using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispatchServer.BaseClass;
using zk;

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

        public void fill_feedback_order(OrderInfo toSend)
        {
            CommType = "FEEDBACK_ORDER";
            CommTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            CommDept = GlobalVarForApp.client_type; ;
            Order a = new Order();
            a.orderCode = toSend.orderCode;
            a.orderId = toSend.orderID;
            a.orderRecordList = new List<OrderRecord>();
            for (int j = 0; j < toSend.orderOpCount; j++)
            {
                OrderRecord b = new OrderRecord();
                b.orderId = toSend.orderID;
                b.orderNumId = toSend.ooc[j].orderOpID;
                if (toSend.oos[j].feedback == true)
                {
                    b.broadcastTime = toSend.oos[j].feedbackTime;
                    b.inexeReason = null;
                }
                else
                {
                    toSend.oos[j].feedback = false;
                    b.broadcastTime = null;
                    b.inexeReason = toSend.oos[j].unableReason;
                }
                a.orderRecordList.Add(b);
            }
            order = a;
        }

        public void fill_receive_order(OrderInfo toSend)
        {
            CommType = "RECEIVE_ORDER";
            CommTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            CommDept = GlobalVarForApp.client_type;
            Order a = new Order();
            a.orderCode = toSend.orderCode;
            a.orderId = toSend.orderID;
            a.orderRecordList = new List<OrderRecord>();
            for (int j = 0; j < toSend.orderOpCount;j++ )
            {
                OrderRecord b = new OrderRecord();
                b.orderNumId = toSend.ooc[j].orderOpID;
                a.orderRecordList.Add(b);
            }
        }

        public void fill_confirm_order(OrderInfo toSend)
        {
            CommType = "CONFIRM_ORDER";
            CommTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            CommDept = GlobalVarForApp.client_type;
            Order a = new Order();
            a.orderCode = toSend.orderCode;
            a.orderId = toSend.orderID;
            OrderRecord b = new OrderRecord();

        }
    }
}
