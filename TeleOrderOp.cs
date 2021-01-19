using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchServer.BaseClass
{
    class TeleOrderOp
    {
        public int OD_ID;//调度令ID
        public int OD_NUM_ID;//调度指令序号
        public string START_DATE;//开始执行日期
        public string END_DATE;//结束执行日期
        public string START_TIME;//开始播音时间
        public string END_TIME;//结束播音时间
        public int TR_ID;//发射机设备号
        public int AN_ID;//天线设备号
        public int FREQ;//频率
        public string DAYS;//周期
        public string AZIMUTH_M;//方向
        public string ANT_PROG;// 程式
        public string CHANNEL_NAME;//节目
        public int POWER;//功率
        public string OPERATE;//操作，0-停，1-开
        public string CHANNEL;//节目通道
        public string ORDER_TYPE;//任务类型

        public TeleOrderOp()
        {
             OD_ID = -1;
            OD_NUM_ID=-1;
            START_DATE="";
            END_DATE = "";
            START_TIME = "";
            END_TIME = "";
            TR_ID = -1;
            AN_ID=-1;
            FREQ=-1;
            DAYS = "";
            AZIMUTH_M = "";
            ANT_PROG = "";
            CHANNEL_NAME = "";
            POWER=-1;
            OPERATE = "";
            CHANNEL = "";
            ORDER_TYPE = "";
        }
    }
}
