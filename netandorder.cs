#define _debug_
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DispatchServer;
using DispatchServer.BaseClass;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
namespace zk
{
    public class netandorder
    {
        //对接收到的RSData数据进行处理
        public static void HandleTheMessageReceive()
        {
#if _debug_
            Console.WriteLine("--------------数据处理线程开启");
#endif
            RSData rcv_rsd = new RSData();
            OrderInfo tmpOI;
            int index=-1;
            while (true)
            {
                while (GlobalVarForApp.receiveMessageQueue.Count > 0)  //队列中有消息进行处理
                {               //"LOGIN_REPLY"     "ADD_USER_REPLY"      "DELETE_USER_REPLY"
                                //"DOWN_ORDER"      "QUERY_ORDER_REPLY"     "NEW_MESSAGE"
                    lock(GlobalVarForApp.receiveMessageQueue){
                      rcv_rsd = GlobalVarForApp.receiveMessageQueue.Dequeue();    //最早接收到的rsdata数据
                    }
                    switch (rcv_rsd.CommType.Trim())
                    {
                        case "LOGIN_REPLY":
                            break;
                        case "ADD_USER_REPLY":
                            break;
                        case "DELETE_USER_REPLY":
                            break;

                        case "DOWN_ORDER":              //把GlobalVarForApp.receiveMessageQueue里的RSD数据整理成tbh_ordersInfoList里的List<OrderInfo>数据
                            tmpOI = new OrderInfo(rcv_rsd.order);   //临时工tmpOI
                            //这里没有做 调度令重复 的检测
                            //默认是新下发的调度令
                            tmpOI.setRecTime();
                            tmpOI.setOdStatus(OrderStatus.sysReceive);
                            index=-1;
                            index=GlobalVarForApp.tbh_ordersInfoList.FindIndex(tmpOI.matchOrderID);
                            if(index==-1){  //tbh里没找到相同orderID的
                                lock(GlobalVarForApp.tbh_ordersInfoList){
                                    GlobalVarForApp.tbh_ordersInfoList.Add(tmpOI);    //将信息加入到tbh_ordersInfoList里
                                    GlobalVarForApp.tbh_ordersInfoList.Sort();        //对tbh按orderID升序进行排序
                                }
                                RSData sendTmp = new RSData();
                                sendTmp.fill_receive_order(tmpOI);
                                //int cycle = 0;
                                //while (cycle < 100000) { cycle++; }
                                network.sendData(sendTmp);
                            }
                            else{
                                //下发了相同的调度令啦 出错了
                                //界面提示待完成
                                Console.WriteLine("下发了相同的调度令啦 出错了");
                            }
                            break;

                        case "RECEIVE_ORDER_REPLY":              //
                            Console.WriteLine("receive order reply");
                            tmpOI = new OrderInfo(rcv_rsd.order);   //临时工tmpOI
                            index=-1;
                            lock(GlobalVarForApp.tbh_ordersInfoList){
                              index=GlobalVarForApp.tbh_ordersInfoList.FindIndex(tmpOI.matchOrderID);
                              if(index != -1){
                                    Console.WriteLine("find order");
                                    GlobalVarForApp.tbh_ordersInfoList[index].setOdStatus(OrderStatus.unconfirmed);
                              }
                              else{     //收到receive order reply,却没有找到该调度令,那就是出错了
                                  Console.WriteLine("收到receive order reply，内存里找不到该调度令的相关信息");
                              }
                            }
                            break;

                        case "CONFIRM_ORDER_REPLY":
                            Console.WriteLine("confirm order reply");
                            tmpOI = new OrderInfo(rcv_rsd.order);   //临时工tmpOI
                            index = -1;
                            lock (GlobalVarForApp.tbh_ordersInfoList)
                            {
                                index = GlobalVarForApp.tbh_ordersInfoList.FindIndex(tmpOI.matchOrderID);
                                if (index != -1)
                                {
                                    Console.WriteLine("find order");
                                    GlobalVarForApp.tbh_ordersInfoList[index].setOdStatus(OrderStatus.confirmed_noFeedback);
                                    //GlobalVarForApp.tbh_ordersInfoList[index].setConfTime();
                                }
                                else{
                                    Console.WriteLine("收到confirm order reply，内存里找不到该调度令的相关信息");
                                }
                            }
                            break;

                        case "FEEDBACK_ORDER_REPLY":    //这里假设feedback order reply 返回所有orderOP的反馈
                            Console.WriteLine("feedback order reply");
                            tmpOI=new OrderInfo(rcv_rsd.order);
                            index=-1;
                            lock(GlobalVarForApp.tbh_ordersInfoList){
                              index = GlobalVarForApp.tbh_ordersInfoList.FindIndex(tmpOI.matchOrderID);
                              if(index != -1){
                                  GlobalVarForApp.tbh_ordersInfoList[index].setOdStatus(OrderStatus.feedbacked);
                                  //GlobalVarForApp.tbh_ordersInfoList[index].setFbTime();
                              }
                              else{
                                  Console.WriteLine("收到feedback order reply，但内存里找不到相关信息");
                              }
                            }
                            break;
                        case "QUERY_ORDERS_REPLY":      //批量查询
                            break;

                        case "QUERY_ORDER_REPLY":         //单个查询
                            //调度令信息
                            break;
                        case "NEW_MESSAGE":
                            break;

                        default: /* 可选的 */
                            break;

                    }
                }
                try{
                    //GlobalVarForApp.f.UIrefresh(null, null);
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadInterruptedException){}
            }
        }

        public static void query_orders_request_send(Query query)       //接收query参数，发送调度令批量查询
        {
            RSData tmp = new RSData();
            tmp.CommType = "QUERY_ORDERS_REQUEST";
            tmp.CommTime = System.DateTime.Now.ToString();
            tmp.CommDept = GlobalVarForApp.client_type; //机房的代码
            tmp.currentUser = GlobalVarForApp.currentUserStr;
            tmp.query = query;
            //GlobalVarForApp.sendMessageQueue.Enqueue(tmp);
            //network.sendData();
            network.sendData(tmp);
        }

        public static void query_order_request_send(Query query)        //接收query参数，发送调度令查询
        {
            RSData tmp = new RSData();
            tmp.CommType = "QUERY_ORDER_REQUEST";
            tmp.CommTime = System.DateTime.Now.ToString();
            tmp.CommDept = GlobalVarForApp.client_type; //机房的代码
            tmp.currentUser = GlobalVarForApp.currentUserStr;
            tmp.query = query;
            //GlobalVarForApp.sendMessageQueue.Enqueue(tmp);
            //network.sendRSDataProc();
            network.sendData(tmp);
        }

        public static void askForAllUnfinishedOrder_send()           //ask for orders unfinished since 24hours ago
        {
            Query askForUnfinishedOrder = new Query();
            askForUnfinishedOrder.pageIndex = 1;            //---------------------------------------------------------------------------
            askForUnfinishedOrder.pageSize = 100;           //每页记录数
            askForUnfinishedOrder.queryOrderStatus = new string[4] { "待下发", "待接收", "待反馈", "" };
            askForUnfinishedOrder.queryStartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            long today = DateTime.Now.Ticks;
            askForUnfinishedOrder.queryEndTime = new DateTime(today - 864000000000).ToString("yyyy-MM-dd HH:mm:ss");     //24hours ago
            netandorder.query_orders_request_send(askForUnfinishedOrder);
        }
    }
}
