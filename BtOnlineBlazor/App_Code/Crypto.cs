using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using BTOnlineBlazor.Data;
using BTOnlineBlazor.Services;

namespace BTOnlineBlazor
{
    public static class SafeBase64UrlEncoder
    {
        private const string Plus = "+";
        private const string Minus = "-";
        private const string Slash = "/";
        private const string Underscore = "_";
        private const string EqualSign = "=";
        private const string Pipe = "|";
        private static readonly IDictionary<string, string> _mapper;        

        private static ErrorReporterService errReport = new ErrorReporterService();
        static SafeBase64UrlEncoder()
        {
            _mapper = new Dictionary<string, string> { { Plus, Minus }, { Slash, Underscore }, { EqualSign, Pipe } };
        }
        /// <summary>
        /// Encode the base64 to safeUrl64
        /// </summary>
        /// <param name="base64Str"></param>
        /// <returns></returns>
        public static string EncodeBase64Url(this string base64Str)
        {
            if (string.IsNullOrEmpty(base64Str))
                return base64Str;
            foreach (var pair in _mapper)
            {
                base64Str = base64Str.Replace(pair.Key, pair.Value);
            }
            return base64Str;
        }
        /// <summary>
        /// Decode the Url back to original base64
        /// </summary>
        /// <param name="safe64Url"></param>
        /// <returns></returns>
        public static string DecodeBase64Url(this string safe64Url)
        {
            if (string.IsNullOrEmpty(safe64Url))
                return safe64Url;
            foreach (var pair in _mapper)
            {
                safe64Url = safe64Url.Replace(pair.Value, pair.Key);
            }
            return safe64Url;
        }
    }

    public class Crypto
    {
        private static ErrorReporterService errReport = new ErrorReporterService();
        private static byte[] _salt = Encoding.ASCII.GetBytes("o6806642kbM7c5");

        private const string EncryptKey1 = "BC2C1D57-ED8A-438D";
        private const string EncryptKey2 = "-B0EF-F635E7D4F73F";

        public const string cKey2 = "-820A-63A5511590EB";
        public const string cKey1 = "ADA8A12C-7F76-4015";

        /// <summary>    /// Encrypt the given string using AES.  The string can be decrypted using
        /// DecryptStringAES().  The sharedSecret parameters must match.    
        /// </summary>    /// <param name="plainText">The text to encrypt.</param>    
        /// <param name="sharedSecret">A password used to generate a key for encryption.</param>    
        public static string EncryptStringAES(string plainText, string sharedSecret)
        {
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException("plainText");
            if (string.IsNullOrEmpty(sharedSecret))
                throw new ArgumentNullException("sharedSecret");
            string outStr = null;
            // Encrypted string to return
            RijndaelManaged aesAlg = null;
            // RijndaelManaged object used to encrypt the data.
            try
            {
                // generate the key from the shared secret and the salt            
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, _salt);
                // Create a RijndaelManaged object            
                // with the specified key and IV.            
                aesAlg = new RijndaelManaged();
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                aesAlg.IV = key.GetBytes(aesAlg.BlockSize / 8);
                // Create a decrytor to perform the stream transform.            
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                // Create the streams used for encryption.            
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.                        
                            swEncrypt.Write(plainText);
                        }
                    }
                    outStr = Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
            finally
            {
                // Clear the RijndaelManaged object.            
                if (aesAlg != null)
                    aesAlg.Clear();
            }
            // Return the encrypted bytes from the memory stream.        
            return outStr;
        }
        /// <summary>    
        /// Decrypt the given string.  Assumes the string was encrypted using     
        /// EncryptStringAES(), using an identical sharedSecret.    
        /// </summary>    
        /// <param name="cipherText">The text to decrypt.</param>    
        /// <param name="sharedSecret">A password used to generate a key for decryption.</param>    
        public static string DecryptStringAES(string cipherText, string sharedSecret)
        {
            if (string.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException("cipherText");
            if (string.IsNullOrEmpty(sharedSecret))
                throw new ArgumentNullException("sharedSecret");
            // Declare the RijndaelManaged object
            // used to decrypt the data.        
            RijndaelManaged aesAlg = null;
            // Declare the string used to hold
            // the decrypted text.        
            string plaintext = null;
            try
            {
                // generate the key from the shared secret and the salt
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, _salt);
                // Create a RijndaelManaged object            
                // with the specified key and IV.            
                aesAlg = new RijndaelManaged();
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                aesAlg.IV = key.GetBytes(aesAlg.BlockSize / 8);
                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                // Create the streams used for decryption.                            
                byte[] bytes = Convert.FromBase64String(cipherText);
                using (MemoryStream msDecrypt = new MemoryStream(bytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.                        
                            plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }
            return plaintext;
        }

        public static string EncryptUrlField(string Value)
        {
            string RetVal = "";
                        
            
            try
            {
                if (Value != "")
                    return SafeBase64UrlEncoder.EncodeBase64Url(EncryptStringAES(Value, EncryptKey1 + EncryptKey2));
                else
                    RetVal = "";
            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
            }

            return RetVal;
        }
        public static string DecryptUrlField(string Value)
        {
            string RetVal = "";            

            try
            {
                if (Value != "")
                    return DecryptStringAES(SafeBase64UrlEncoder.DecodeBase64Url(Value), EncryptKey1 + EncryptKey2);
                else
                    RetVal = "";
            }
            catch (Exception ex)
            {
                errReport.LogErr("Bad Value was " + Value, ex);
            }

            return RetVal;
        }
    }
}