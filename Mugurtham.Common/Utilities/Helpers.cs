using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Configuration;

namespace Mugurtham.Common.Utilities
{
    [MugurthamBaseAPIController]
    public static class Helpers
    {
        private static readonly string AppKeyLogFilePath = "LogFilePath";
        private static readonly string AppKeyConnectionstring = "MugurthamConnectionString";

        private static readonly string strLogilePath = ConfigurationManager.AppSettings[AppKeyLogFilePath] + "Log_" + DateTime.Now.ToShortDateString().Replace('/', '-') + ".log";
        private static readonly string strConnectionstring = System.Configuration.ConfigurationManager.ConnectionStrings[AppKeyConnectionstring].ConnectionString;

        public static string LogFilePath
        {
            get
            {
                return strLogilePath;
            }
        }
        /// <summary>
        /// Gets the ConnectionString of the Mugurtham Database
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                return strConnectionstring;
            }
        }

        public static string primaryKey
        {
            get
            {
                return Guid.NewGuid().ToString().Substring(1, 20).Replace("-", "").ToUpper();
            }
        }

        public static string passwordGenerator()
        {
            return Guid.NewGuid().ToString().Substring(1, 5).Replace("-", "").ToUpper();
        }

        /// <summary>
        /// Logging a general message in the log file
        /// </summary>
        /// <param name="strText">Text to log</param>
        public static void LogMessage(string strText)
        {
            AsyncLogger.Info(strText);
        }

        public static void LogMessageInFlatFile1(string strText)
        {
            try
            {
                StringBuilder objSB = new StringBuilder();
                objSB.Append(strText + "\r\n");
                // flush every 20 seconds as you do it
                File.AppendAllText(strLogilePath, objSB.ToString());
                objSB.Remove(0, objSB.Length);
                objSB.Clear();
                objSB = null;
            }
            catch (Exception objEx)
            {
                Helpers.LogMessage(objEx.Message + objEx.StackTrace);
            }
        }

        public static void LogMessageInFlatFile(string strText)
        {
            try
            {
                StringBuilder objSB = new StringBuilder();
                objSB.Append("==============================================================================" + "\r\n");
                objSB.Append(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString() + "\r\n");
                objSB.Append(strText + "\r\n");
                objSB.Append("==============================================================================" + "\r\n");
                // flush every 20 seconds as you do it
                File.AppendAllText(strLogilePath, objSB.ToString());
                objSB.Remove(0, objSB.Length);
                objSB.Clear();
                objSB = null;
            }
            catch (Exception objEx)
            {
                Helpers.LogMessage(objEx.Message + objEx.StackTrace);
            }
        }

        /// <summary>
        /// Don't encrypt passwords, they're vulnerable to decryption and attacks. Hash them instead. Something like this
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string EncodePasswordToBase64(string password)
        {
            string strHashedText = string.Empty;
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            strHashedText = Convert.ToBase64String(inArray);
            return Convert.ToBase64String(inArray);
        }

        /// <summary>
        /// One of the popular (or simple) method is MD5 Hash Algorithm. 
        /// The point is this algorithm change your password into 32 hexadecimal digits. 
        /// It doesn’t care how long is your password and it’ll become 32 hexadecimal digits. 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string EncodePasswordToMD5Hash(string strPassword)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strPassword));
            //get hash result after compute it
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }

        public static string readLogFile(string strLogFilePath)
        {
            string strText = string.Empty;
            //var fileStream = new FileStream(@"C:\\Inetpub\\vhosts\\mugurtham.com\\test\\Log\\MugurthamLog.log", FileMode.Open, FileAccess.Read);
            //var fileStream = new FileStream(@"D:\\Mugurtham\\GIT\\Mugurtham\\Mugurtham.Service\\Log\\MugurthamLog.log", FileMode.Open, FileAccess.Read);
            var fileStream = new FileStream(strLogFilePath, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                strText = streamReader.ReadToEnd();
            }
            return strText;
        }

        public static void LogExceptionInFlatFile(Exception objEx)
        {
            StringBuilder objSB = new StringBuilder();
            objSB.Append("==============================================================================" + "\r\n");
            objSB.Append(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString() + "\r\n");
            objSB.Append("Message : " + objEx.Message + "\r\n\r\n");
            objSB.Append("InnerException : " + objEx.InnerException + "\r\n\r\n");
            objSB.Append("StackTrace : " + objEx.StackTrace + "\r\n\r\n");
            objSB.Append("==============================================================================" + "\r\n");
            // flush every 20 seconds as you do it
            File.AppendAllText(strLogilePath, objSB.ToString());
            objSB.Remove(0, objSB.Length);
            objSB.Clear();
            objSB = null;
        }
    }
}
