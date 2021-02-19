using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispatchServer.BaseUtil;

namespace DispatchServer
{
    public class OrderRecord
    {
        public int ID;//ID
        public int orderId;//调度令ID
        public int orderNumId;//调度指令ID
        public int downCount;//下发次数
        public string dispatchOrderStatus;//分发系统调令状态
        public string dispatchDownTime;//分发系统下发时间
        public string receiveDept;//接收部门
        public string clientReceiveTime;//客户端接收时间
        public string deptConfirmTime;//部门确认时间
        public string deptConfirmPerson;//部门确认人员
        public string inexeReason;//不可执行原因
        public string deptFeedbackTime;//反馈时间
        public string deptFeedbackPerson;//反馈人员
        public string broadcastTime;//开启时间
        public string trackInfo;//调度指令跟踪信息

        public OrderRecord()
        {
            ID = -1;
            orderId=-1;//调度令ID
            orderNumId=-1;//调度指令ID
            downCount=-1;//下发次数
            dispatchOrderStatus = null;//分发系统调令状态
            dispatchDownTime=null;//分发系统下发时间
            receiveDept = null;//接收部门
            clientReceiveTime = null;//客户端接收时间
            deptConfirmTime = null;//部门接收时间
            deptConfirmPerson = null;//部门接收人员
            inexeReason = null;//不可执行原因
            deptFeedbackTime = null;//反馈时间
            deptFeedbackPerson = null;//反馈人员
            broadcastTime = null;//开启时间
            trackInfo = null;//调度指令跟踪信息
        }

        public OrderRecord
            (
              int ID,//ID
             int orderId,//调度令ID
             int orderNumId,//调度指令ID
             int downCount,//下发次数
             string dispatchOrderStatus,//分发系统调令状态
             string dispatchDownTime,//分发系统下发时间
             string receiveDept,//接收部门
             string clientReceiveTime,//客户端接收时间 
             string deptConfirmTime,//部门确认时间
             string deptConfirmPerson,//部门确认人员
             string inexeReason,//不可执行原因
             string deptFeedbackTime,//反馈时间
             string deptFeedbackPerson,//反馈人员
             string broadcastTime,//开启时间
             string trackInfo//调度指令跟踪信息
            )
        {
           this.ID =ID;
           this.orderId = orderId;
           this.orderNumId = orderNumId;
           this.downCount = downCount;
           this.dispatchOrderStatus = dispatchOrderStatus;
           this.dispatchDownTime = dispatchDownTime;
           this.receiveDept = receiveDept;
           this.clientReceiveTime = clientReceiveTime;
           this.deptConfirmTime = deptConfirmTime;
           this.deptConfirmPerson = deptConfirmPerson;
           this.inexeReason = inexeReason;
           this.deptFeedbackTime = deptFeedbackTime;
           this.deptFeedbackPerson = deptFeedbackPerson;
           this.broadcastTime = broadcastTime;
           this.trackInfo = trackInfo;
        }
    }
}
