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
        public static void receive_order_send(Order order)          //接收order odid参数，发送 调度令接收确认
        {
            RSData tmp = new RSData();
            tmp.CommType = "RECEIVE_ORDER";
            tmp.CommTime = System.DateTime.Now.ToString();
            tmp.CommDept = GlobalVarForApp.client_type; //机房的代码
            tmp.currentUser = GlobalVarForApp.currentUserStr;
            //GlobalVarForApp.sendMessageQueue.Enqueue(tmp);
            //network.sendRSDataProc();
            network.sendData(tmp);
        }

        public static void feedback_order_send(List<OrderRecord> orderRecordList)  //接收orderRecordList参数，发送 调度令反馈
        {
            RSData tmp = new RSData();
            tmp.CommType = "FEEDBACK_ORDER";
            tmp.CommTime = System.DateTime.Now.ToString();
            tmp.CommDept = GlobalVarForApp.client_type; //机房的代码
            tmp.currentUser = GlobalVarForApp.currentUserStr;
            tmp.orderRecordList = orderRecordList;
            //GlobalVarForApp.sendMessageQueue.Enqueue(tmp);
            //network.sendRSDataProc();
            network.sendData(tmp);
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

        //
        //-----------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        //
        //
        /*
        public static OrderInfo down_order_receive(RSData tmp, OrderInfo oitmp)         //接收DOWN_ORDER，将数据存入全局变量
        {
            oitmp.orderInfo = tmp.order;
            oitmp.orderInstructionList= tmp.orderOpList;
            oitmp.orderRecordList = tmp.orderRecordList;
            return oitmp;
        }

        public static OrderInfo down_order_reply_receive(RSData tmp,OrderInfo oitmp)    //客户端接收通知
        {
            oitmp.orderInfo = tmp.order;
            oitmp.orderStatus =OrderStatus.unconfirmed;     //
            return oitmp;
        }

        public static OrderInfo receive_order_reply_receive(RSData tmp,OrderInfo oitmp) //机房值班员确认接收通知
        {
            oitmp.orderInfo = tmp.order;
            oitmp.orderStatus = OrderStatus.confirmed_noFeedback;        //
            return oitmp;
        }

        public static OrderInfo feedback_order_reply_receive(RSData tmp,OrderInfo oitmp)
        {
            oitmp.orderInfo = tmp.order;
            oitmp.orderStatus = OrderStatus.feedback;
            oitmp.orderRecordList = tmp.orderRecordList;
            return oitmp;
        }

        public static List<OrderAndOp> query_orders_reply_receive(RSData rec)   //批量获取调度令信息
        {
            List<OrderAndOp> tmpOaoList = new List<OrderAndOp>();
            tmpOaoList = rec.orderAndOpList;
            return tmpOaoList;
        }


        public static OrderInfo query_oder_reply_receive(RSData tmp,OrderInfo oitmp)
        {
            oitmp.orderInfo = tmp.order;
            oitmp.orderInstructionList = tmp.orderOpList;
            return oitmp;
        }
        */

        //对接收到的数据进行处理
        public static void HandleTheMessageReceive()
        {
#if _debug_
            Console.WriteLine("--------------数据处理线程开启");
#endif
            RSData rcv_rsd = new RSData();
            OrderInfo tmpOI;
            //OrderInfo tmpOI = new OrderInfo();      //调度令信息
            while (true)
            {
#if _debug_
                //Console.WriteLine("触发了一次数据处理线程处理");
#endif
                while (GlobalVarForApp.receiveMessageQueue.Count > 0)  //队列中有消息进行处理
                {               //"LOGIN_REPLY"     "ADD_USER_REPLY"      "DELETE_USER_REPLY"
                                //"DOWN_ORDER"      "QUERY_ORDER_REPLY"     "NEW_MESSAGE"
                    lock(GlobalVarForApp.receiveMessageQueue){
                      rcv_rsd = GlobalVarForApp.receiveMessageQueue.Dequeue();
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
                            for(int j=0;j<tmpOI.orderOpNum;j++){
                                tmpOI.oos[j].orderStatus = OrderStatus.unconfirmed;
                                tmpOI.oos[j].clientReceiveTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            lock(GlobalVarForApp.tbh_ordersInfoList){
                              GlobalVarForApp.tbh_ordersInfoList.Add(tmpOI);    //将信息加入到tbh_ordersInfoList里
                            }
                            //GlobalVarForApp.f.UIrefresh(null,null);
                            break;

                        case "DOWN_ORDER_REPLY":
                            //MessageBox.Show("Down order reply");
                            //接收到服务器发送的接收调度令确认数据
                            //1、 确认是否与客户端存在的调度令数据一致，不一致以
                            //         这次接收的数据为准
                            //2、    客户端不存在该调度令的数据，将数据存入全局变量tbh_ordersInfoList
                            //3、  对tbh_ordersInfoList进行排序
                            tmpOI = new OrderInfo(rcv_rsd.order);
                            for(int j=0;j<tmpOI.oos.GetLength(0);j++){
                                tmpOI.oos[j].orderStatus = OrderStatus.unconfirmed;
                                tmpOI.oos[j].clientReceiveTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            /* //已经存在该调度令，用最新的数据覆盖该调度令
                           if()
                           {
                           }
                            */
                            GlobalVarForApp.tbh_ordersInfoList.Add(tmpOI);                      //添加到调度令信息
                            //对orInfo全局变量按调度令号进行排序
                            if (GlobalVarForApp.tbh_ordersInfoList.Count > 1)
                            {
                                //GlobalVarForApp.tbh_ordersInfoList.Sort(CompareOrderByOrderID);
                            }
                            //od_dis.od_dis_show();            //新调度令显示
                            // Form1.tbd_OrderInfo_display();

                            //
                            //接收到新调度语音提示
                            //

                            break;


                        case "QUERY_ORDERS_REPLY":      //批量查询
                            //调度令信息
                            List<OrderAndOp> tmpOaoList = new List<OrderAndOp>();
                            //tmpOaoList = query_orders_reply_receive(rcv_rsd);
                            if (rcv_rsd.query.pageSize == 100)      //系统初始化时查询所有未完成调度令
                            {
                                //清空全局变量     tbh_orderInfo
                                if (tmpOaoList.Count() != 0)       //非空链条
                                {
                                    int i = 0;
                                    foreach (OrderAndOp tmpOao in tmpOaoList)//获取所有未完成调度令的od_id  od_year od_code
                                    {
                                        //GlobalVarForApp.tbh_ordersInfoList[i].orderInfo.OD_ID = int.Parse(tmpOao.odId);
                                        //GlobalVarForApp.tbh_ordersInfoList[i].orderInfo.ORDER_YEAR = int.Parse(tmpOao.orderYear);
                                       //GlobalVarForApp.tbh_ordersInfoList[i].orderInfo.ORDER_CODE = tmpOao.orderCode;
                                        i++;
                                    }
                                }
                            }
                            else                              //调度令查询功能
                            {

                            }
                            break;

                        case "QUERY_ORDER_REPLY":         //单个查询
                            //调度令信息

                            break;

                        case "NEW_MESSAGE":
                            break;

                        case "RECEIVE_ORDER_REPLY":
                            //提取调度令信息
                            //tmpOI.commTime = rcv_rsd.CommTime;
                            //tmpOI.orderInfo = rcv_rsd.order;
                            //tmpOI.infoReturn = rcv_rsd.infoReturn;
                            //tmpOI.orderStatus = OrderStatus.confirmed_noFeedback;        //设置调度令状态信息    未接收确认状态
                            //GlobalVarForApp.tbh_ordersInfoList.Add(tmpOI);                      //添加到调度令信息
                            //tbd_OrderInfo_display();
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


    }
}
