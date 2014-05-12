using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analog.Classes;
using System.Threading;
using System.Net;


namespace Analog
{
    /// <summary>
    /// Sources:
    /// http://stackoverflow.com/questions/5525181/find-each-regex-match-in-string
    /// http://stackoverflow.com/questions/5101217/rs232-serial-port-communication-c-sharp-win7-net-framework-3-5-sp1
    /// </summary>
    /// 
    public partial class MainForm : Form
    {

        Config config = new Config();
        public MainForm()
        {
            InitializeComponent();

            if (config.Debug)
                this.Text += " [Debug]";

            groupBox_RS232.Text += string.Format(" ({0})", config.SerialPort);
            numericUpDown_High.Value = config.NumericUpDown_High;
            numericUpDown_Low.Value = config.NumericUpDown_Low;

            // Check for new release if AutoUpdate is true
            if (config.AutoUpdate)
                checkRelease();
        }

        // Check for new releases
        public void checkRelease(bool showResponse = false)
        {
            var url = "https://github.com/Nemto/Analog/releases";
            var currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            if (Upgrade.Needed(currentVersion))
                if (MessageBox.Show("En ny oppdatering er tilgjengelig!\n Vil du laste ned nå?\n\n" + url, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    Process.Start(url);
            
            if (showResponse)
                MessageBox.Show("Ingen nye oppdateringer.");
        }

        // Restart app when when settings is saved
        public void restart()
        {
            // Is there a better way to update UI then this?
            Application.Restart();
        }

        // ErrorCounter
        private void countErrors()
        {
            if (config.ErrorCount == 0)
                populateGrid(config.ErrorCount.ToString(), "feil funnet.", null, null, null, Color.YellowGreen); 
            else
                populateGrid(config.ErrorCount.ToString(), "feil funnet.", null, null, null, Color.Red);
        }

        // Regex
        private void matchText(string input)
        {
            Regex regex = new Regex(config.Regex, RegexOptions.IgnoreCase);

            string detektorAdresse, detektorType;
            int? forvarselGrense, alarmGrense, analogvedi;
     
            foreach (Match match in regex.Matches(input))
            {
                detektorAdresse = match.Groups[7].Value + match.Groups[8].Value;
                detektorType = match.Groups[9].Value.Replace("|", "ø");
                forvarselGrense = To.int32(match.Groups[4].Value);
                alarmGrense = To.int32(match.Groups[5].Value);
                analogvedi = To.int32(match.Groups[2].Value);
                
                if (match.Groups[3].Value == "PROSENT")
                    detektorType = "[IQ8] " + detektorType;

                //Todo: Prevent logging of deactivated detectors

                // Send bad apollo values to gridview
                if (!checkBox_Quad.Checked)
                {
                    if (analogvedi < numericUpDown_Low.Value || analogvedi > numericUpDown_High.Value)
                    {
                        populateGrid(detektorAdresse, detektorType, forvarselGrense, alarmGrense, analogvedi, Color.White);
                        config.ErrorCount++;
                    }
                }

                // Send bad quad values to gridview
                if (checkBox_Quad.Checked)
                {
                    if(analogvedi > numericUpDown_Low.Value)
                    {
                        populateGrid(detektorAdresse, detektorType, forvarselGrense, alarmGrense, analogvedi, Color.White);
                        config.ErrorCount++;
                    }
                }
            }

            // Count error if showall is not checked 
            if (!checkBox_ShowAll.Checked)
                countErrors();
        }

        // Insert to datagridview
        private void populateGrid(string addresse, string detektortype, int? prealarm, int? alarm, int? analogverdi, Color color)
        {
            DataGridViewRow row1 = (DataGridViewRow)dataGridView1.Rows[0].Clone();

            row1.Cells[0].Value = addresse;             //loop+adress
            row1.Cells[1].Value = detektortype;         //type
            row1.Cells[2].Value = prealarm;             //pre-al
            row1.Cells[3].Value = alarm;                //alarm
            row1.Cells[4].Value = analogverdi;          //value
            row1.DefaultCellStyle.BackColor = color;    //rowcolor

            // Paint it gray row grey if alarm is 99 or 0
            if (alarm == 0 || alarm == 99)
            {
                row1.DefaultCellStyle.BackColor = Color.LightGray;
                row1.Cells[1].Value = "ALARM GRENSE = " + alarm;
            }

            dataGridView1.Rows.Add(row1);
        }

        #region FileDialogs
        
        // Open file
        private void selectFile_show()
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Alle filer (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            matchText(File.ReadAllText(openFileDialog1.FileName.ToString()));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Kunne ikke lese filen\n\nEx. melding: " + ex.Message);
                }
            }
        }

