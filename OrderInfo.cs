using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DispatchServer.BaseClass;
using DispatchServer.BaseUtil;
using DispatchServer;

//调度令信息类
namespace zk
{
    public class OrderInfo : IComparable
    {
        public int orderID;                                           //调度令在数据库的id
        public string orderCode;                                      //文号
        public int orderOpNum;                                        //调度指令数量
        public Order_Op_Content[] ooc=new Order_Op_Content[100];    //调度指令的数量大概也不会超过100个啦,调度令的内容，只读
        public Order_Op_Status[] oos=new Order_Op_Status[100];      //调度指令的状态值

        public OrderInfo(){
            orderID = 0;
            orderCode = null;
            orderOpNum = 0;
            ooc = new Order_Op_Content[100];
            oos = new Order_Op_Status[100];
        }

        public OrderInfo(OrderInfo b){
            orderID=b.orderID;
            orderCode=b.orderCode;
            orderOpNum=b.orderOpNum;
            if(b.ooc!=null){
              for(int j=0;j<orderOpNum;j++){
                  ooc[j] = new Order_Op_Content(b.ooc[j]);
                  oos[j] = new Order_Op_Status(b.oos[j]);
              }
            }
        }

        public int CompareTo(object other)
        {
            if (other == null)
                return 1;
            OrderInfo otherOI = other as OrderInfo;
            return this.orderID.CompareTo(otherOI.orderID);
        }


        public OrderInfo(Order a)      //构造函数，给orderInfo赋值
        {
            this.orderID = a.orderId;                                           //你好，id给我
            this.orderCode = a.orderCode;                                       //你好，文号给我
            OrderOp[] oops = new OrderOp[100];
            if(a.orderOpList!=null){                                 //
              a.orderOpList.Sort();             //对调度指令根据序号进行排序
              oops = a.orderOpList.ToArray();                                     //能超过100个指令吗
            }
            int i = 0;                                                                          //记录调度指令数量
            foreach (OrderOp oop in oops)                                     //初始化ooc及oos内容
            {
                //this.oos[i].orderCode = oop.orderCode;            //文号
                //this.oos[i].orderNum = oop.num;                   //序号
                this.ooc[i] = new Order_Op_Content(oop);          //
                this.oos[i] = new Order_Op_Status(oop);           //
                i++;
            }
            this.orderOpNum = i;
        }

        public void setOdStatus(OrderStatus odStatus)
        {
          for(int j=0;j<orderOpNum;j++)
            oos[j].orderStatus=odStatus;
        }

