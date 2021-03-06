﻿namespace ComSniff
{
    partial class Form1
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
            this.comboBoxComPort1 = new System.Windows.Forms.ComboBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.comboBoxComPort2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSniffed = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.comboBoxFlowControl = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.comboBoxStopBits = new System.Windows.Forms.ComboBox();
            this.LabelParity = new System.Windows.Forms.Label();
            this.comboBoxParity = new System.Windows.Forms.ComboBox();
            this.LabelDataBits = new System.Windows.Forms.Label();
            this.comboBoxDataBits = new System.Windows.Forms.ComboBox();
            this.LabelBitsPerSecond = new System.Windows.Forms.Label();
            this.comboBoxBitsPerSecond = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxComPort1
            // 
            this.comboBoxComPort1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComPort1.FormattingEnabled = true;
            this.comboBoxComPort1.Location = new System.Drawing.Point(9, 25);
            this.comboBoxComPort1.Name = "comboBoxComPort1";
            this.comboBoxComPort1.Size = new System.Drawing.Size(211, 21);
            this.comboBoxComPort1.TabIndex = 0;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(374, 68);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "&Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 311);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(472, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // comboBoxComPort2
            // 
            this.comboBoxComPort2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComPort2.FormattingEnabled = true;
            this.comboBoxComPort2.Location = new System.Drawing.Point(238, 25);
            this.comboBoxComPort2.Name = "comboBoxComPort2";
            this.comboBoxComPort2.Size = new System.Drawing.Size(211, 21);
            this.comboBoxComPort2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "COM A:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "COM B:";
            // 
            // textBoxSniffed
            // 
            this.textBoxSniffed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSniffed.Location = new System.Drawing.Point(12, 98);
            this.textBoxSniffed.Multiline = true;
            this.textBoxSniffed.Name = "textBoxSniffed";
            this.textBoxSniffed.Size = new System.Drawing.Size(446, 204);
            this.textBoxSniffed.TabIndex = 8;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(280, 55);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(68, 13);
            this.Label5.TabIndex = 46;
            this.Label5.Text = "Flow Control:";
            // 
            // comboBoxFlowControl
            // 
            this.comboBoxFlowControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFlowControl.FormattingEnabled = true;
            this.comboBoxFlowControl.Items.AddRange(new object[] {
            "None",
            "Hardware",
            "Both",
            "Xon / Xoff"});
            this.comboBoxFlowControl.Location = new System.Drawing.Point(284, 72);
            this.comboBoxFlowControl.Name = "comboBoxFlowControl";
            this.comboBoxFlowControl.Size = new System.Drawing.Size(72, 21);
            this.comboBoxFlowControl.TabIndex = 45;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(227, 55);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(51, 13);
            this.Label4.TabIndex = 44;
            this.Label4.Text = "Stop bits:";
            // 
            // comboBoxStopBits
            // 
            this.comboBoxStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStopBits.FormattingEnabled = true;
            this.comboBoxStopBits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.comboBoxStopBits.Location = new System.Drawing.Point(230, 72);
            this.comboBoxStopBits.Name = "comboBoxStopBits";
            this.comboBoxStopBits.Size = new System.Drawing.Size(48, 21);
            this.comboBoxStopBits.TabIndex = 43;
            // 
            // LabelParity
            // 
            this.LabelParity.AutoSize = true;
            this.LabelParity.Location = new System.Drawing.Point(161, 55);
            this.LabelParity.Name = "LabelParity";
            this.LabelParity.Size = new System.Drawing.Size(33, 13);
            this.LabelParity.TabIndex = 42;
            this.LabelParity.Text = "Parity";
            // 
            // comboBoxParity
            // 
            this.comboBoxParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParity.FormattingEnabled = true;
            this.comboBoxParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.comboBoxParity.Location = new System.Drawing.Point(164, 72);
            this.comboBoxParity.Name = "comboBoxParity";
            this.comboBoxParity.Size = new System.Drawing.Size(61, 21);
            this.comboBoxParity.TabIndex = 41;
            // 
            // LabelDataBits
            // 
            this.LabelDataBits.AutoSize = true;
            this.LabelDataBits.Location = new System.Drawing.Point(94, 55);
            this.LabelDataBits.Name = "LabelDataBits";
            this.LabelDataBits.Size = new System.Drawing.Size(53, 13);
            this.LabelDataBits.TabIndex = 40;
            this.LabelDataBits.Text = "Data Bits:";
            // 
            // comboBoxDataBits
            // 
            this.comboBoxDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataBits.FormattingEnabled = true;
            this.comboBoxDataBits.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5"});
            this.comboBoxDataBits.Location = new System.Drawing.Point(97, 72);
            this.comboBoxDataBits.Name = "comboBoxDataBits";
            this.comboBoxDataBits.Size = new System.Drawing.Size(62, 21);
            this.comboBoxDataBits.TabIndex = 39;
            // 
            // LabelBitsPerSecond
            // 
            this.LabelBitsPerSecond.AutoSize = true;
            this.LabelBitsPerSecond.Location = new System.Drawing.Point(6, 55);
            this.LabelBitsPerSecond.Name = "LabelBitsPerSecond";
            this.LabelBitsPerSecond.Size = new System.Drawing.Size(86, 13);
            this.LabelBitsPerSecond.TabIndex = 38;
            this.LabelBitsPerSecond.Text = "Bits Per Second:";
            // 
            // comboBoxBitsPerSecond
            // 
            this.comboBoxBitsPerSecond.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBitsPerSecond.FormattingEnabled = true;
            this.comboBoxBitsPerSecond.Items.AddRange(new object[] {
            "110",
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600",
            "1250000"});
            this.comboBoxBitsPerSecond.Location = new System.Drawing.Point(9, 72);
            this.comboBoxBitsPerSecond.Name = "comboBoxBitsPerSecond";
            this.comboBoxBitsPerSecond.Size = new System.Drawing.Size(83, 21);
            this.comboBoxBitsPerSecond.TabIndex = 37;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(83, 26);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(82, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 333);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.comboBoxFlowControl);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.comboBoxStopBits);
            this.Controls.Add(this.LabelParity);
            this.Controls.Add(this.comboBoxParity);
            this.Controls.Add(this.LabelDataBits);
            this.Controls.Add(this.comboBoxDataBits);
            this.Controls.Add(this.LabelBitsPerSecond);
            this.Controls.Add(this.comboBoxBitsPerSecond);
            this.Controls.Add(this.textBoxSniffed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxComPort2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.comboBoxComPort1);
            this.MinimumSize = new System.Drawing.Size(488, 372);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxComPort1;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ComboBox comboBoxComPort2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSniffed;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.ComboBox comboBoxFlowControl;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ComboBox comboBoxStopBits;
        internal System.Windows.Forms.Label LabelParity;
        internal System.Windows.Forms.ComboBox comboBoxParity;
        internal System.Windows.Forms.Label LabelDataBits;
        internal System.Windows.Forms.ComboBox comboBoxDataBits;
        internal System.Windows.Forms.Label LabelBitsPerSecond;
        internal System.Windows.Forms.ComboBox comboBoxBitsPerSecond;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

