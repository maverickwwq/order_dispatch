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
        public int ID;
        public int orderId;//调度令ID
        public int orderYear;//年份
        public string orderCode;//文号
        public string sourceType;//调度令性质
        public string orderStatus;//调度令状态
        public string orderStatusDate;//状态日期
        public string sender;//发送人
        public string sendDate;//发送时间
        public string sendAccessor;//发送审核人
        public string sendDept;//发送单位
        public string receiver;//台站接收人
        public string receiveDate;//台站接收时间
        public string corrector;//台站校对人
        public string correctDate;//台站校对时间
        public string orderRmks;//备注
        public string createType;//创建类型
        public string orderFormat;//任务格式
        public string flagReply;//可执行反馈
        public string replyDate;//可执行反馈时间
        public string insteadFlag;
        public int insteadId;
        public int orderNumId;
        public int num;//调度指令数
        public string orderType;//任务类型
        public string transCode;//发射机代码
        public string antennaCode;//天线代码
        public string startDate;//开始执行日期
        public string endDate;//结束执行日期
        public string startTime;//开始执行时间
        public string endTime;//结束执行时间
        public int freq;//频率
        public int power;//功率
        public string programCode;//节目代码
        public string programName;//节目名称
        public string azimuthM;//天线方向
        public string azimuthDe;//天线偏向
        public string operate;//操作，0-停，1-开
        public int target;//对象台
        public string servArea;//服务区
        public string days;//周期
        public string msgNum;//需求文号
        public string channel;//节目通道
        public string season;//季节
        public string mod;//调制方式
        public string opRmks;
        public string opStatus;//调度指令状态
        public string opStatusDate;//调度指令状态日期
        public string inexeReasonCode;//不可执行原因
        public string inexePerson;//机房确认人
        public string antProg;
        public string broadcastTime;
        public string innerTaskInsteadInfo;
        public string insteadStationCode;
        public string insteadTransUsedCode;
        public string updateTime;
        public int dealed;
        public string operation;

        public string orderCodeDisplay;//完整调令号
        public string operateDisplay;//操作显示
        public string trDisplay;//发射机显示
        public string anDisplay;//天线号显示
        public string orderTypeDisplay;//任务类型显示
        public string freqStr;//该调度令所有频率
        public string trStr;//该调度令所有发射机
        public string anStr;//该调度令所有天线

        public OrderOp()
        {
            ID=-1;
            orderId=-1;
            orderYear=-1;
            orderCode=null;
            sourceType = null;
            orderStatus = null;
            orderStatusDate = null;
            sender = null;
            sendDate = null;
            sendAccessor = null;
            sendDept = null;
            receiver = null;
            receiveDate = null;
            corrector = null;
            correctDate = null;
            orderRmks = null;
            createType = null;
            orderFormat = null;
            flagReply = null;
            replyDate = null;
            insteadFlag=null;
            insteadId=-1;
            orderNumId=-1;
            num=-1;
            orderType = null;
            transCode = null;
            antennaCode = null;
            startDate = null;
            endDate = null;
            startTime = null;
            endTime = null;
            freq=-1;
            power=-1;
            programCode = null;
            programName = null;
            azimuthM = null;
            azimuthDe = null;
            operate = null;
            target=-1;
            servArea = null;
            days = null;
            msgNum = null;
            channel = null;
            season = null;
            mod = null;
            opRmks = null;
            opStatus = null;
            opStatusDate = null;
            inexeReasonCode = null;
            inexePerson = null;
            antProg = null;
            broadcastTime = null;
            innerTaskInsteadInfo = null;
            insteadStationCode = null;
            insteadTransUsedCode = null;
            updateTime = null;
            dealed=-1;
            operation = null;

            orderCodeDisplay = null;
            operateDisplay = null;
            trDisplay = null;
            anDisplay = null;
            orderTypeDisplay = null;
            freqStr = null;
            trStr = null;
            anStr = null;
        }

        public OrderOp(
             int ID,
             int orderId,
             int orderYear,
             string orderCode,
             string sourceType,
             string orderStatus,
             string orderStatusDate,
             string sender,
             string sendDate,
             string sendAccessor,
             string sendDept,
             string receiver,
             string receiveDate,
             string corrector,
             string correctDate,
             string orderRmks,
             string createType,
             string orderFormat,
             string flagReply,
             string replyDate,
             string insteadFlag,
             int insteadId,
             int orderNumId,
             int num,
             string orderType,
             string transCode,
             string antennaCode,
             string startDate,
             string endDate,
             string startTime,
             string endTime,
             int freq,
             int power,
             string programCode,
             string programName,
             string azimuthM,
             string azimuthDe,
             string operate,
             int target,
             string servArea,
             string days,
             string msgNum,
             string channel,
             string season,
             string mod,
             string opRmks,
             string opStatus,
             string opStatusDate,
             string inexeReasonCode,
             string inexePerson,
             string antProg,
             string broadcastTime,
             string innerTaskInsteadInfo,
             string insteadStationCode,
             string insteadTransUsedCode,
             string updateTime,
             int dealed,
             string operation
            )
        {
            this.ID=ID;
            this.orderId = orderId;
            this.orderYear=orderYear;
            this.orderCode="广无调单字【"+orderYear+"】"+orderCode+"号";
            CommUtil.dicSourceType.TryGetValue(sourceType,out this.sourceType);
            this.orderStatus=orderStatus;
            this.orderStatusDate = orderStatusDate;
            this.sender=sender;
            this.sendDate=sendDate;
            this.sendAccessor=sendAccessor;
            this.sendDept=sendDept;
            this.receiver=receiver;
            this.receiveDate=receiveDate;
            this.corrector=corrector;
            this.correctDate=correctDate;
            this.orderRmks=orderRmks;
            this.createType=createType;
            this.orderFormat=orderFormat;
            this.flagReply=flagReply;
            this.replyDate=replyDate;
            this.insteadFlag=insteadFlag;
            this.insteadId=insteadId;
            this.orderNumId=orderNumId;
            this.num=num;
            CommUtil.dicOrderType.TryGetValue(orderType,out this.orderType);
            CommUtil.dicCtoT.TryGetValue(transCode,out this.transCode);
            CommUtil.dicCtoA.TryGetValue(antennaCode,out this.antennaCode);
            this.startDate=startDate;
            this.endDate=endDate;
            this.startTime=startTime;
            this.endTime=endTime;
            this.freq=freq;
            this.power=power;
            this.programCode=programCode;
            this.programName=programName;
            this.azimuthM=azimuthM;
            this.azimuthDe=azimuthDe;
            if (operate.Equals("0"))
                this.operate = "停";
            else if (operate.Equals("1"))
                this.operate = "开";
            this.target=target;
            this.servArea=servArea;
            this.days=days;
            this.msgNum=msgNum;
            this.channel=channel;
            this.season=season;
            this.mod=mod;
            this.opRmks=opRmks;
            this.opStatus=opStatus;
            this.opStatusDate=opStatusDate;
            this.inexeReasonCode=inexeReasonCode;
            this.inexePerson=inexePerson;
            this.antProg=antProg;
            this.broadcastTime=broadcastTime;
            this.innerTaskInsteadInfo=innerTaskInsteadInfo;
            this.insteadStationCode=insteadStationCode;
            this.insteadTransUsedCode=insteadTransUsedCode;
            this.updateTime=updateTime;
            this.dealed=dealed;
            this.operation=operation;
        }
    }
}
