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
        public static readonly string COMM_TYPE_DOWN_ORDER_REQUEST = "DOWN_ORDER_REQUEST";//中控下发调令请求
        public static readonly string COMM_TYPE_DOWN_ORDER_REPLY = "DOWN_ORDER_REPLY";//中控下发调令结果
        public static readonly string COMM_TYPE_DOWN_TELE_ORDER_REQUEST = "DOWN_TELE_ORDER_REQUEST";//下发电话调令请求
        public static readonly string COMM_TYPE_DOWN_TELE_ORDER = "DOWN_TELE_ORDER";//下发电话调令
        public static readonly string COMM_TYPE_RECEIVE_ORDER = "RECEIVE_ORDER";//接收调令
        public static readonly string COMM_TYPE_RECEIVE_ORDER_REPLY = "RECEIVE_ORDER_REPLY";//接收调令的答复
        public static readonly string COMM_TYPE_RECEIVE_TELE_ORDER = "RECEIVE_TELE_ORDER";//接收电话调令
        public static readonly string COMM_TYPE_FEEDBACK_ORDER = "FEEDBACK_ORDER";//反馈调令
        public static readonly string COMM_TYPE_FEEDBACK_ORDER_REPLY = "FEEDBACK_ORDER_REPLY";//反馈调令的答复
        public static readonly string COMM_TYPE_FEEDBACK_TELE_ORDER = "FEEDBACK_TELE_ORDER";//反馈电话调令
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
        public static readonly string COMM_TYPE_NEW_MESSAGE = "NEW_MESSAGE";//新消息提醒

        //机房代码定义
        public static readonly string DEPT_JIA = "7830";//甲机房的机房代码
        public static readonly string DEPT_YI = "7831";//乙机房的机房代码
        public static readonly string DEPT_CENTER = "7852";//中控机房的机房代码

        //调令状态
        public static readonly string ORDER_STATUS_WAIT_DOWN = "待下发";
        public static readonly string ORDER_STATUS_WAIT_RECEIVE = "待接收";
        public static readonly string ORDER_STATUS_WAIT_FEEDBACK = "待反馈";
        public static readonly string ORDER_STATUS_ALREADY_FEEDBACK = "已反馈";

        //常量对应字典
        public static Dictionary<string, string> dicDept = new Dictionary<string, string>();
        public static Dictionary<string, string> dicTR = new Dictionary<string, string>();
        public static Dictionary<string, string> dicAN = new Dictionary<string, string>();
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
            dicTR.Add("1", "A01");
            dicTR.Add("2", "A02");
            dicTR.Add("3", "A03");
            dicTR.Add("4", "A04");
            dicTR.Add("5", "A05");
            dicTR.Add("6", "A06");
            dicTR.Add("7", "B01");
            dicAN.Add("1", "101");
            dicAN.Add("2", "102");
            dicAN.Add("3", "103");
            dicAN.Add("4", "104");
            dicAN.Add("5", "105");
            dicAN.Add("6", "106");
            dicAN.Add("7", "107");
            dicTR.Add("8", "108");
            dicAN.Add("9", "109");
            dicAN.Add("10", "110");
            dicAN.Add("11", "201");
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
