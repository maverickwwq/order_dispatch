﻿namespace zk
{
    partial class orderInfoForm
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
            this.components = new System.ComponentModel.Container();
            this.orderInfo_dgv = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.反馈ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.check_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.orderInfo_dgv)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // orderInfo_dgv
            // 
            this.orderInfo_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderInfo_dgv.ContextMenuStrip = this.contextMenuStrip1;
            this.orderInfo_dgv.Location = new System.Drawing.Point(28, 180);
            this.orderInfo_dgv.Name = "orderInfo_dgv";
            this.orderInfo_dgv.RowTemplate.Height = 27;
            this.orderInfo_dgv.Size = new System.Drawing.Size(1383, 282);
            this.orderInfo_dgv.TabIndex = 0;
            this.orderInfo_dgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.orderOpClick);
            this.orderInfo_dgv.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.orderOpDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.反馈ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 28);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 反馈ToolStripMenuItem
            // 
            this.反馈ToolStripMenuItem.Name = "反馈ToolStripMenuItem";
            this.反馈ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.反馈ToolStripMenuItem.Text = "反馈";
            this.反馈ToolStripMenuItem.Click += new System.EventHandler(this.反馈ToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(863, 543);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 56);
            this.button1.TabIndex = 1;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(635, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // check_btn
            // 
            this.check_btn.Location = new System.Drawing.Point(453, 543);
            this.check_btn.Name = "check_btn";
            this.check_btn.Size = new System.Drawing.Size(165, 56);
            this.check_btn.TabIndex = 3;
            this.check_btn.Text = "button2";
            this.check_btn.UseVisualStyleBackColor = true;
            this.check_btn.Click += new System.EventHandler(this.check_btn_Click);
            // 
            // orderInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1439, 774);
            this.Controls.Add(this.check_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.orderInfo_dgv);
            this.Name = "orderInfoForm";
            this.Text = "orderInfoForm";
            this.Load += new System.EventHandler(this.orderInfoForm_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.反馈ToolStripMenuItem_Click);
            ((System.ComponentModel.ISupportInitialize)(this.orderInfo_dgv)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView orderInfo_dgv;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button check_btn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 反馈ToolStripMenuItem;
    }
}