﻿namespace Analog
{
    partial class SettingsForm
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
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_Regex = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Update = new System.Windows.Forms.ComboBox();
            this.comboBox_Debug = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_COM = new System.Windows.Forms.TextBox();
            this.numericUpDown_BaudRate = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown_DataBits = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_ReadTimeout = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDown_WriteTimeout = new System.Windows.Forms.NumericUpDown();
            this.comboBox_DTR = new System.Windows.Forms.ComboBox();
            this.comboBox_RTS = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_BaudRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DataBits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ReadTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_WriteTimeout)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(340, 362);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 2;
            this.button_Save.Text = "Lagre";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(259, 362);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 5;
            this.button_Cancel.Text = "Avbryt";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(411, 322);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Program";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox_Regex);
            this.groupBox1.Location = new System.Drawing.Point(7, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 155);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Søk etter:";
            // 
            // textBox_Regex
            // 
            this.textBox_Regex.Location = new System.Drawing.Point(12, 19);
            this.textBox_Regex.Multiline = true;
            this.textBox_Regex.Name = "textBox_Regex";
            this.textBox_Regex.Size = new System.Drawing.Size(372, 60);
            this.textBox_Regex.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 85);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(372, 60);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "Backup:\r\n(\\w{11}=|\\w{16}:.)(\\d{2})\\s+(\\w{9}=(\\d{2})\\s+\\w{5}=(\\d{2})|\\w{7}).*?(\\n|" +
    "\\r\\n)\\w+.:(\\d{2}.?)(\\d{2,3})\\s+(\\w+\\|?\\s?\\w+?)\\s";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox_Debug);
            this.groupBox3.Controls.Add(this.comboBox_Update);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(7, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(396, 107);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Program";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Debug:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Se etter oppdateringer ved oppstart:";
            // 
            // comboBox_Update
            // 
            this.comboBox_Update.FormattingEnabled = true;
            this.comboBox_Update.Items.AddRange(new object[] {
            "True",
            "False"});
            this.comboBox_Update.Location = new System.Drawing.Point(12, 36);
            this.comboBox_Update.Name = "comboBox_Update";
            this.comboBox_Update.Size = new System.Drawing.Size(372, 21);
            this.comboBox_Update.TabIndex = 23;
            // 
            // comboBox_Debug
            // 
            this.comboBox_Debug.FormattingEnabled = true;
            this.comboBox_Debug.Items.AddRange(new object[] {
            "True",
            "False"});
            this.comboBox_Debug.Location = new System.Drawing.Point(13, 76);
            this.comboBox_Debug.Name = "comboBox_Debug";
            this.comboBox_Debug.Size = new System.Drawing.Size(371, 21);
            this.comboBox_Debug.TabIndex = 24;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(411, 322);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "RS232";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_RTS);
            this.groupBox2.Controls.Add(this.comboBox_DTR);
            this.groupBox2.Controls.Add(this.numericUpDown_WriteTimeout);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.numericUpDown_ReadTimeout);
            this.groupBox2.Controls.Add(this.numericUpDown_DataBits);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.numericUpDown_BaudRate);
            this.groupBox2.Controls.Add(this.textBox_COM);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(7, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(396, 305);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RS232";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Data Bits:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Read Timeout:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Baud Rate:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Serial Port (feks \"COM1\"):";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Write Timeout:";
            // 
            // textBox_COM
            // 
            this.textBox_COM.Location = new System.Drawing.Point(12, 33);
            this.textBox_COM.Name = "textBox_COM";
            this.textBox_COM.Size = new System.Drawing.Size(373, 20);
            this.textBox_COM.TabIndex = 0;
            // 
            // numericUpDown_BaudRate
            // 
            this.numericUpDown_BaudRate.Location = new System.Drawing.Point(12, 72);
            this.numericUpDown_BaudRate.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.numericUpDown_BaudRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_BaudRate.Name = "numericUpDown_BaudRate";
            this.numericUpDown_BaudRate.Size = new System.Drawing.Size(373, 20);
            this.numericUpDown_BaudRate.TabIndex = 17;
            this.numericUpDown_BaudRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 218);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "DTR:";
            // 
            // numericUpDown_DataBits
            // 
            this.numericUpDown_DataBits.Location = new System.Drawing.Point(12, 111);
            this.numericUpDown_DataBits.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_DataBits.Name = "numericUpDown_DataBits";
            this.numericUpDown_DataBits.Size = new System.Drawing.Size(373, 20);
            this.numericUpDown_DataBits.TabIndex = 18;
            // 
            // numericUpDown_ReadTimeout
            // 
            this.numericUpDown_ReadTimeout.Location = new System.Drawing.Point(12, 150);
            this.numericUpDown_ReadTimeout.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDown_ReadTimeout.Name = "numericUpDown_ReadTimeout";
            this.numericUpDown_ReadTimeout.Size = new System.Drawing.Size(373, 20);
            this.numericUpDown_ReadTimeout.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 258);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "RTS:";
            // 
            // numericUpDown_WriteTimeout
            // 
            this.numericUpDown_WriteTimeout.Location = new System.Drawing.Point(12, 192);
            this.numericUpDown_WriteTimeout.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDown_WriteTimeout.Name = "numericUpDown_WriteTimeout";
            this.numericUpDown_WriteTimeout.Size = new System.Drawing.Size(373, 20);
            this.numericUpDown_WriteTimeout.TabIndex = 20;
            // 
            // comboBox_DTR
            // 
            this.comboBox_DTR.FormattingEnabled = true;
            this.comboBox_DTR.Items.AddRange(new object[] {
            "True",
            "False"});
            this.comboBox_DTR.Location = new System.Drawing.Point(13, 234);
            this.comboBox_DTR.Name = "comboBox_DTR";
            this.comboBox_DTR.Size = new System.Drawing.Size(372, 21);
            this.comboBox_DTR.TabIndex = 21;
            // 
            // comboBox_RTS
            // 
            this.comboBox_RTS.FormattingEnabled = true;
            this.comboBox_RTS.Items.AddRange(new object[] {
            "True",
            "False"});
            this.comboBox_RTS.Location = new System.Drawing.Point(12, 274);
            this.comboBox_RTS.Name = "comboBox_RTS";
            this.comboBox_RTS.Size = new System.Drawing.Size(372, 21);
            this.comboBox_RTS.TabIndex = 22;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(8, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(419, 348);
            this.tabControl1.TabIndex = 4;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 390);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button_Save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Instillinger";
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_BaudRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DataBits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ReadTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_WriteTimeout)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBox_Debug;
        private System.Windows.Forms.ComboBox comboBox_Update;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox_Regex;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox_RTS;
        private System.Windows.Forms.ComboBox comboBox_DTR;
        private System.Windows.Forms.NumericUpDown numericUpDown_WriteTimeout;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDown_ReadTimeout;
        private System.Windows.Forms.NumericUpDown numericUpDown_DataBits;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDown_BaudRate;
        private System.Windows.Forms.TextBox textBox_COM;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tabControl1;
    }
}