        // Save file
        private void saveFile_Show()
        {
            DateTime dateTime = DateTime.Now;

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "All files (*.*)|*.*";
                dialog.FileName = "log_" + dateTime.ToString("ddMMyyhhmm") + ".csv";
                dialog.FilterIndex = 2;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (Stream stream = dialog.OpenFile())
                    {
                    }

                    string CsvFpath = dialog.FileName.ToString();
                    try
                    {
                        System.IO.StreamWriter csvFileWriter = new StreamWriter(CsvFpath, false);

                        string columnHeaderText = "";

                        int countColumn = dataGridView1.ColumnCount - 1;

                        if (countColumn >= 0)
                        {
                            columnHeaderText = dataGridView1.Columns[0].HeaderText;
                        }

                        for (int i = 1; i <= countColumn; i++)
                        {
                            columnHeaderText = columnHeaderText + ';' + dataGridView1.Columns[i].HeaderText;
                        }


                        csvFileWriter.WriteLine(columnHeaderText);

                        foreach (DataGridViewRow dataRowObject in dataGridView1.Rows)
                        {
                            if (!dataRowObject.IsNewRow)
                            {
                                string dataFromGrid = dataRowObject.Cells[0].Value.ToString();

                                for (int i = 1; i <= countColumn; i++)
                                {
                                    dataFromGrid = dataFromGrid + ';' + dataRowObject.Cells[i].Value.ToString();
                                }

                                csvFileWriter.WriteLine(dataFromGrid);
                            }
                        }

                        csvFileWriter.Flush();
                        csvFileWriter.Close();
                    }
                    catch (Exception exceptionObject)
                    {
                        MessageBox.Show(exceptionObject.ToString());
                    }
                }
            }
        }

        #endregion

        #region Menu: File

        // Open file
        private void åpneFilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            config.ErrorCount = 0;
            selectFile_show();
        }

        // Empty window
        private void tømVinduToolStripMenuItem_Click(object sender, EventArgs e)
        {
            config.ErrorCount = 0;
            dataGridView1.Rows.Clear();
        }

        // Save as
        private void lagreSomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile_Show();
        }
        #endregion

        #region Menu: Help

        // About
        private void omToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox abox = new AboutBox();
            abox.Show();
        }




        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = "README.txt";
            try
            {
                Process.Start(fileName);
            }
            catch
            {
                MessageBox.Show("Finner ikke filen README.txt", "Error");
            }
        }

        private void erDetteNyesteVersjonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkRelease(true);
        }

        #endregion

        #region Menu: Settings
        
        private void instillingerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.Show();
        }

        #endregion

        #region RS232 Reader

        private delegate void SetTextDeleg(string data);
        private SerialPort mySerialPort;

        public void StartRS232()
        {
            try
            {
                mySerialPort = new SerialPort(config.SerialPort);

                mySerialPort.BaudRate = config.BaudRate;
                mySerialPort.Parity = Parity.None;
                mySerialPort.StopBits = StopBits.One;
                mySerialPort.DataBits = config.DataBits;
                mySerialPort.Handshake = Handshake.None;
                mySerialPort.ReadTimeout = config.ReadTimeout;
                mySerialPort.WriteTimeout = config.WriteTimeout;

                mySerialPort.DtrEnable = config.DtrEnable;
                mySerialPort.RtsEnable = config.RtsEnable;

                mySerialPort.Open();
                mySerialPort.DataReceived += DataReceivedHandler;

                textBox_RS232.Text = "Klar, trykk M42111 for å starte utskrift.\r\n";
                button_Send.Enabled = true;
                button_Start.Text = "Stop";
            }
            catch (Exception ex)
            {
                textBox_RS232.Text = ex.Message;
            }
        }

        public void StopRS232()
        {
            try
            {

                if (config.Debug)
                    MessageBox.Show(textBox_RS232.Text);
                
                matchText(textBox_RS232.Text);
                mySerialPort.Close();

                textBox_RS232.Text = "Utskrift stoppet\r\n" + Environment.NewLine;
            }
            catch (Exception ex)
            {
                textBox_RS232.Text = ex.Message;
            }
        }

        public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            Thread.Sleep(500);
            string indata = sp.ReadExisting();
            this.BeginInvoke(new SetTextDeleg(DisplayToUI), new object[] { indata });
        }

        private void DisplayToUI(string displayData)
        {
            textBox_RS232.Text += displayData;
            
            // Scroll down
            textBox_RS232.SelectionStart = textBox_RS232.Text.Length;
            textBox_RS232.ScrollToCaret();
            textBox_RS232.Refresh();
        }

        public void SendStringRS232(string msg)
        {
            try
            {
                // If debug is true then send test log insted
                if (config.Debug)
                {
                    // Write test log for DA systems
                    foreach (var line in Testing.daLog())
                    {
                        mySerialPort.Write(line);
                    }

                    // Write test log for DA Quad systems
                    foreach (var line in Testing.daqLog())
                    {
                        mySerialPort.Write(line);
                    }
                }
                else
                {
                    mySerialPort.Write(msg + "\r\n");
                }
            }
            catch (Exception ex)
            {
                textBox_RS232.Text = ex.Message;
            }
        }
        
        #endregion

        #region Controls

        // Show all values
        private void checkBox_ShowAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ShowAll.Checked)
            {
                // Apollo/Quad
                groupBox_Settings.Text = "Analogverdi/Nedsmussingsgrad";
                checkBox_Quad.Checked = false;
                numericUpDown_Low.Enabled = false;
                numericUpDown_High.Enabled = false;
                numericUpDown_Low.Value = 99;
                numericUpDown_High.Value = 0;
            }
            else
            {
                // And back to Apollo
                groupBox_Settings.Text = "Analogverdi";
                numericUpDown_Low.Enabled = true;
                numericUpDown_High.Enabled = true;
                numericUpDown_High.Value = config.NumericUpDown_High;
                numericUpDown_Low.Value = config.NumericUpDown_Low;
            }
        }

        private void checkBox_Quad_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Quad.Checked)
            {
                // Set groupbox/num to quad setting
                checkBox_ShowAll.Checked = false;
                groupBox_Settings.Text = "Nedsmussingsgrad";
                label1.Text = "% (eller mindre)";
                numericUpDown_High.Enabled = false;
                numericUpDown_Low.Value = 50; // What is the highest allowed value here??
                numericUpDown_High.Value = 0;
                numericUpDown_High.Visible = false;
            }
            else
            {
                // Set groupbox/num up for apollo setting
                groupBox_Settings.Text = "Analogverdi";
                label1.Text = "-";
                numericUpDown_High.Enabled = true;
                numericUpDown_High.Value = config.NumericUpDown_High;
                numericUpDown_Low.Value = config.NumericUpDown_Low;
                numericUpDown_High.Visible = true;
            }
        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            SendStringRS232(textBox_Send.Text);
            textBox_Send.Text = "";
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            if (button_Start.Text == "Start")
            {
                StartRS232();
            }
            else
            {
                StopRS232();
                button_Send.Enabled = false;
                button_Start.Text = "Start";
            }
        }

        //Save numericUpDown values
        private void numericUpDown_High_ValueChanged(object sender, EventArgs e)
        {
            // Don't save value if Quad or ShowAll is checked
            if (!checkBox_ShowAll.Checked && !checkBox_Quad.Checked)
            {
                config.NumericUpDown_High = (int)numericUpDown_High.Value;
            }
        }

        //Save numericUpDown values
        private void numericUpDown_Low_ValueChanged(object sender, EventArgs e)
        {
            // Don't save value if Quad or ShowAll is checked
            if (!checkBox_ShowAll.Checked && !checkBox_Quad.Checked)
            {
                config.NumericUpDown_Low = (int)numericUpDown_Low.Value;
            }
        }

        #endregion

    }
}
