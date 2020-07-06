using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DispatchServer;
using DispatchServer.BaseClass;

namespace zk
{
    public static class GlobalVarForApp        //存放程序的全局变量
    {
        public static User currentUserStr;
        public static bool networkStatusBool = false;                   //客户端与服务器网络状态
        public static bool network_server_database_bool = false;//服务器与数据库网络状态
        public static bool network_server_jia_bool = false;
        public static bool network_server_yi_bool = false;          // 服务器与乙客户端网络状态

        public static int server_port = 0;         //服务器ip及端口号
        public static string server_ip = "";
        public static string client_type = "";  //客户端类型
        public static Queue<RSData> receiveMessageQueue = new Queue<RSData>();         //消息接收队列
        public static Queue<RSData> sendMessageQueue = new Queue<RSData>();            //消息发送队列
        public static List<OrderInfo> tbh_ordersInfoList = new List<OrderInfo>();                             //存放未处理完成的所有调度令的信息

        public static void GlobalVarForAppInitial()
        {
            networkStatusBool = false;
            network_server_database_bool = false;
            network_server_jia_bool = false;
            network_server_yi_bool = false;
            receiveMessageQueue.Clear();
            sendMessageQueue.Clear();
            tbh_ordersInfoList.Clear();
        }
    }
}
