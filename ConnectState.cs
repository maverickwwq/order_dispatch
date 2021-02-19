
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchServer.BaseClass
{
    public class ConnectState
    {
        public bool JiaConnect = false;//甲机房客户端连接状态
        public bool YiConnect = false;//乙机房客户端连接状态
        public bool DatabaseConnect = false;//数据库连接状态
        public bool ServerConnect = false;//服务器连接状态

        public ConnectState()
        { 

        }
    }
}
