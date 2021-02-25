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
    public class OrderInfo
    {
        public int orderID;                                           //调度令在数据库的id
        public string orderCode;                                      //文号
        public int orderOpNum;                                        //调度指令数量
        public Order_Op_Content[] ooc=new Order_Op_Content[100];      //调度指令的数量大概也不会超过100个啦,调度令的内容，只读
        public Order_Op_Status[] oos=new Order_Op_Status[100];        //调度指令的状态值

        public OrderInfo()
        {
        }

       public OrderInfo(Order a)      //构造函数，给orderInfo赋值
       {
          this.orderID=a.orderId;               //你好，id给我
          this.orderCode=a.orderCode;           //你好，文号给我
          OrderOp[] oops=new OrderOp[100];                      //
          oops=a.orderOpList.ToArray();                         //能超过100个指令吗
          int i=0;                              //记录调度指令数量
          foreach(OrderOp oop in oops)                          //初始化ooc及oos内容
          {
              this.oos[i]=new Order_Op_Status();
              this.ooc[i]=new Order_Op_Content();
              this.ooc[i].orderCode=a.orderCode;              //文号
              this.ooc[i].orderNum=oop.num;                   //序号
              this.oos[i].orderCode=oop.orderCode;            //文号
              this.oos[i].orderNum=oop.num;                   //序号
              this.ooc[i].power = oop.power;
              this.ooc[i].transCode=oop.transCode;            //发射机号
              this.ooc[i].startTime=oop.startTime;      //开始时间
              this.ooc[i].endTime=oop.endTime;          //结束时间
              this.ooc[i].freq=oop.freq;                //频率
              this.ooc[i].programName=oop.programName;  //节目名称
              this.ooc[i].channel=oop.channel;          //通道
              this.ooc[i].antCode=oop.antennaCode;     //天线代码
              this.ooc[i].antProg=oop.antProg;     //天线程式
              this.ooc[i].azimuthM=oop.azimuthM;    //天线角度
              this.ooc[i].servArea=oop.servArea;    //服务区 代码表示 暂时不知道代码所表示的意思
              this.ooc[i].operate=oop.operate;     //操作  “开” “关”
              this.ooc[i].days=oop.days;        //周期
              this.ooc[i].startDate=oop.startDate;   //开始日期
              this.ooc[i].endDate=oop.endDate;     //结束日期
              this.ooc[i].orderType=oop.orderType;   //业务
              this.ooc[i].orderRmks=oop.orderRmks;   //备注
              this.ooc[i].sender=oop.sender;      //下发人
              this.ooc[i].sendDateTime=oop.sendDate;//下发日期时间
              i++;
          }
          this.orderOpNum = i;
        }
            public void setOOS()
            {

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

        public Order_Op_Content(){}
      }

    public class Order_Op_Status                //调度指令在系统中的状态及反馈信息
    {
        public string orderCode;                   //调单号
        public int orderNum;                    //调单序号
        public OrderStatus orderStatus;        //orderOp当前在系统中的状态
        public User receiver;                          //接收人
        public string clientReceiveTime;        //客户端接收时间
        public string confirm_time;            //接收人点击确认接收的时间
        public string feedback_user;           //反馈人
        public string feedbackTime;           //反馈时间
        public bool feedback;                 //反馈是否可开
        public string unableReason;           //不可开原因
    }

    public enum OrderStatus
    {
        down_error,                      //未下发
        unconfirmed,                    //未接收
        unconfirmed_timeout,        //未接收超时
        confirmed_noFeedback,   //未反馈
        confirmed_noFeedback_timeout,//未反馈超时
        feedback                            //已反馈
    }
}
