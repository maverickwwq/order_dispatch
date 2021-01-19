using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchServer.BaseClass
{
    public class SystemLog
    {
        public string LogTime;
        public string LogInfo;

        public SystemLog()
        {
            LogTime = "";
            LogInfo = "";
        }

        public SystemLog(string logTime, string logInfo)
        {
            LogTime = logTime;
            LogInfo = logInfo;
        }
    }
}