        public void setRecTime(){
          for(int j=0;j<orderOpNum;j++)
            oos[j].clientReceiveTime=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public void setConfTime(){
          for(int j=0;j<orderOpNum;j++)
            oos[j].confirmTime=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public void setFbTime(int index){
          oos[index].feedbackTime=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public void setFbInfo(int index,bool fb,string reason){
          oos[index].feedback=fb;
          if(fb == true)
            oos[index].unableReason=null;
          else
            oos[index].unableReason=reason;
        }

        public bool matchOrderID(OrderInfo t){
          if(this.orderID == t.orderID)
            return true;
          else
            return false;
        }
    }
        public class Order_Op_Content    //调度令内容
        {
            public string orderCode;   //调单号
            public int orderNum;    //调单序号
            public string transCode;   //发射机代码
            public int power;           //功率
            public string startTime;   //开始时间
            public string endTime;     //结束时间
            public int freq;        //频率
            public string programName; //节目名称
            public string channel;     //通道
            public string antCode;     //天线代码
            public string antProg;     //天线程式
            public string azimuthM;    //天线角度
            public string servArea;    //服务区 代码表示 暂时不知道代码所表示的意思
            public string operate;     //操作  “开” “关”
            public string days;        //周期
            public string startDate;   //开始日期
            public string endDate;     //结束日期
            public string orderType;   //业务
            public string orderRmks;   //备注
            public string sender;      //下发人
            public string sendDateTime;//下发日期时间

            public Order_Op_Content(Order_Op_Content b) {
              orderCode=b.orderCode;   //调单号
              orderNum=b.orderNum;    //调单序号
              transCode=b.transCode;   //发射机代码
              power=b.power;           //功率
              startTime=b.startTime;   //开始时间
              endTime=b.endTime;     //结束时间
              freq=b.freq;        //频率
              programName=b.programName; //节目名称
              channel=b.channel;     //通道
              antCode=b.antCode;     //天线代码
              antProg=b.antProg;     //天线程式
              azimuthM=b.azimuthM;    //天线角度
              servArea=b.servArea;    //服务区 代码表示 暂时不知道代码所表示的意思
              operate=b.operate;     //操作  “开” “关”
              days=b.days;        //周期
              startDate=b.startDate;   //开始日期
              endDate=b.endDate;     //结束日期
              orderType=b.orderType;   //业务
              orderRmks=b.orderRmks;   //备注
              sender=b.sender;      //下发人
              sendDateTime=b.sendDateTime;//下发日期时间
            }

            public Order_Op_Content(OrderOp op){
                if (op != null)
                {
                    orderCode = op.orderCode;
                    orderNum = op.num;
                    power = op.power;
                    transCode = op.transCode;            //发射机号
                    DateTime dtTmp;
                    dtTmp = DateTime.Parse(op.startTime);
                    startTime = dtTmp.TimeOfDay.ToString();        //开始时间
                    dtTmp = DateTime.Parse(op.endTime);
                    endTime = dtTmp.TimeOfDay.ToString();          //结束时间
                    freq = op.freq;                //频率
                    programName = op.programName;  //节目名称
                    channel = op.channel;          //通道
                    antCode = op.antennaCode;     //天线代码
                    antProg = op.antProg;     //天线程式
                    azimuthM = op.azimuthM;    //天线角度
                    servArea = op.servArea;    //服务区 代码表示 暂时不知道代码所表示的意思
                    operate = op.operate;     //操作  “开” “关”
                    days = op.days;        //周期
                    dtTmp = DateTime.Parse(op.startDate);
                    startDate = dtTmp.ToString("yyyy-MM-dd");   //开始日期
                    dtTmp = DateTime.Parse(op.endDate);
                    endDate = dtTmp.ToString("yyyy-MM-dd");     //结束日期
                    orderType = op.orderType;   //业务
                    orderRmks = op.orderRmks;   //备注
                    sender = op.sender;      //下发人
                    sendDateTime = op.sendDate;//下发日期时间
                }
            }
        }

        public class Order_Op_Status                //调度指令在系统中的状态及反馈信息
        {
            public string orderCode;                //调单号
            public int orderNum;                    //调单序号
            public OrderStatus orderStatus;         //orderOp当前在系统中的状态
            public User receiver;                   //接收人
            public string clientReceiveTime;        //客户端接收时间
            public string confirmTime;             //接收人点击确认接收的时间
            public string feedbackUser;            //反馈人
            public string feedbackTime;             //反馈时间
            public bool feedback;                   //反馈是否可开
            public string unableReason;             //不可开原因

            public Order_Op_Status(Order_Op_Status b){
              orderCode=b.orderCode;
              orderNum=b.orderNum;
              orderStatus=b.orderStatus;
              receiver=null;
              clientReceiveTime=b.clientReceiveTime;
              confirmTime=b.confirmTime;
              feedbackUser=b.feedbackUser;
              feedbackTime=b.feedbackTime;
              feedback=b.feedback;
              unableReason=b.unableReason;
            }
            public Order_Op_Status(OrderOp op){
                if (op != null)
                {
                    orderCode = op.orderCode;
                    orderNum = op.num;
                }
            }

        }

        public enum OrderStatus
        {
            down_error,                       //未下发
            sysReceive,                       //系统接收到，服务器尚未确认
            unconfirmed,                      //服务器确认，值班员未接收
            confirmed_noFeedback,             //值班员已接受未反馈
            feedbacked,                       //已反馈
            unconfirmed_timeout,              //未接收超时
            confirmed_noFeedback_timeout,     //未反馈超时
        }
    }
