using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Analog.Classes;

namespace Analog
{
    public partial class SettingsForm : Form
    {
        Config config = new Config();
        
        public SettingsForm()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            SaveSettings();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void LoadSettings()
        {
            // Regex
            textBox_Regex.Text = config.Regex;

            // RS232
            textBox_COM.Text = config.SerialPort;
            numericUpDown_BaudRate.Value = config.BaudRate;
            numericUpDown_DataBits.Value = config.DataBits;
            numericUpDown_ReadTimeout.Value = config.ReadTimeout;
            numericUpDown_WriteTimeout.Value = config.WriteTimeout;
            comboBox_DTR.Text = config.DtrEnable.ToString();
            comboBox_RTS.Text = config.RtsEnable.ToString();

            // Program
            comboBox_Update.Text = config.AutoUpdate.ToString();
            comboBox_Debug.Text = config.Debug.ToString();
        }

        private void SaveSettings()
        {
            // Todo: unchanged settings
            config.SerialPort = textBox_COM.Text.ToUpper();
            config.Regex = textBox_Regex.Text;
            config.BaudRate = (int)numericUpDown_BaudRate.Value;
            config.DataBits = (int)numericUpDown_DataBits.Value;
            config.ReadTimeout = (int)numericUpDown_ReadTimeout.Value;
            config.WriteTimeout = (int)numericUpDown_WriteTimeout.Value;
            config.DtrEnable = Convert.ToBoolean(comboBox_DTR.Text);
            config.RtsEnable = Convert.ToBoolean(comboBox_RTS.Text);
            config.AutoUpdate = Convert.ToBoolean(comboBox_Update.Text);
            config.Debug = Convert.ToBoolean(comboBox_Debug.Text);
        }

    }
}
