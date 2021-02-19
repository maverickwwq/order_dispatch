using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DispatchServer.BaseUtil
{
    public class CommUtil
    {
        //通讯操作类型
        public static readonly string COMM_TYPE_SOCKET_CONNECTED = "SOCKET_CONNECTED";//网络连接确认
        public static readonly string COMM_TYPE_LOGIN_REQUEST = "LOGIN_REQUEST";//登录请求
        public static readonly string COMM_TYPE_LOGIN_REPLY = "LOGIN_REPLY";//登录回复
        public static readonly string COMM_TYPE_ADD_USER_REQUEST = "ADD_USER_REQUEST";//添加用户请求
        public static readonly string COMM_TYPE_ADD_USER_REPLY = "ADD_USER_REPLY";//添加用户回复
        public static readonly string COMM_TYPE_DELETE_USER_REQUEST = "DELETE_USER_REQUEST";//删除用户请求
        public static readonly string COMM_TYPE_DELETE_USER_REPLY = "DELETE_USER_REPLY";//删除用户回复
        public static readonly string COMM_TYPE_UPDATE_PASSWORD_REQUEST = "UPDATE_PASSWORD_REQUEST";//修改密码请求
        public static readonly string COMM_TYPE_UPDATE_PASSWORD_REPLY = "UPDATE_PASSWORD_REPLY";//修改密码回复
        public static readonly string COMM_TYPE_QUERY_USER_REQUEST = "QUERY_USER_REQUEST";//查询单个用户
        public static readonly string COMM_TYPE_QUERY_USERS_REQUEST = "QUERY_USERS_REQUEST";//批量用户查询结果
        public static readonly string COMM_TYPE_DOWN_ORDER = "DOWN_ORDER"; //服务器下发调令
        public static readonly string COMM_TYPE_RECEIVE_ORDER_REPLY = "RECEIVE_ORDER_REPLY";//接收调令的反馈
        public static readonly string COMM_TYPE_DOWN_TELE_ORDER_REQUEST = "DOWN_TELE_ORDER_REQUEST";//下发电话调令请求
        public static readonly string COMM_TYPE_DOWN_TELE_ORDER = "DOWN_TELE_ORDER";//下发电话调令
        public static readonly string COMM_TYPE_CONFIRM_ORDER = "CONFIRM_ORDER";//确认调令
        public static readonly string COMM_TYPE_CONFIRM_ORDER_REPLY = "COINFIRM_ORDER_REPLY";//确认调令的反馈
        public static readonly string COMM_TYPE_CONFIRM_TELE_ORDER = "CONFIRM_TELE_ORDER";//确认电话调令
        public static readonly string COMM_TYPE_FEEDBACK_ORDER = "FEEDBACK_ORDER";//执行回复调令
        public static readonly string COMM_TYPE_FEEDBACK_ORDER_REPLY = "FEEDBACK_ORDER_REPLY";//执行回复调令的反馈
        public static readonly string COMM_TYPE_FEEDBACK_TELE_ORDER = "FEEDBACK_TELE_ORDER";//执行回复电话调令的反馈
        public static readonly string COMM_TYPE_QUERY_ORDER_REQUEST = "QUERY_ORDER_REQUEST";//查询单个调令综合信息
        public static readonly string COMM_TYPE_QUERY_TELE_ORDER_REQUEST = "QUERY_TELE_ORDER_REQUEST";//查询单个电话调令综合信息
        public static readonly string COMM_TYPE_QUERY_ORDERS_REQUEST = "QUERY_ORDERS_REQUEST";//查询批量调令
        public static readonly string COMM_TYPE_QUERY_TELE_ORDERS_REQUEST = "QUERY_TELE_ORDERS_REQUEST";//查询批量电话调令
        public static readonly string COMM_TYPE_QUERY_ORDER_REPLY = "QUERY_ORDER_REPLY";//单个调令查询结果
        public static readonly string COMM_TYPE_QUERY_TELE_ORDER_REPLY = "QUERY_TELE_ORDER_REPLY";//单个电话调令查询结果
        public static readonly string COMM_TYPE_QUERY_ORDERS_REPLY = "QUERY_ORDERS_REPLY";//批量调令查询结果
        public static readonly string COMM_TYPE_QUERY_TELE_ORDERS_REPLY = "QUERY_TELE_ORDER_REPLY";//批量电话调令查询结果  
        public static readonly string COMM_TYPE_QUERY_OPERATELOG_REQUEST = "QUERY_OPERATELOG_REQUEST";//操作日志查询
        public static readonly string COMM_TYPE_QUERY_OPERATELOG_REPLY = "QUERY_OPERATELOG_REPLY";//操作日志查询结果
        public static readonly string COMM_TYPE_QUERY_SYSTEMLOG_REQUEST = "QUERY_SYSTEMLOG_REQUEST";//系统日志查询
        public static readonly string COMM_TYPE_QUERY_SYSTEMLOG_REPLY = "QUERY_SYSTEMLOG_REPLY";//系统日志查询结果
        public static readonly string COMM_TYPE_QUERY_DEBUGLOG_REQUEST = "QUERY_DEBUGLOG_REQUEST";//调试日志查询
        public static readonly string COMM_TYPE_QUERY_DEBUGLOG_REPLY = "QUERY_DEBUGLOG_REPLY";//调试日志查询结果
        public static readonly string COMM_TYPE_QUERY_ERRORLOG_REQUEST = "QUERY_ERRORLOG_REQUEST";//错误日志查询
        public static readonly string COMM_TYPE_QUERY_ERRORLOG_REPLY = "QUERY_ERRORLOG_REPY";//错误日志查询结果
        public static readonly string COMM_TYPE_REMIND_RECEIVE_ORDER = "REMIND_RECEIVE_ORDER";//提醒接收调令
        public static readonly string COMM_TYPE_REMIND_FEEDBACK_ORDER = "REMIND_FEEDBACK_ORDER";//提醒反馈调令
        public static readonly string COMM_TYPE_NEW_MESSAGE = "NEW_MESSAGE";//新消息提醒
        public static readonly string COMM_TYPE_CONNECT_STATE = "CONNECT_STATE";//连接状态信息
        //机房代码定义
        public static readonly string DEPT_JIA = "7830";//甲机房的机房代码
        public static readonly string DEPT_YI = "7831";//乙机房的机房代码
        public static readonly string DEPT_CENTER = "7852";//中控机房的机房代码

        //调令状态
        public static readonly string ORDER_STATUS_WAIT_DOWN = "待下发";
        public static readonly string ORDER_STATUS_WAIT_RECEIVE = "待接收";
        public static readonly string ORDER_STATUS_WAIT_CONFIRM = "待确认";
        public static readonly string ORDER_STATUS_WAIT_FEEDBACK = "待反馈";
        public static readonly string ORDER_STATUS_ALREADY_FEEDBACK = "已反馈";

        //常量对应字典
        public static Dictionary<string, string> dicDept = new Dictionary<string, string>();
        public static Dictionary<string, string> dicTtoC = new Dictionary<string, string>();//发射机到代码的映射
        public static Dictionary<string, string> dicCtoT = new Dictionary<string, string>();//代码到发射机的映射
        public static Dictionary<string, string> dicCtoA = new Dictionary<string, string>();//代码到天线的映射
        public static Dictionary<string, string> dicAtoC = new Dictionary<string, string>();//天线到代码的映射
        public static Dictionary<string, string> dicSourceType = new Dictionary<string, string>();
        public static Dictionary<string, string> dicIP = new Dictionary<string, string>();
        public static Dictionary<string, string> dicOrderType = new Dictionary<string, string>();
        public static Dictionary<string, string> dicOmsOrderOpStatus = new Dictionary<string, string>();
        
        public static void Init()
        {
            //初始化操作
            dicDept.Add(CommUtil.DEPT_JIA, "甲机房");
            dicDept.Add(CommUtil.DEPT_YI, "乙机房");
            dicDept.Add(CommUtil.DEPT_CENTER, "中控机房");
            dicTtoC.Add("A01", "783001");
            dicTtoC.Add("A02", "783002");
            dicTtoC.Add("A03", "783003");
            dicTtoC.Add("A04", "783004");
            dicTtoC.Add("A05", "783005");
            dicTtoC.Add("A06", "783006");
            dicTtoC.Add("B01", "783101");

            dicCtoT.Add("783001", "A01");
            dicCtoT.Add("783002", "A02");
            dicCtoT.Add("783003", "A03");
            dicCtoT.Add("783004", "A04");
            dicCtoT.Add("783005", "A05");
            dicCtoT.Add("783006", "A06");
            dicCtoT.Add("783101", "B01");

            dicCtoA.Add("78101", "101");
            dicCtoA.Add("78102", "102");
            dicCtoA.Add("78103", "103");
            dicCtoA.Add("78104", "104");
            dicCtoA.Add("78105", "105");
            dicCtoA.Add("78106", "106");
            dicCtoA.Add("78107", "107");
            dicCtoA.Add("78108", "108");
            dicCtoA.Add("78109", "109");
            dicCtoA.Add("78110", "110");
            dicCtoA.Add("78201", "201");

            dicAtoC.Add("101", "78101");
            dicAtoC.Add("102", "78102");
            dicAtoC.Add("103", "78103");
            dicAtoC.Add("104", "78104");
            dicAtoC.Add("105", "78105");
            dicAtoC.Add("106", "78106");
            dicAtoC.Add("107", "78107");
            dicAtoC.Add("108", "78108");
            dicAtoC.Add("109", "78109");
            dicAtoC.Add("110", "78110");
            dicAtoC.Add("201", "78201");

            dicSourceType.Add("NORM","正常任务");
            dicSourceType.Add("INTR", "台际代播");
            dicSourceType.Add("INNR", "自台代播");
            dicOrderType.Add("D", "对内广播");
            dicOrderType.Add("L", "地方广播");
            dicOrderType.Add("F", "对外广播");
            dicOrderType.Add("S", "外转中");
            dicOrderType.Add("M", "中转外");
            dicOrderType.Add("I", "实验");
            dicOmsOrderOpStatus.Add("10","新建");
            dicOmsOrderOpStatus.Add("20", "已校对");
            dicOmsOrderOpStatus.Add("21", "已接收未校对");
            dicOmsOrderOpStatus.Add("30", "已校对");
            dicOmsOrderOpStatus.Add("40", "中控不可执行");
            dicOmsOrderOpStatus.Add("41", "机房不可执行");
            dicOmsOrderOpStatus.Add("50", "中控可执行");
            dicOmsOrderOpStatus.Add("60", "中控完成");
            dicOmsOrderOpStatus.Add("70", "等待下发机房");
            dicOmsOrderOpStatus.Add("80", "已下发机房");
            dicOmsOrderOpStatus.Add("81", "机房可执行");
        }
    }
}
