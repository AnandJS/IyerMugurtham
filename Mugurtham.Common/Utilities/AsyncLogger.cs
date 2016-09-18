using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugurtham.Common.Utilities
{
    public static class AsyncLogger
    {
        private static readonly log4net.ILog objLog =
        log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static int Debug(string strDebug)
        {
            if (objLog.IsDebugEnabled)
            {
                Task.Run(() => objLog.Debug(strDebug));
            }
            return 0;
        }

        public static int Info(string strInformation)
        {
            if (objLog.IsDebugEnabled)
            {
                Task.Run(() => objLog.Info(strInformation));
            }
            return 0;
        }

        public static int Error(string strError)
        {
            if (objLog.IsDebugEnabled)
            {
                Task.Run(() => objLog.Error(strError));
            }
            return 0;
        }

        public static int Fatal(string strFatal)
        {
            if (objLog.IsDebugEnabled)
            {
                Task.Run(() => objLog.Fatal(strFatal));
            }
            return 0;
        }
    }
}
