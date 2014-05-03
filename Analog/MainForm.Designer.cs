namespace Analog
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.åpneFilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tømVinduToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lagreSomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instillingerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hjelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eEPROMSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hyperterminalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.omToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.checkBox_ShowAll = new System.Windows.Forms.CheckBox();
            this.numericUpDown_Low = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_High = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox_Settings = new System.Windows.Forms.GroupBox();
            this.groupBox_RS232 = new System.Windows.Forms.GroupBox();
            this.textBox_Send = new System.Windows.Forms.TextBox();
            this.button_Send = new System.Windows.Forms.Button();
            this.textBox_RS232 = new System.Windows.Forms.TextBox();
            this.button_Start = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Low)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_High)).BeginInit();
            this.groupBox_Settings.SuspendLayout();
            this.groupBox_RS232.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column2,
            this.Column4,
            this.Column5});
            this.dataGridView1.Location = new System.Drawing.Point(6, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(407, 283);
            this.dataGridView1.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column1.HeaderText = "Adresse";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 70;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 352.7559F;
            this.Column3.HeaderText = "Detektor Type";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 130;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.FillWeight = 15.74803F;
            this.Column2.HeaderText = "Forvarsel";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.FillWeight = 15.74803F;
            this.Column4.HeaderText = "Alarm";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.FillWeight = 15.74803F;
            this.Column5.HeaderText = "Verdi";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filToolStripMenuItem,
            this.instillingerToolStripMenuItem,
            this.hjelpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(418, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filToolStripMenuItem
            // 
            this.filToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.åpneFilToolStripMenuItem,
            this.tømVinduToolStripMenuItem,
            this.lagreSomToolStripMenuItem});
            this.filToolStripMenuItem.Name = "filToolStripMenuItem";
            this.filToolStripMenuItem.Size = new System.Drawing.Size(31, 20);
            this.filToolStripMenuItem.Text = "Fil";
            // 
            // åpneFilToolStripMenuItem
            // 
            this.åpneFilToolStripMenuItem.Name = "åpneFilToolStripMenuItem";
            this.åpneFilToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.åpneFilToolStripMenuItem.Text = "Åpne fil";
            this.åpneFilToolStripMenuItem.Click += new System.EventHandler(this.åpneFilToolStripMenuItem_Click);
            // 
            // tømVinduToolStripMenuItem
            // 
            this.tømVinduToolStripMenuItem.Name = "tømVinduToolStripMenuItem";
            this.tømVinduToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.tømVinduToolStripMenuItem.Text = "Tøm vindu";
            this.tømVinduToolStripMenuItem.Click += new System.EventHandler(this.tømVinduToolStripMenuItem_Click);
            // 
            // lagreSomToolStripMenuItem
            // 
            this.lagreSomToolStripMenuItem.Name = "lagreSomToolStripMenuItem";
            this.lagreSomToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.lagreSomToolStripMenuItem.Text = "Lagre som..";
            this.lagreSomToolStripMenuItem.Click += new System.EventHandler(this.lagreSomToolStripMenuItem_Click);
            // 
            // instillingerToolStripMenuItem
            // 
            this.instillingerToolStripMenuItem.Name = "instillingerToolStripMenuItem";
            this.instillingerToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.instillingerToolStripMenuItem.Text = "Instillinger";
            this.instillingerToolStripMenuItem.Click += new System.EventHandler(this.instillingerToolStripMenuItem_Click);
            // 
            // hjelpToolStripMenuItem
            // 
            this.hjelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eEPROMSetupToolStripMenuItem,
            this.omToolStripMenuItem});
            this.hjelpToolStripMenuItem.Name = "hjelpToolStripMenuItem";
            this.hjelpToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.hjelpToolStripMenuItem.Text = "Hjelp";
            // 
            // eEPROMSetupToolStripMenuItem
            // 
            this.eEPROMSetupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hyperterminalToolStripMenuItem});
            this.eEPROMSetupToolStripMenuItem.Name = "eEPROMSetupToolStripMenuItem";
            this.eEPROMSetupToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.eEPROMSetupToolStripMenuItem.Text = "Oppsett";
            // 
            // hyperterminalToolStripMenuItem
            // 
            this.hyperterminalToolStripMenuItem.Name = "hyperterminalToolStripMenuItem";
            this.hyperterminalToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.hyperterminalToolStripMenuItem.Text = "Delta DA/ANX95";
            this.hyperterminalToolStripMenuItem.Click += new System.EventHandler(this.hyperterminalToolStripMenuItem_Click);
            // 
            // omToolStripMenuItem
            // 
            this.omToolStripMenuItem.Name = "omToolStripMenuItem";
            this.omToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.omToolStripMenuItem.Text = "Om M42111..";
            this.omToolStripMenuItem.Click += new System.EventHandler(this.omToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 514);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(418, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(42, 22);
            this.toolStripLabel1.Text = "Status:";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // checkBox_ShowAll
            // 
            this.checkBox_ShowAll.AutoSize = true;
            this.checkBox_ShowAll.Location = new System.Drawing.Point(306, 18);
            this.checkBox_ShowAll.Name = "checkBox_ShowAll";
            this.checkBox_ShowAll.Size = new System.Drawing.Size(94, 17);
            this.checkBox_ShowAll.TabIndex = 6;
            this.checkBox_ShowAll.Text = "Vis alle verdier";
            this.checkBox_ShowAll.UseVisualStyleBackColor = true;
            this.checkBox_ShowAll.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // numericUpDown_Low
            // 
            this.numericUpDown_Low.Location = new System.Drawing.Point(7, 17);
            this.numericUpDown_Low.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDown_Low.Name = "numericUpDown_Low";
            this.numericUpDown_Low.Size = new System.Drawing.Size(46, 20);
            this.numericUpDown_Low.TabIndex = 7;
            this.numericUpDown_Low.ValueChanged += new System.EventHandler(this.numericUpDown_Low_ValueChanged);
            // 
            // numericUpDown_High
            // 
            this.numericUpDown_High.Location = new System.Drawing.Point(75, 17);
            this.numericUpDown_High.Name = "numericUpDown_High";
            this.numericUpDown_High.Size = new System.Drawing.Size(46, 20);
            this.numericUpDown_High.TabIndex = 8;
            this.numericUpDown_High.ValueChanged += new System.EventHandler(this.numericUpDown_High_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "= OK";
            // 
            // groupBox_Settings
            // 
            this.groupBox_Settings.Controls.Add(this.numericUpDown_High);
            this.groupBox_Settings.Controls.Add(this.checkBox_ShowAll);
            this.groupBox_Settings.Controls.Add(this.label2);
            this.groupBox_Settings.Controls.Add(this.numericUpDown_Low);
            this.groupBox_Settings.Controls.Add(this.label1);
            this.groupBox_Settings.Location = new System.Drawing.Point(6, 319);
            this.groupBox_Settings.Name = "groupBox_Settings";
            this.groupBox_Settings.Size = new System.Drawing.Size(407, 45);
            this.groupBox_Settings.TabIndex = 11;
            this.groupBox_Settings.TabStop = false;
            this.groupBox_Settings.Text = "Analogverdi";
            // 
            // groupBox_RS232
            // 
            this.groupBox_RS232.Controls.Add(this.textBox_Send);
            this.groupBox_RS232.Controls.Add(this.button_Send);
            this.groupBox_RS232.Controls.Add(this.textBox_RS232);
            this.groupBox_RS232.Controls.Add(this.button_Start);
            this.groupBox_RS232.Location = new System.Drawing.Point(6, 370);
            this.groupBox_RS232.Name = "groupBox_RS232";
            this.groupBox_RS232.Size = new System.Drawing.Size(407, 135);
            this.groupBox_RS232.TabIndex = 13;
            this.groupBox_RS232.TabStop = false;
            this.groupBox_RS232.Text = "RS232";
            // 
            // textBox_Send
            // 
            this.textBox_Send.Location = new System.Drawing.Point(7, 107);
            this.textBox_Send.Name = "textBox_Send";
            this.textBox_Send.Size = new System.Drawing.Size(222, 20);
            this.textBox_Send.TabIndex = 9;
            // 
            // button_Send
            // 
            this.button_Send.Enabled = false;
            this.button_Send.Location = new System.Drawing.Point(235, 105);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(80, 23);
            this.button_Send.TabIndex = 8;
            this.button_Send.Text = "Send";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // textBox_RS232
            // 
            this.textBox_RS232.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox_RS232.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_RS232.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_RS232.Location = new System.Drawing.Point(7, 19);
            this.textBox_RS232.Multiline = true;
            this.textBox_RS232.Name = "textBox_RS232";
            this.textBox_RS232.ReadOnly = true;
            this.textBox_RS232.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_RS232.Size = new System.Drawing.Size(394, 84);
            this.textBox_RS232.TabIndex = 6;
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(321, 105);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(80, 23);
            this.button_Start.TabIndex = 5;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 539);
            this.Controls.Add(this.groupBox_RS232);
            this.Controls.Add(this.groupBox_Settings);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Analog";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Low)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_High)).EndInit();
            this.groupBox_Settings.ResumeLayout(false);
            this.groupBox_Settings.PerformLayout();
            this.groupBox_RS232.ResumeLayout(false);
            this.groupBox_RS232.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hjelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eEPROMSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hyperterminalToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripMenuItem omToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem filToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lagreSomToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox_ShowAll;
        private System.Windows.Forms.NumericUpDown numericUpDown_Low;
        private System.Windows.Forms.NumericUpDown numericUpDown_High;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox_Settings;
        private System.Windows.Forms.GroupBox groupBox_RS232;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.ToolStripMenuItem åpneFilToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.TextBox textBox_RS232;
        private System.Windows.Forms.ToolStripMenuItem tømVinduToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox_Send;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.ToolStripMenuItem instillingerToolStripMenuItem;
    }
}

