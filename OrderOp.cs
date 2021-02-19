using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispatchServer.BaseUtil;

namespace DispatchServer
{
    public class OrderOp
    {
        public int OD_NUM_ID;//指令序号
        public int OD_ID;//调度令序号
        public int NUM;//调度指令序号
        public string ORDER_TYPE;//任务类型
        public int TR_ID;//发射机序号
        public int AN_ID;//天线序号
        public string START_DATE;//开始执行日期
        public string END_DATE;//结束执行日期
        public string START_TIME;//开始播音时间
        public string END_TIME;//结束播音时间
        public int FREQ;//频率
        public int POWER;//功率
        public int PG_ID;//节目序号
        public string AZIMUTH_M;//方向
        public string AZIMUTH_DE;//偏向
        public string ANT_PROG;//
        public string OPERATE;//操作，0-停，1-开
        public int TARGET;//对象台
        public string SERV_AREA;//服务区
        public string DAYS;//周期
        public string MSG_NUM;//需求文号
        public string CHANNEL;//节目通道
        public string SEASON;//季节
        public string MOD;//调制方式
        public string RMKS;//备注
        public string STATUS;//状态
        public string STATUS_DATE;//状态日期
        public string INEXE_REASON_CODE;//不可执行原因
        public string INEXE_PERSON;//机房确认人
        public string BROADCAST_TIME;
        public string INNER_INSTEAD_TASK_INFO;
        public string INS_ST_CODE;
        public string INS_TRANS_USED_CODE;

        public string orderTypeDisplay;//任务类型显示
        public string trDisplay;//发射机显示
        public string anDisplay;//天线号显示
        public string operateDisplay;//操作显示
        public string omsStatusDisplay;//调令状态显示

        public OrderOp()
        {
            OD_NUM_ID = -1;
            OD_ID = -1;
            NUM = -1;
            ORDER_TYPE = "";
            TR_ID = -1;
            AN_ID = -1;
            START_DATE = "";
            END_DATE = "";
            START_TIME = "";
            END_TIME = "";
            FREQ = -1;
            POWER = -1;
            PG_ID = -1;
            AZIMUTH_M = "";
            AZIMUTH_DE = "";
            ANT_PROG = "";
            OPERATE = "";
            TARGET = -1;
            SERV_AREA = "";
            DAYS = "";
            MSG_NUM = "";
            CHANNEL = "";
            SEASON = "";
            MOD = "";
            RMKS = "";
            STATUS = "";
            STATUS_DATE = "";
            INEXE_REASON_CODE = "";
            INEXE_PERSON = "";
            orderTypeDisplay="";
            trDisplay="";
            anDisplay="";
            operateDisplay="";
            omsStatusDisplay = "";
        }

        public OrderOp
            (
             int OD_NUM_ID,
             int OD_ID,
             int NUM,
             string ORDER_TYPE,
             int TR_ID,
             int AN_ID,
             string START_DATE,
             string END_DATE,
             string START_TIME,
             string END_TIME,
             int FREQ,
             int POWER,
             int PG_ID,
             string AZIMUTH_M,
             string AZIMUTH_DE,
             string ANT_PROG,
             string OPERATE,
             int TARGET,
             string SERV_AREA,
             string DAYS,
             string MSG_NUM,
             string CHANNEL,
             string SEASON,
             string MOD,
             string RMKS,
             string STATUS,
             string STATUS_DATE,
             string INEXE_REASON_CODE,
             string INEXE_PERSON,
             string BROADCAST_TIME,
             string INNER_INSTEAD_TASK_INFO,
             string INS_ST_CODE,
             string INS_TRANS_USED_CODE
            )
        {
            this.OD_NUM_ID = OD_NUM_ID;
            this.OD_ID=OD_ID;
            this.NUM=NUM;
            this.ORDER_TYPE=ORDER_TYPE;
            this.TR_ID=TR_ID;
            this.AN_ID=AN_ID;
            this.START_DATE=START_DATE;
            this.END_DATE=END_DATE;
            this.START_TIME=START_TIME;
            this.END_TIME=END_TIME;
            this.FREQ=FREQ;
            this.POWER=POWER;
            this.PG_ID=PG_ID;
            this.AZIMUTH_M=AZIMUTH_M;
            this.AZIMUTH_DE=AZIMUTH_DE;
            this.ANT_PROG=ANT_PROG;
            this.OPERATE=OPERATE;
            this.TARGET=TARGET;
            this.SERV_AREA=SERV_AREA;
            this.DAYS=DAYS;
            this.MSG_NUM=MSG_NUM;
            this.CHANNEL=CHANNEL;
            this.SEASON=SEASON;
            this.MOD=MOD;
            this.RMKS=RMKS;
            this.STATUS=STATUS;
            this.STATUS_DATE=STATUS_DATE;
            this.INEXE_REASON_CODE=INEXE_REASON_CODE;
            this.INEXE_PERSON=INEXE_PERSON;
            this.BROADCAST_TIME=BROADCAST_TIME;
            this.INNER_INSTEAD_TASK_INFO=INNER_INSTEAD_TASK_INFO;
            this.INS_ST_CODE=INS_ST_CODE;
            this.INS_TRANS_USED_CODE=INS_TRANS_USED_CODE;

            CommUtil.dicOrderType.TryGetValue(ORDER_TYPE, out orderTypeDisplay);
            //CommUtil.dicTR.TryGetValue(TR_ID.ToString(), out trDisplay);
            //CommUtil.dicAN.TryGetValue(AN_ID.ToString(), out anDisplay);
            if (this.OPERATE.Equals("0"))
                operateDisplay = "停";
            else if (this.OPERATE.Equals("1"))
                operateDisplay = "开";
            CommUtil.dicOmsOrderOpStatus.TryGetValue(STATUS,out omsStatusDisplay);
        }
    }
}
