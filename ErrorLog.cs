using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchServer.BaseClass
{
    public class ErrorLog
    {
        public string LogTime;
        public string LogInfo;


        public ErrorLog()
        {
            LogTime = "";
            LogInfo = "";
        }

        public ErrorLog(string logTime, string logInfo)
        {
            LogTime = logTime;
            LogInfo = logInfo;
        }
    }
}
