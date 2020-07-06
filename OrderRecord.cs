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
        public int OD_NUM_ID;//调度指令序列号
        public int OD_ID;//调度令号
        public int DOWN_COUNT;//下发次数
        public string DISPATCH_ORDER_STATUS;//分发系统的调令状态
        public string DISPATCH_DOWN_TIME;//分发系统下发时间
        public string DOWN_PERSON;//中控下发人
        public string RECEIVE_DEPT;//接收部门
        public string RECEIVE_TIME;//机房接收时间
        public string RECEIVE_PERSON;//接收人
        public string INEXE_REASON;//不可执行原因
        public string BROADCAST_TIME;//开启时间
        public string FEEDBACK_TIME;//反馈时间
        public string FEEDBACK_PERSON;//反馈人员
        public string TRACK_INFO;//调度指令跟踪信息
        public string receive_deptStr;//接收部门显示

        public OrderRecord()
        {
            OD_NUM_ID = -1;
            OD_ID = -1;
            DOWN_COUNT = 0;
            DISPATCH_ORDER_STATUS = "";
            DISPATCH_DOWN_TIME = "";
            DOWN_PERSON = "";
            RECEIVE_DEPT = "";
            RECEIVE_TIME = "";
            RECEIVE_PERSON = "";
            INEXE_REASON = "";
            BROADCAST_TIME = "";
            FEEDBACK_TIME = "";
            FEEDBACK_PERSON = "";
            TRACK_INFO = "";
            receive_deptStr = "";
        }

        public OrderRecord
            (
            int OD_NUM_ID,
            int OD_ID,
            int DOWN_COUNT,
            string DISPATCH_ORDER_STATUS,
            string DISPATCH_DOWN_TIME,
            string DOWN_PERSON,
            string RECEIVE_DEPT,
            string RECEIVE_TIME,
            string RECEIVE_PERSON,
            string INEXE_REASON,
            string BROADCAST_TIME,
            string FEEDBACK_TIME,
            string FEEDBACK_PERSON,
            string TRACK_INFO
            )
        {
            this.OD_NUM_ID=OD_NUM_ID;
            this.OD_ID=OD_ID;
            this.DOWN_COUNT=DOWN_COUNT;
            this.DISPATCH_ORDER_STATUS=DISPATCH_ORDER_STATUS;
            this.DISPATCH_DOWN_TIME=DISPATCH_DOWN_TIME;
            this.DOWN_PERSON=DOWN_PERSON;
            this.RECEIVE_DEPT=RECEIVE_DEPT;
            this.RECEIVE_TIME=RECEIVE_TIME;
            this.RECEIVE_PERSON=RECEIVE_PERSON;
            this.INEXE_REASON=INEXE_REASON;
            this.BROADCAST_TIME=BROADCAST_TIME;
            this.FEEDBACK_TIME=FEEDBACK_TIME;
            this.FEEDBACK_PERSON=FEEDBACK_PERSON;
            this.TRACK_INFO = TRACK_INFO;
            CommUtil.dicDept.TryGetValue(RECEIVE_DEPT, out this.receive_deptStr);
        }

        
    }
}
