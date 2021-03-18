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
        public bool dialogResult;

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
            dialogResult = true;
            if (operate_suc_chk.Checked == true){
                orderInfo.oos[index].feedback = true;
                orderInfo.oos[index].broadcastTime = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
                orderInfo.oos[index].unableReason = null;
            }
            else{
                orderInfo.oos[index].feedback = false;
                orderInfo.oos[index].broadcastTime =null;
                orderInfo.oos[index].unableReason = reason_content.Text.Trim();
            }
            this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            dialogResult = false;
            this.Close();
        }

        private void operate_suc_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void operate_fail_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void operate_suc_chk_Click(object sender, EventArgs e)
        {
            operate_fail_chk.Checked = false;
            operate_suc_chk.Checked = true;
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
