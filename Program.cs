#define   _debug_

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DispatchServer;
using System.Threading;
using System.Configuration;
using DispatchServer.BaseClass;


//这个项目是中控机房的客户端

namespace zk
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        ///
        //

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 f = new Form1();
            GlobalVarForApp.f = f;
            if (program_initial() == false)
            {
                MessageBox.Show("系统初始化失败，无法启动");
                return;
            }
            System.Timers.Timer UI_refresh_timer = new System.Timers.Timer(1000);
            //Hook up the Elapsed event for the timer.
            //界面刷新定时器
            UI_refresh_timer.Elapsed += f.UIrefresh;
            UI_refresh_timer.AutoReset = true;
            UI_refresh_timer.Enabled = true;
#if _debug_
            Console.WriteLine("--------------界面刷新线程开启");
#endif

#if _debug_

#endif


            Application.Run(f);


        }

        private static bool program_initial()       //系统初始化   成功返回true 失败false
        {
            //  读配置文件
            var setting = ConfigurationManager.AppSettings;
            if (setting["server_IP"] != null && setting["server_Port"] != null && setting["client_type"] != null)
            {
                GlobalVarForApp.client_type = setting["client_type"];           //客户端类型
                GlobalVarForApp.server_ip = setting["server_IP"];               //服务器ip
                GlobalVarForApp.server_port = Convert.ToInt32(setting["server_Port"]);//服务器端口号
            }
            else
            {
                MessageBox.Show("配置文件读取失败,程序无法启动");
                appLog.exceptionRecord("配置文件读取失败,程序无法启动");
                return false;
            }
            //初始化全局变量
            GlobalVarForApp.GlobalVarForAppInitial();
            GlobalVarForApp.receiveMessageQueue.Clear();    //消息接收队列
            GlobalVarForApp.sendMessageQueue.Clear();       //消息发送队列
            GlobalVarForApp.tbh_ordersInfoList.Clear();     //存放未处理完成的所有调度令的信息

            //网络连接正常？
            if (network.networkInitialize() == true)        //网络正常，正常则启动发送、接收线程
            {
                //do something
#if _debug_
                Console.WriteLine("网络正常");
#endif
            }
            else
            {
                GlobalVarForApp.networkStatusBool = false;
                MessageBox.Show("网络连接失败，无法连接服务器，请确认网络配置正常");
                appLog.exceptionRecord("配置文件读取失败,程序无法启动");
                return false;
            }

            //初始化声音提示模块
            voiceReminder.speakerIni();

            //开启数据处理线程，处理网络接收的数据包
            GlobalVarForApp.messageHandle_thread = new Thread(netandorder.HandleTheMessageReceive);
            GlobalVarForApp.messageHandle_thread.Start();
#if _debug_
            Console.WriteLine("------------------声音报警线程开启");
#endif
        return true;
        }

    }
}







/*
//请求获取未处理订单
//机房端未接收的，下发机房失败或者尚未下发，机房未反馈的三种状态
netandorder.askForAllUnfinishedOrder_send();// waiting for server ,receive the "QUERY_ORDERS_REPLY"

//  ---------------------------丢弃QUERY_ORDERS_REPLY之前的所有数据包------------------------
RSData rsd_tmp = new RSData();//get one QUERY_ORDERS_REPLY
while(true){
    if(GlobalVarForApp.receiveMessageQueue.Count()>0){
        rsd_tmp = GlobalVarForApp.receiveMessageQueue.Dequeue();     //丢弃所有包
        if (rsd_tmp.CommType == "QUERY_ORDERS_REPLY")                     //直到QUERY_ORDERS_REPLY
            break;
    }
    Thread.Sleep(1000);//wait for the data to be sent and receive
}
if (rsd_tmp.query.totalRecords != 0)    //存在未完成状态的调度令       数据存在GLOBALVARFORAPP.tbh_orsersInfoList
{
    int i = 0;
    foreach(OrderAndOp tmpOao in rsd_tmp.orderAndOpList)
    {
        GlobalVarForApp.tbh_ordersInfoList[i].orderInfo.OD_ID = int.Parse(tmpOao.odId);     //获取未完成调度令的 od id
        GlobalVarForApp.tbh_ordersInfoList[i].orderInfo.ORDER_YEAR = int.Parse(tmpOao.orderYear);//获取文号
        GlobalVarForApp.tbh_ordersInfoList[i].orderInfo.ORDER_CODE = tmpOao.orderCode;              //获取文号
        i++;
    }
    for (i = 0; i < GlobalVarForApp.tbh_ordersInfoList.Count(); i++)     //发送query_order_request，
    {                                                                                                          //请求获取所有未完成调度令的详细信息
        Query query=new Query();
        query.queryOrderODID=GlobalVarForApp.tbh_ordersInfoList[i].orderInfo.OD_ID.ToString();
        netandorder.query_order_request_send(query);
    }
    // i代表未完成调度令的数量
    while (i == 0)
    {
        if (GlobalVarForApp.receiveMessageQueue.Count() > 0)
        {
            rsd_tmp = GlobalVarForApp.receiveMessageQueue.Dequeue();
            if (rsd_tmp.CommType == "QUERY_ORDER_REPLY")
            {
                i--;
                for (int j = 0; j < GlobalVarForApp.tbh_ordersInfoList.Count(); j++)
                {
                    if (GlobalVarForApp.tbh_ordersInfoList[j].orderInfo.OD_ID == rsd_tmp.order.OD_ID)
                    {
                        GlobalVarForApp.tbh_ordersInfoList[j].orderInfo = rsd_tmp.order;
                        GlobalVarForApp.tbh_ordersInfoList[j].orderInstructionList = rsd_tmp.orderOpList;
                    }
                }
            }
        }
        Thread.Sleep(1000);
    }
}
Console.WriteLine("主线程在这里结束");
Thread.Sleep(Timeout.Infinite);
 */
