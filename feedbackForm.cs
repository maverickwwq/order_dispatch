using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DispatchServer;
using DispatchServer.BaseClass;

namespace zk
{
    public partial class feedbackForm : Form
    {
        public OrderInfo orderInfo;
        public int index;

        public feedbackForm(OrderInfo a,int b)
        {
            InitializeComponent();
            orderInfo = new OrderInfo(a);
            index = b;
            operate_suc_chk.Checked = true;
            operate_fail_chk.Checked = false;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }



        private void confirm_btn_Click(object sender, EventArgs e)
        {
            RSData rsdTmp = new RSData();
            rsdTmp.CommType = "FEEDBACK_ORDER";
            rsdTmp.CommTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            rsdTmp.CommDept = GlobalVarForApp.client_type;
            Order orTmp = new Order();
            orTmp.orderCode = orderInfo.orderCode;
            orTmp.orderId = orderInfo.orderID;
            orTmp.orderRecordList=new List<OrderRecord>();
            for(int j=0;j<orderInfo.orderOpCount;j++){
                OrderRecord b=new OrderRecord();
                b.orderId=orderInfo.orderID;
                b.orderNumId=orderInfo.ooc[j].orderOpID;
                if(operate_suc_chk.Checked==true){
                    orderInfo.oos[j].feedback = true;
                    b.broadcastTime=dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    b.inexeReason=null;
                }
                else{
                    orderInfo.oos[j].feedback = false;
                    b.broadcastTime=null;
                    b.inexeReason=reason_content.Text;
                }
                orTmp.orderRecordList.Add(b);
            }
            rsdTmp.order=orTmp;
            network.sendData(rsdTmp);
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void operate_suc_CheckedChanged(object sender, EventArgs e)
        {
            //operate_fail_chk.Checked = false;
            //operate_suc_chk.Checked = true;
            //orderInfo.oos[index].feedback = true;
            //orderInfo.oos[index].feedbackTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void operate_fail_CheckedChanged(object sender, EventArgs e)
        {
            //operate_suc_chk.Checked = false;
            //operate_fail_chk.Checked = true;
        }

        private void operate_suc_chk_Click(object sender, EventArgs e)
        {
            operate_fail_chk.Checked = false;
            operate_suc_chk.Checked = true;
            //orderInfo.oos[index].feedback = true;
            //orderInfo.oos[index].feedbackTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void operate_fail_Click(object sender, EventArgs e)
        {
            operate_suc_chk.Checked = false;
            operate_fail_chk.Checked = true;
        }

        private void feedbackForm_Load(object sender, EventArgs e)
        {

        }
    }
}
