using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispatchServer.BaseUtil;

namespace DispatchServer.BaseClass
{
    public class OrderAndOp
    {
        public string odId;//调度令ID
        public string orderYear;//调令年份
        public string orderCode;//调令文号
        public string sourceType;//调度令性质
        public string dispatchOrderStatus;//调度令状态
        public string omsDownTime;//台运行管理系统下发时间
        public string dispatchDownTime;//分发系统下发时间
        public string downPerson;//中控下发人员
        public string deptReceiveTime;//机房人员接收时间
        public string receivePerson;//机房接收人员
        public string feedbackTime;//机房人员反馈时间

        public string freqStr;//所有频率
        public string trStr;//所有发射机
        public string anStr;//所有天线

        public OrderAndOp()
        { 
            odId="";
            orderYear="";
            orderCode="";
            sourceType="";
            dispatchOrderStatus="";
            omsDownTime="";
            dispatchDownTime="";
            downPerson="";
            deptReceiveTime="";
            receivePerson="";
            feedbackTime="";
            freqStr = "";
            trStr = "";
            anStr = "";
        }

        public OrderAndOp
            (
            string odId,
            string orderYear,
            string orderCode,
            string sourceType,
            string dispatchOrderStatus,
            string omsDownTime,
            string dispatchDownTime,
            string downPerson,
            string deptReceiveTime,
            string receivePerson,
            string feedbackTime
            )
        {
            this.odId = odId;
            this.orderYear = orderYear;
            this.orderCode=orderCode;
            this.sourceType=sourceType;
            this.downPerson = downPerson;
            this.receivePerson = receivePerson;
            this.dispatchOrderStatus = dispatchOrderStatus;
            this.omsDownTime = omsDownTime;
            this.dispatchDownTime = dispatchDownTime;
            this.deptReceiveTime = deptReceiveTime;
            this.feedbackTime = feedbackTime;
        }

        public void createTrAnFreq(string[] an, string[] freq)
        {
             //将机号、天线号、频率合并放入orderAndOp
            string trStr = "", freqStr = "", anStr = "";
            for (int k = 0; k < 7; k++)
            {
                if (an[k].Equals("") == false)
                {
                    if(anStr.Equals(""))
                    {
                        //CommUtil.dicAN.TryGetValue(an[k], out anStr);
                        //CommUtil.dicTR.TryGetValue(k.ToString(), out trStr);
                    } 
                    else
                    {
                        string tempStr = "";
                        //CommUtil.dicAN.TryGetValue(an[k], out tempStr);
                        anStr += "," + tempStr;
                        //CommUtil.dicTR.TryGetValue(k.ToString(), out tempStr);
                        trStr += "," + tempStr;
                    }
                }
                if (freq[k].Equals("") == false)
                    if(freqStr.Equals(""))
                        freqStr = freq[k];
                    else
                        freqStr += "," + freq[k];
            }
            this.trStr = trStr;
            this.anStr = anStr;
            this.freqStr = freqStr;
        }
    }
}
