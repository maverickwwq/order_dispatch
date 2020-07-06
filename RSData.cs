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
        public string CommDept = "";//通讯机房名称：甲机房7830、乙机房7831，中控机房7850
        public User currentUser = null;//当前用户

        //连接状态
        public ConnectState connectState = null;

        //设置相关的操作变量
        public User user = null;
        public List<User> userList = null;
        public string infoReturn=null;//操作信息返回

        //调令相关的操作变量
        public Order order = null;//下发的调度令
        public List<OrderOp> orderOpList = null;//调度指令集
        public List<OrderRecord> orderRecordList = null;//调令跟踪记录
        public List<OrderAndOp> orderAndOpList = null;//调令综合信息
        public string newMessage = null;//新消息提醒条数

        //查询相关
        public Query query = null;//相关查询变量

        //系统标识
        public bool ifRequestSucess = false;//请求操作是否成功
       

        public RSData()
        {
        }
    }
}
