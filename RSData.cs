using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispatchServer.BaseClass;

namespace DispatchServer
{
    public class RSData
    {
        public string CommType = "";//通讯类型的定义
        public string CommTime = "";//通讯时间的定义
        public string CommDept = "";//通讯机房代码定义
        public User currentUser = null;//当前用户

        //连接状态
        public ConnectState connectState = null;

        //设置相关的操作变量
        public User user = null;//用户(单个)
        public List<User> userList = null;//用户(多个)
        public string infoReturn=null;//操作信息返回

        //调令相关的操作变量
        public Order order = null;//调度令(单个)

        //-------------------------------------------------------------------------------------------------------------------
        public List<Order> orderList = null;//调度令(多个)
        //-------------------------------------------------------------------------------------------------------------------

        public string newMessage = null;//新消息提醒内容

        //查询相关
        public Query query = null;//相关查询变量

        //系统标识
        public bool ifRequestSucess = false;//请求操作是否成功

        public RSData()
        {
        }
    }
}
