using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchServer.BaseClass
{
    class TeleOrder
    {
        public int teleOrderID;//调度令ID
        public int teleOrderYear;//调度令年份
        public string teleOrderCode;//调度令文号
        public string receiveDept;//接收部门
        public string createUser;//填表人
        public string createTime;//创建时间
        public string assessorUser;//复核人
        public string assessorTime;//复核时间
        public string receiveUser;//接收人
        public string receiveAssessorUser;//接收复核人
        public string receiveTime;//接收时间
        public string orderStatus;//调度令状态
        public string teleOrderCodeDisplay;//文号显示

        public TeleOrder()
        {
              teleOrderID = -1;
              teleOrderYear = -1;
              teleOrderCode = "";
              receiveDept = "";
              createUser = "";
              createTime = "";
              assessorUser = "";
              assessorTime = "";
              receiveUser = "";
              receiveAssessorUser = "";
              receiveTime = "";
              orderStatus = "";
              teleOrderCodeDisplay = "";
        }

        public TeleOrder(
             int teleOrderID ,
             int teleOrderYear,
             string teleOrderCode ,
             string receiveDept,
             string createUser,
             string createTime,
             string assessorUser,
             string assessorTime,
             string receiveUser,
             string receiveAssessorUser,
             string receiveTime,
            string orderStatus
            )
        {
            this.teleOrderID = teleOrderID;
            this.teleOrderYear = teleOrderYear;
            this.teleOrderCode = teleOrderCode;
            this.receiveDept = receiveDept;
            this.createUser = createUser;
            this.createTime = createTime;
            this.assessorUser = assessorUser;
            this.assessorTime = assessorTime;
            this.receiveUser = receiveUser;
            this.receiveAssessorUser = receiveAssessorUser;
            this.receiveTime = receiveTime;
            this.orderStatus = orderStatus;
            this.teleOrderCodeDisplay = "2023临调字【" + teleOrderYear + "】" + teleOrderCode + "号";
        }
    }
}
