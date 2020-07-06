﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DispatchServer;


//调度令信息类
//orderInfo存放不包括调度令的信息
//orderInstructionList 存放调度指令的信息
//orderRecord存放每个调度指令对应的信息
//orderStatus存放调度指令的发送接收状态
namespace zk
{
    public class OrderInfo      
    {
            public Order orderInfo = new Order();
            public List<OrderOp> orderInstructionList = new List<OrderOp>();
            public List<OrderRecord> orderRecordList = new List<OrderRecord>();
            public OrderStatus orderStatus ;
            public string  infoReturn ;
            public string commTime;
            public OrderInfo()
            {
            }
    }
    public enum OrderStatus
    {
        down_error,              //未下发
        unconfirmed,             //未接收
        unconfirmed_timeout,//未接收超时
        confirmed_noFeedback,//未反馈
        confirmed_noFeedback_timeout,//未反馈超时
        feedback             //已反馈
    }   
}