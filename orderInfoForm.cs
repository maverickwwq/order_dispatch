﻿using DispatchServer;
using DispatchServer.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zk
{
    public partial class orderInfoForm : Form
    {
        public OrderInfo tmp;
        public int OrderIndex = -1;
        //private OrderInfo orderDisplay;
        public orderInfoForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void orderInfoForm_Load(object sender, EventArgs e)
        {

        }

        public orderInfoForm(int index)
        {
            InitializeComponent();
            OrderIndex = index;
            this.StartPosition = FormStartPosition.CenterScreen;
            //调度令表格显示格式
            orderInfo_dgv.ReadOnly = true;
            orderInfo_dgv.AllowUserToAddRows = false;
            orderInfo_dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            orderInfo_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            orderInfo_dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            orderInfo_dgv.RowHeadersVisible = false;
            orderInfo_dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            orderInfo_dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            orderInfo_dgv.ColumnHeadersDefaultCellStyle.Font = new Font(orderInfo_dgv.Font, FontStyle.Bold);
            orderInfo_dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //           orderInfo_dgv.GridColor = Color.Black;
            orderInfo_dgv.ColumnCount = 17;
            orderInfo_dgv.Columns[16].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            orderInfo_dgv.Columns[0].Name = "序号";
            orderInfo_dgv.Columns[1].Name = "机号";
            orderInfo_dgv.Columns[2].Name = "功率";
            orderInfo_dgv.Columns[3].Name = "播音时间";
            orderInfo_dgv.Columns[4].Name = "频率";
            orderInfo_dgv.Columns[5].Name = "节目";
            orderInfo_dgv.Columns[6].Name = "通道";
            orderInfo_dgv.Columns[7].Name = "天线";
            orderInfo_dgv.Columns[8].Name = "程式";
            orderInfo_dgv.Columns[9].Name = "方向";
            orderInfo_dgv.Columns[10].Name = "服务区";
            orderInfo_dgv.Columns[11].Name = "操作";
            orderInfo_dgv.Columns[12].Name = "周期";
            orderInfo_dgv.Columns[13].Name = "开始日期";
            orderInfo_dgv.Columns[14].Name = "结束日期";
            orderInfo_dgv.Columns[15].Name = "业务";
            orderInfo_dgv.Columns[16].Name = "备注";

            OrderInfo tmpOI = new OrderInfo();
            tmpOI = GlobalVarForApp.tbh_ordersInfoList[index];
            label1.Text = tmpOI.orderCode;
            for (int j = 0; j < tmpOI.orderOpNum; j++)
            {
                orderInfo_dgv.Rows.Add(1);
                orderInfo_dgv.Rows[j].Cells[0].Value = tmpOI.ooc[j].orderNum;
                orderInfo_dgv.Rows[j].Cells[1].Value = tmpOI.ooc[j].transCode;
                orderInfo_dgv.Rows[j].Cells[2].Value = tmpOI.ooc[j].power.ToString();
                orderInfo_dgv.Rows[j].Cells[3].Value = tmpOI.ooc[j].startTime + "-" + tmpOI.ooc[j].endTime;
                orderInfo_dgv.Rows[j].Cells[4].Value = tmpOI.ooc[j].freq;
                orderInfo_dgv.Rows[j].Cells[5].Value = tmpOI.ooc[j].programName;
                orderInfo_dgv.Rows[j].Cells[6].Value = tmpOI.ooc[j].channel;
                orderInfo_dgv.Rows[j].Cells[7].Value = tmpOI.ooc[j].programName;
                orderInfo_dgv.Rows[j].Cells[8].Value = tmpOI.ooc[j].antProg;
                orderInfo_dgv.Rows[j].Cells[9].Value = tmpOI.ooc[j].azimuthM;
                orderInfo_dgv.Rows[j].Cells[10].Value = tmpOI.ooc[j].servArea;
                orderInfo_dgv.Rows[j].Cells[11].Value = tmpOI.ooc[j].operate;
                orderInfo_dgv.Rows[j].Cells[12].Value = tmpOI.ooc[j].days;
                orderInfo_dgv.Rows[j].Cells[13].Value = tmpOI.ooc[j].startDate;
                orderInfo_dgv.Rows[j].Cells[14].Value = tmpOI.ooc[j].endDate;
                orderInfo_dgv.Rows[j].Cells[15].Value = tmpOI.ooc[j].orderType;
                orderInfo_dgv.Rows[j].Cells[16].Value = tmpOI.ooc[j].orderRmks;
            }
            switch (tmpOI.oos[0].orderStatus){
                case OrderStatus.sysReceive:
                    check_btn.Text = "接收";
                    check_btn.Enabled = false;
                    break;

                case OrderStatus.unconfirmed:           //系统已接收，尚未点击接收确认
                    check_btn.Text = "接收";
                    check_btn.Enabled = true;
                    break;

                case OrderStatus.confirmed_noFeedback:
                    break;

                case OrderStatus.feedbacked:
                    break;
            }
        }

        private void check_btn_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(sender.ToString()+e.ToString());
            if (check_btn.Text == "接收")
            {
                GlobalVarForApp.tbh_ordersInfoList[OrderIndex].setOdStatus(OrderStatus.confirmed_noFeedback);

                RSData sendTmp=new RSData();              //send "RECEIVE_ORDER"
                sendTmp.CommType="CONFIRM_ORDER";
                sendTmp.CommTime=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                sendTmp.CommDept=GlobalVarForApp.client_type;
                sendTmp.order=new Order();
                sendTmp.order.orderId=GlobalVarForApp.tbh_ordersInfoList[OrderIndex].orderID;
                sendTmp.order.orderCode = GlobalVarForApp.tbh_ordersInfoList[OrderIndex].orderCode;
                sendTmp.order.orderRecordList = new List<OrderRecord>();

                for (int j = 0; j < GlobalVarForApp.tbh_ordersInfoList[OrderIndex].orderOpNum; j++)
                {
                  OrderRecord orTmp = new OrderRecord();
                  //orTmp.orderNumId = rcv_rsd.order.orderOpList[j].orderNumId;
                  sendTmp.order.orderRecordList.Add(orTmp);
                }
                network.sendData(sendTmp);


                //send confirm_order
                check_btn.Text = "反馈";
            }
            else if (check_btn.Text == "反馈")
            {
                MessageBox.Show(OrderIndex.ToString());
            }
        }
    }
}
