namespace zk
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbd_OrderInfo_dgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tbd_OrderInfo_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // tbd_OrderInfo_dgv
            // 
            this.tbd_OrderInfo_dgv.Location = new System.Drawing.Point(0, 37);
            this.tbd_OrderInfo_dgv.Name = "tbd_OrderInfo_dgv";
            this.tbd_OrderInfo_dgv.RowTemplate.Height = 23;
            this.tbd_OrderInfo_dgv.Size = new System.Drawing.Size(639, 543);
            this.tbd_OrderInfo_dgv.TabIndex = 0;
            this.tbd_OrderInfo_dgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.mouseClickOrder);
            this.tbd_OrderInfo_dgv.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.mouseEnterOrderInfoDGV);
            this.tbd_OrderInfo_dgv.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.mouseLeaveOrderInfoDGV);
            this.tbd_OrderInfo_dgv.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbd_OrderInfo_dgv_RowEnter);
            this.tbd_OrderInfo_dgv.MouseLeave += new System.EventHandler(this.mouseLeaveOrderInfoDGV);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 580);
            this.Controls.Add(this.tbd_OrderInfo_dgv);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbd_OrderInfo_dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tbd_OrderInfo_dgv;

    }
}

