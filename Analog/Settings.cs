using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Analog
{
    public partial class Settings : Form
    {
        

        public Settings()
        {
            InitializeComponent();
        }

        Properties.Settings s = new Properties.Settings();

        private void Settigs_Load(object sender, EventArgs e)
        {
            // Regex
            textBox_Regex.Text = s.Regex;
            
            // RS232
            textBox_COM.Text = s.SerialPort;
            numericUpDown_BaudRate.Value = s.BaudRate;
            numericUpDown_DataBits.Value = s.DataBits;
            numericUpDown_ReadTimeout.Value = s.ReadTimeout;
            numericUpDown_WriteTimeout.Value = s.WriteTimeout;
            comboBox_DTR.Text = s.DtrEnable.ToString();
            comboBox_RTS.Text = s.RtsEnable.ToString();

            // Program
            comboBox_Update.Text = s.Update.ToString();
            comboBox_Debug.Text = s.Debug.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            s.Regex = textBox_Regex.Text;

            s.SerialPort = textBox_COM.Text;
            s.BaudRate = (int)numericUpDown_BaudRate.Value;
            s.DataBits = (int)numericUpDown_DataBits.Value;
            s.ReadTimeout = (int)numericUpDown_ReadTimeout.Value;
            s.WriteTimeout = (int)numericUpDown_WriteTimeout.Value;
            s.DtrEnable = Convert.ToBoolean(comboBox_DTR.Text);
            s.RtsEnable = Convert.ToBoolean(comboBox_RTS.Text);
            s.Update = Convert.ToBoolean(comboBox_Update.Text);
            s.Debug = Convert.ToBoolean(comboBox_Debug.Text);
            
            s.Save();
            MessageBox.Show("Endringene er lagret!\nProgrammet må startes på nytt for at endringene skal tre i kraft.", "Informasjon");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
