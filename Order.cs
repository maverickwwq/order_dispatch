using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispatchServer.BaseUtil;

namespace DispatchServer
{
    public class Order
    {
        public int OD_ID;//调度令ID
        public int ORDER_YEAR;//年份
        public string ORDER_CODE;//文号
        public string SOURCE_TYPE;//调度令性质
        public string ORDER_STATUS;//状态
        public string STATUS_DATE;//状态日期
        public string SENDER;//发送人
        public string SEND_DATE;//发送时间
        public string SEND_ASSESSOR;//发送审核人
        public string SEND_DEPT;//发送单位
        public string RECEIVER;//台站接收人
        public string RECEIVER_DATE;//接收时间
        public string CORRECTOR;//接收校对人
        public string CORRECT_DATE;//校对时间
        public string RMKS;//备注
        public string CREATE_TYPE;//创建类型
        public string INS_ST_CODE;//故障台站编号
        public string INS_TRANS_CODE;//故障发射机使用编号
        public string REASON;//代播原因
        public string ORDER_FORMAT;//任务格式
        public string FLAG_REPLY;//可执行反馈
        public string REPLY_DATE;//可执行反馈时间
        public string INSTEAD_FLAG;
        public int INS_ID;//
        
        public string OrderCodeDisplay;//文号显示
        public string SourceTypeDisplay;//调令性质显示

        public Order()
        {
            OD_ID = -1;
            ORDER_YEAR = -1;
            ORDER_CODE = "";
            SOURCE_TYPE = "";
            ORDER_STATUS = "";
            STATUS_DATE = "";
            SENDER = "";
            SEND_DATE = "";
            SEND_ASSESSOR = "";
            SEND_DEPT = "";
            RECEIVER = "";
            RECEIVER_DATE = "";
            CORRECTOR = "";
            CORRECT_DATE = "";
            RMKS = "";
            CREATE_TYPE = "";
            INS_ST_CODE = "";
            INS_TRANS_CODE = "";
            REASON = "";
            ORDER_FORMAT = "";
            FLAG_REPLY = "";
            REPLY_DATE = "";
            INSTEAD_FLAG = "";
            INS_ID = -1;
            OrderCodeDisplay = "";
            SourceTypeDisplay = "";
        }

        public Order(
            int OD_ID,
            int ORDER_YEAR,
            string ORDER_CODE,
            string SOURCE_TYPE,
            string ORDER_STATUS,
            string STATUS_DATE,
            string SENDER,
            string SEND_DATE,
            string SEND_ASSESSOR,
            string SEND_DEPT,
            string RECEIVER,
            string RECEIVER_DATE,
            string CORRECTOR,
            string CORRECT_DATE,
            string RMKS,
            string CREATE_TYPE,
            string INS_ST_CODE,
            string INS_TRANS_CODE,
            string REASON,
            string ORDER_FORMAT,
            string FLAG_REPLY,
            string REPLY_DATE,
            string INSTEAD_FLAG,
            int INS_ID
            )
        {
            this.OD_ID = OD_ID;
            this.ORDER_YEAR = ORDER_YEAR;
            this.ORDER_CODE = ORDER_CODE;
            this.SOURCE_TYPE = SOURCE_TYPE;
            this.ORDER_STATUS = ORDER_STATUS;
            this.STATUS_DATE = STATUS_DATE;
            this.SENDER = SENDER;
            this.SEND_DATE = SEND_DATE;
            this.SEND_ASSESSOR = SEND_ASSESSOR;
            this.SEND_DEPT = SEND_DEPT;
            this.RECEIVER = RECEIVER;
            this.RECEIVER_DATE = RECEIVER_DATE;
            this.CORRECTOR = CORRECTOR;
            this.CORRECT_DATE = CORRECT_DATE;
            this.RMKS = RMKS;
            this.CREATE_TYPE = CREATE_TYPE;
            this.INS_ST_CODE = INS_ST_CODE;
            this.INS_TRANS_CODE = INS_TRANS_CODE;
            this.REASON = REASON;
            this.ORDER_FORMAT = ORDER_FORMAT;
            this.FLAG_REPLY = FLAG_REPLY;
            this.REPLY_DATE = REPLY_DATE;
            this.INSTEAD_FLAG = INSTEAD_FLAG;
            this.INS_ID = INS_ID;
            this.OrderCodeDisplay = "广无调单字【"+ORDER_YEAR+"】"+ORDER_CODE+"号";
            CommUtil.dicSourceType.TryGetValue(SOURCE_TYPE, out this.SourceTypeDisplay);
        }
    }
}
