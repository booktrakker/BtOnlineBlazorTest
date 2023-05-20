using BTOnlineBlazor.Services;
using BTOnlineBlazor.Services.Interfaces;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace BTOnlineBlazor.App_Code
{
    public static class Utilities
    {
        public static string BuildXML(DataSet dataSet, string encryptionKey)
        {
            string result = "Error: XML Table Conversion Failed";
            try
            {
                StringWriter dataString = new StringWriter();
                dataSet.WriteXml(dataString, XmlWriteMode.WriteSchema);
                result = dataString.ToString();

                result = Crypto.EncryptStringAES(result, encryptionKey);
            }
            catch (Exception ex)
            {
                throw (new Exception("Utilities.BuildXML: Failed to serialize input.", ex));
            }

            return result;
        }

        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
        public static DataTable ToDataTable<T>(this IEnumerable<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
        public static void ToDataTable<T>(this IEnumerable<T> data, DataTable table)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));

            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }

        }

        public static TConvert ConvertTo<TConvert>(this object entity) where TConvert : new()
        {            

            try
            {
                if (Equals(entity, DBNull.Value) || (entity is string && string.IsNullOrEmpty((string)entity)))
                    return default(TConvert); //<-That is how to return a default value for any type object.

                TypeConverter converter = TypeDescriptor.GetConverter(typeof(TConvert));

                if (entity is string && (typeof(TConvert) == typeof(int) || typeof(TConvert) == typeof(decimal) || typeof(TConvert) == typeof(double) ||
                                         typeof(TConvert) == typeof(float) ||
                                         typeof(TConvert) == typeof(long)))
                {
                    entity = ((string)entity).Replace("'", "");
                }

                if (converter != null && converter.CanConvertFrom(entity.GetType()))
                    return (TConvert)converter.ConvertFrom(entity);

                if ((entity.GetType().Equals(typeof(System.Int16)) || entity.GetType().Equals(typeof(System.Int32))) && typeof(TConvert).Equals(typeof(DateTime)))
                {
                    return (TConvert)converter.ConvertFrom(entity.ToString() + "-01-01");
                }

                else if (entity.GetType() != typeof(System.String))
                {
                    return (TConvert)converter.ConvertFrom(entity.ToString());
                }

                throw new InvalidCastException(string.Format("Cannot convert '{0}'  to {1} ", typeof(TConvert).Name, entity.GetType().Name));

            }
            catch (Exception ex)
            {
                throw new Exception("ConvertTo value was '" + entity.ToString() + "', Output Type: " + typeof(TConvert), ex);                
            }            
        }

        public static string MapPath(string path)
        {
            string? rootPath = AppDomain.CurrentDomain.GetData("ContentRootPath")?.ToString();

            if (rootPath != null) {
                return Path.Combine(rootPath,
                    path);
            }

            return string.Empty;
        }

        public static string ToDebugString<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return "{" + string.Join(",", dictionary.Select(kv => kv.Key + "=" + kv.Value).ToArray()) + "}";
        }
        public static string ToDebugList<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return "{" + string.Join(",", dictionary.Select(kv => kv.Key + "=" + kv.Value.PropertyList()).ToArray()) + "}";
        }
        public static string PropertyList(this object obj)
        {
            var props = obj.GetType().GetProperties();
            var sb = new StringBuilder();
            foreach (var p in props)
            {
                sb.AppendLine(p.Name + ": " + p.GetValue(obj, null));
            }
            return sb.ToString();
        }


        public static bool IsNumeric(this string @this)
        {
            return !Regex.IsMatch(@this, "[^0-9]");
        }

    }

    public static class FileHelper
    {
        public static byte[] GetFileBytes(FileInfo fInfo)
        {
            byte[] fileContent;
            using (Stream fileStream = fInfo.OpenRead())
            {
                BinaryReader bin = new BinaryReader(fileStream);

                fileContent = bin.ReadBytes((int)fInfo.Length);
                bin.Dispose();
            }
            return fileContent;
        }

        public static string GetFileSizeLabel(FileInfo fInfo)
        {
            double fsize = fInfo.Length;
            string sizeLabel = "Byte";
            if (fsize > 1024)
            {
                fsize = fsize / 1024;
                sizeLabel = "kb";
            }
            if (fsize > 1024)
            {
                fsize = fsize / 1024;
                sizeLabel = "MB";
            }
            if (fsize > 1024)
            {
                fsize = fsize / 1024;
                sizeLabel = "GB";
            }

            fsize = Math.Round(fsize, 2);

            return fInfo.Name + " " + fsize + sizeLabel;
        }

        //public static async Task WaitForShutdownAsync(this IHost host)
        //{
        //    // Get the lifetime object from the DI container
        //    var applicationLifetime = host.Services.GetService<IHostApplicationLifetime>();

        //    // Create a new TaskCompletionSource called waitForStop
        //    var waitForStop = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);

        //    // Register a callback with the ApplicationStopping cancellation token
        //    applicationLifetime.ApplicationStopping.Register(obj =>
        //    {
        //        var tcs = (TaskCompletionSource<object>)obj;


        //        //PUT YOUR CODE HERE 
        //        ErrorReporterFactory.Instance.CreateErrorReporter().LogEventMessage("Shutting Down");
        //        // When the application stopping event is fired, set 
        //        // the result for the waitForStop task, completing it
        //        tcs.TrySetResult(null);
        //    }, waitForStop);

            
        //    // Await the Task. This will block until ApplicationStopping is triggered,
        //    // and TrySetResult(null) is called
        //    await waitForStop.Task;

            

        //    // We're shutting down, so call StopAsync on IHost
        //    await host.StopAsync();
        //}
    }
}
