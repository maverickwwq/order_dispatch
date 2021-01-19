using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchServer.BaseClass
{
    public class OperateLog
    {
        public string OperateTime;
        public string OperateInfo;
        public string OperateUser;

        public OperateLog()
        {
            OperateTime = "";
            OperateInfo = "";
            OperateUser = "";
        }

        public OperateLog(string operateTime,string operateInfo,string operateUser)
        {
            OperateTime = operateTime;
            OperateInfo = operateInfo;
            OperateUser = operateUser;
        }
    }
}
