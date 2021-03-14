namespace zk
{
    partial class feedbackForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.operate_suc_chk = new System.Windows.Forms.CheckBox();
            this.operate_fail_chk = new System.Windows.Forms.CheckBox();
            this.confirm_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.fail_reason = new System.Windows.Forms.Label();
            this.reason_content = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // operate_suc_chk
            // 
            this.operate_suc_chk.AutoSize = true;
            this.operate_suc_chk.Location = new System.Drawing.Point(86, 84);
            this.operate_suc_chk.Name = "operate_suc_chk";
            this.operate_suc_chk.Size = new System.Drawing.Size(86, 19);
            this.operate_suc_chk.TabIndex = 0;
            this.operate_suc_chk.Text = "可以开启";
            this.operate_suc_chk.UseVisualStyleBackColor = true;
            this.operate_suc_chk.CheckedChanged += new System.EventHandler(this.operate_suc_CheckedChanged);
            this.operate_suc_chk.Click += new System.EventHandler(this.operate_suc_chk_Click);
            // 
            // operate_fail_chk
            // 
            this.operate_fail_chk.AutoSize = true;
            this.operate_fail_chk.Location = new System.Drawing.Point(86, 184);
            this.operate_fail_chk.Name = "operate_fail_chk";
            this.operate_fail_chk.Size = new System.Drawing.Size(86, 19);
            this.operate_fail_chk.TabIndex = 1;
            this.operate_fail_chk.Text = "无法开启";
            this.operate_fail_chk.UseVisualStyleBackColor = true;
            this.operate_fail_chk.CheckedChanged += new System.EventHandler(this.operate_fail_CheckedChanged);
            this.operate_fail_chk.Click += new System.EventHandler(this.operate_fail_Click);
            // 
            // confirm_btn
            // 
            this.confirm_btn.Location = new System.Drawing.Point(264, 332);
            this.confirm_btn.Name = "confirm_btn";
            this.confirm_btn.Size = new System.Drawing.Size(143, 40);
            this.confirm_btn.TabIndex = 2;
            this.confirm_btn.Text = "确定";
            this.confirm_btn.UseVisualStyleBackColor = true;
            this.confirm_btn.Click += new System.EventHandler(this.confirm_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(490, 333);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(143, 39);
            this.cancel_btn.TabIndex = 3;
            this.cancel_btn.Text = "取消";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(337, 81);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(296, 25);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // fail_reason
            // 
            this.fail_reason.AutoSize = true;
            this.fail_reason.Location = new System.Drawing.Point(245, 185);
            this.fail_reason.Name = "fail_reason";
            this.fail_reason.Size = new System.Drawing.Size(37, 15);
            this.fail_reason.TabIndex = 5;
            this.fail_reason.Text = "原因";
            // 
            // reason_content
            // 
            this.reason_content.Location = new System.Drawing.Point(337, 182);
            this.reason_content.Name = "reason_content";
            this.reason_content.Size = new System.Drawing.Size(450, 25);
            this.reason_content.TabIndex = 6;
            // 
            // feedbackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 452);
            this.Controls.Add(this.reason_content);
            this.Controls.Add(this.fail_reason);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.confirm_btn);
            this.Controls.Add(this.operate_fail_chk);
            this.Controls.Add(this.operate_suc_chk);
            this.Name = "feedbackForm";
            this.Text = "feedbackForm";
            this.Load += new System.EventHandler(this.feedbackForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox operate_suc_chk;
        private System.Windows.Forms.CheckBox operate_fail_chk;
        private System.Windows.Forms.Button confirm_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label fail_reason;
        private System.Windows.Forms.TextBox reason_content;
    }
}