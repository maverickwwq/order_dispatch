using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DispatchServer;
using System.Timers;
using System.Threading;

namespace zk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            orderHistory_btn.Text = "历史调度令查询";
            //界面标题数组 标题宽度
            String[] title_UI = {"序号","单号","日常","机房","状态","时间"};
            int[] title_UI_width = {30,100,30,30,100,100 };
            this.FormClosing += new FormClosingEventHandler(programExit);
            tbd_OrderInfo_dgv.RowHeadersVisible = false;//不要每行的第一个序号单元       
            tbd_OrderInfo_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect ;//全行选择
            tbd_OrderInfo_dgv.BorderStyle = BorderStyle.Fixed3D;
            tbd_OrderInfo_dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;   //单元格无边框
            tbd_OrderInfo_dgv.AutoSizeColumnsMode =  DataGridViewAutoSizeColumnsMode.Fill;//延伸整个窗口
            tbd_OrderInfo_dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tbd_OrderInfo_dgv.AllowUserToAddRows = false;       //去掉最后一行空白行
            tbd_OrderInfo_dgv.AllowUserToResizeColumns = false;//固定列宽
            tbd_OrderInfo_dgv.AllowUserToResizeRows = false;        //固定行高
            tbd_OrderInfo_dgv.AllowUserToOrderColumns = false;      //列顺序不可变更
            tbd_OrderInfo_dgv.MultiSelect = false;                                  //不可多行选择
            tbd_OrderInfo_dgv.ReadOnly = true;                                      //单元格不可编辑
            tbd_OrderInfo_dgv.DefaultCellStyle.Font = new Font("宋体",12);
            tbd_OrderInfo_dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//居中
            tbd_OrderInfo_dgv.DefaultCellStyle.SelectionBackColor = Color.LightSeaGreen;//选中行背景色
            tbd_OrderInfo_dgv.DefaultCellStyle.BackColor = Color.LightYellow;                             //单元格默认背景色
            tbd_OrderInfo_dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;   //水平分割线
            tbd_OrderInfo_dgv.BackgroundColor = Color.White;                //datagridview背景色
            tbd_OrderInfo_dgv.ColumnCount = title_UI.Length;    //共6列

            //tbd_OrderInfo_dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //tbd_OrderInfo_dgv.Columns[0].Resizable = DataGridViewTriState.False;
            //tbd_OrderInfo_dgv.Columns[0].Width = 40;

            for (int i = 0; i < title_UI.Length ; i++ )
            {
                tbd_OrderInfo_dgv.Columns[i].FillWeight = title_UI_width[i];
                tbd_OrderInfo_dgv.Columns[i].Name = title_UI[i];
                tbd_OrderInfo_dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            tbd_OrderInfo_dgv.ColumnHeadersHeight = 30;  //设定标题行行高
            tbd_OrderInfo_dgv.ClearSelection();                     //初始无选择行

            tbd_OrderInfo_dgv.Show();
            //tbd_OrderInfo_display();
        }


        public delegate void UI_refresh_delegate();
        public void UIrefresh(Object source, ElapsedEventArgs e)             //其他的线程可以调用该方法用来改变界面的数值，
        {                                                                                                         //同时不会产生错误
          tbd_OrderInfo_dgv.BeginInvoke(new UI_refresh_delegate(tbd_OrderInfo_display)); 
          
        }

        //------------------------------------------------------------------------------------------------
        //----------------------界面数值更新函数，其他线程不能直接调用----------------
        //------------------------------------------------------------------------------------------------
        public void tbd_OrderInfo_display()
        {
            if (GlobalVarForApp.tbh_ordersInfoList.Count == 0)         //无待处理调度令返回
                return;
            else   //有待处理调度令
            {            
                tbd_OrderInfo_dgv.Rows.Clear();     //先清空
                int ordersCount = 0;                          //
                foreach (OrderInfo tmpOrInfo in GlobalVarForApp.tbh_ordersInfoList)
                {
                    tbd_OrderInfo_dgv.Rows.Add(1);      //增加一行显示
                    tbd_OrderInfo_dgv.Rows[ordersCount].Height = 60;    //行高60
                    tbd_OrderInfo_dgv.Rows[ordersCount].Cells[0].Value = (ordersCount+1).ToString();        //第一列 序号 按调度令增序排列
                    tbd_OrderInfo_dgv.Rows[ordersCount].Cells[1].Value = tmpOrInfo.orderInfo.ORDER_YEAR+" "+ tmpOrInfo.orderInfo.ORDER_CODE;//第二列调度令号
/*
                    tmp = "";
                    switch (tmpOrInfo.orderInstructionList[0].TR_ID)
                    {
                            case 1:
                                tmp = "A01";
                                break;
                            case 2:
                                tmp = "A02";
                                break;
                            case 3:
                                tmp = "A03";
                                break;
                            case 4:
                                tmp = "A04";
                                break;
                            case 5:
                                tmp = "A05";
                                break;
                            case 6:
                                tmp = "A06";
                                break;
                            case 7:
                                tmp = "B01";
                                break;
                    }
                    if (tmpOrInfo.orderInstructionList.Count() > 1)
                    {
                        tmp += "+";     
                    }
                    tbd_OrderInfo_dgv.Rows[ordersCount].Cells[2].Value = tmp;     */
/*
                    tbd_OrderInfo_dgv.Rows[ordersCount].Cells[3].Style.Font = new Font("宋体", 12, FontStyle.Bold);       //调度令状态
                    tbd_OrderInfo_dgv.Rows[ordersCount].Cells[3].Style.ForeColor = Color.Red;
                    tbd_OrderInfo_dgv.Rows[ordersCount].Cells[3].Style.SelectionForeColor = Color.Red;
                    switch(tmpOrInfo.orderStatus)
                    {
                        case OrderStatus.unconfirmed:
                            tbd_OrderInfo_dgv.Rows[ordersCount].Cells[3].Value = "未确认接收";
                            tbd_OrderInfo_dgv.Rows[ordersCount].Cells[4].Value = "--";
                            break;
                        case OrderStatus.confirmed_noFeedback:
                            tbd_OrderInfo_dgv.Rows[ordersCount].Cells[3].Style.ForeColor = Color.Blue;
                            tbd_OrderInfo_dgv.Rows[ordersCount].Cells[3].Style.SelectionForeColor = Color.Blue;
                            tbd_OrderInfo_dgv.Rows[ordersCount].Cells[3].Value = "已接收未反馈";
                            tbd_OrderInfo_dgv.Rows[ordersCount].Cells[4].Value = "--";
                            break;
                        case OrderStatus.feedback:
                            tbd_OrderInfo_dgv.Rows[ordersCount].Cells[3].Style.ForeColor = Color.Green;
                            tbd_OrderInfo_dgv.Rows[ordersCount].Cells[3].Style.SelectionForeColor = Color.Green;
                            tbd_OrderInfo_dgv.Rows[ordersCount].Cells[4].Value = "已反馈";
             
                        
                                      if(){//开启则显示时间                                      //         未完成！！！！！！！！！！！！！！！！！！！！！
                                tbd_OrderInfo_dgv.Rows[ordersCount].Cells[4].Value = "--";
                            }
                            else{//无法开启则显示原因
                                tbd_OrderInfo_dgv.Rows[ordersCount].Cells[4].Value = "--";
                            }

                            break;
                    }*/

                    //tbd_OrderInfo_dgv.Rows[ordersCount].Cells[5].Value = tmpOrInfo.orderInstruction.AN_ID;                       //天线
                    //tbd_OrderInfo_dgv.Rows[ordersCount].Cells[2].Value = "待完成";
                    //tbd_OrderInfo_dgv.Rows[ordersCount].Cells[3].Value = tmpOrInfo.infoReturn;
                    //tbd_OrderInfo_dgv.Rows[ordersCount].Cells[4].Value = tmpOrInfo.commTime;
                    ordersCount++;
                }
            }
            return;
        }


        private void tbd_OrderInfo_dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("RowEnter");
        }

        //
        private void mouseEnterOrderInfoDGV(object sender, DataGridViewCellEventArgs e)
        {
           // tbd_OrderInfo_dgv.Rows[1].Cells[0].Value = "in";
            tbd_OrderInfo_dgv.ClearSelection();
            for (int rowCount = 0; rowCount < tbd_OrderInfo_dgv.RowCount; rowCount++)
                tbd_OrderInfo_dgv.Rows[rowCount].DefaultCellStyle.BackColor = Color.LightYellow;
            if (e.RowIndex >= 0)//鼠标进入数据栏
            {
                tbd_OrderInfo_dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                this.Cursor = System.Windows.Forms.Cursors.Hand;
            }
            else
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                //鼠标进入标题栏
            }
            //tbd_OrderInfo_dgv.Rows[0].Cells[0].Value = e.RowIndex.ToString();
        }

        private void mouseLeaveOrderInfoDGV(object sender, EventArgs e)
        {

            tbd_OrderInfo_dgv.ClearSelection();
            for (int rowCount = 0; rowCount < tbd_OrderInfo_dgv.RowCount; rowCount++)
                tbd_OrderInfo_dgv.Rows[rowCount].DefaultCellStyle.BackColor = Color.LightYellow;
           // tbd_OrderInfo_dgv.Rows[1].Cells[0].Value = "out";
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void mouseLeaveOrderInfoDGV(object sender, DataGridViewCellEventArgs e)
        {
            tbd_OrderInfo_dgv.ClearSelection();
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        //排序函数   对消息队列的调度令进行排序，按调令文号增序排列
        private static int CompareOrderByOrderID(OrderInfo a, OrderInfo b)
        {
            if (a.orderInfo.OD_ID > b.orderInfo.OD_ID)
                return 1;
            else if (a.orderInfo.OD_ID < b.orderInfo.OD_ID)
                return -1;
            else
                return 0;
        }

        public void messageHandle()
        {
            RSData tmp = new RSData();
            OrderInfo tmpOI = new OrderInfo();      //调度令信息
            while (GlobalVarForApp.receiveMessageQueue.Count > 0)  //队列中有消息进行处理
            {
                //foreach( RSData  rsdData in receiveQueue)
                //{   //
                //"LOGIN_REPLY"     "ADD_USER_REPLY"      "DELETE_USER_REPLY"
                //"DOWN_ORDER"      "QUERY_ORDER_REPLY"     "NEW_MESSAGE"
                tmp = GlobalVarForApp.receiveMessageQueue.Dequeue();

                switch (tmp.CommType.Trim())
                {
                    case "LOGIN_REPLY":
                        break;

                    case "ADD_USER_REPLY":
                        break;

                    case "DELETE_USER_REPLY":
                        break;

                    case "DOWN_ORDER_REPLY":
                        MessageBox.Show("Down order reply");
                        tmpOI.commTime=tmp.CommTime;
                        tmpOI.orderInfo = tmp.order;
                        tmpOI.infoReturn = tmp.infoReturn;
                        
                        tmpOI.orderStatus = OrderStatus.unconfirmed;        //设置调度令状态信息    未接收确认状态
                        GlobalVarForApp.tbh_ordersInfoList.Add(tmpOI);                      //添加到调度令信息
                        //对orInfo全局变量按调度令号进行排序
                        if (GlobalVarForApp.tbh_ordersInfoList.Count > 1)
                        {
                            GlobalVarForApp.tbh_ordersInfoList.Sort(CompareOrderByOrderID);
                        }
                        //od_dis.od_dis_show();            //新调度令显示                           
                        //tbd_OrderInfo_display();

                        //
                        //接收到新调度语音提示
                        //

                        break;


                    case "QUERY_ORDERS_REPLY":      //批量查询
                             //调度令信息
                        
                        break;
                    
                    case "QUERY_ORDER_REPLY":         //单个查询
                        //调度令信息

                        break;

                    case "NEW_MESSAGE":
                        break;

                    case "RECEIVE_ORDER_REPLY":
                        //提取调度令信息
                        tmpOI.commTime=tmp.CommTime;
                        tmpOI.orderInfo = tmp.order;
                        tmpOI.infoReturn = tmp.infoReturn;
                        tmpOI.orderStatus = OrderStatus.confirmed_noFeedback;        //设置调度令状态信息    未接收确认状态
                        GlobalVarForApp.tbh_ordersInfoList.Add(tmpOI);                      //添加到调度令信息
                        //tbd_OrderInfo_display();
                        break;

                    default: /* 可选的 */
                        break;

                }
                // }
            }

        }

        private void mouseClickOrder(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                MessageBox.Show("cell click"+e.RowIndex);
            }
        }

        //点击关闭按钮后，程序关闭所有线程
        private void programExit(object sender, CancelEventArgs e)
        {
            MessageBox.Show("exit");
            //network.listenSocket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
            System.Environment.Exit(0);
        }

        private void orderHistory_btn_Click(object sender, EventArgs e)
        {
            order_history_query order_query_form = new order_history_query();
            order_query_form.Show();
        }


    }
}
