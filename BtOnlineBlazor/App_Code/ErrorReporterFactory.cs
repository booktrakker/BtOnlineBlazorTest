using BTOnlineBlazor.Services;
using BTOnlineBlazor.Data;

namespace BTOnlineBlazor.App_Code
{
    public class ErrorReporterFactory
    {
        private static readonly Lazy<ErrorReporterFactory> lazy = new Lazy<ErrorReporterFactory>(() => new ErrorReporterFactory());
        
        public static ErrorReporterFactory Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public ErrorReporterFactory()
        {
            
        }        

        public ErrorReporterService CreateErrorReporter()
        {
            return new ErrorReporterService();
        }

    }
}
