using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;
using Analog.Classes;

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

            // Check for new release if AutoUpdate is true
            if (config.AutoUpdate && !config.Restart)
                checkRelease();

            UpdateUI();
        }


        public void UpdateUI()
        {
            if (config.Debug)
                this.Text = "Analog [Debug]";
            else
                this.Text = "Analog";

            groupBox_RS232.Text = string.Format("RS232 ({0})", config.SerialPort);
            numericUpDown_High.Value = config.NumericUpDown_High;
            numericUpDown_Low.Value = config.NumericUpDown_Low;
            config.Restart = false;
        }

        // Check for new releases
        public void checkRelease(bool showResponse = false)
        {
            var url = "https://github.com/Nemto/Analog/releases";
            var currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            if (Upgrade.Check(currentVersion))
                if (MessageBox.Show("En ny oppdatering er tilgjengelig!\n Vil du laste ned nå?\n\n" + url, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    Process.Start(url);
            
            if (showResponse)
                MessageBox.Show("Ingen nye oppdateringer.");
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
        private void populateGrid(string detectorAddress, string detektorType, int? preAlarm, int? alarm, int? value, Color color)
        {
            var row1 = (DataGridViewRow) dataGridView1.Rows[0].Clone();

            row1.Cells[0].Value = detectorAddress;      //loop+adress
            row1.Cells[1].Value = detektorType;         //type
            row1.Cells[2].Value = preAlarm;             //pre-al
            row1.Cells[3].Value = alarm;                //alarm
            row1.Cells[4].Value = value;                //value
            row1.DefaultCellStyle.BackColor = color;    //rowcolor

            // Paint it grey if alarm is 99 or 0
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

        private void SaveFileShow()
        {
            var dateTime = DateTime.Now;

            using(saveFileDialog1)
            {
                saveFileDialog1.Filter = "All files (*.*)|*.*";
                saveFileDialog1.FileName = "analog_" + dateTime.ToString("ddMMyyhhmm") + ".csv";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if(saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var filePath = saveFileDialog1.FileName.ToString();
                    try
                    {
                        using (var sw = new StreamWriter(filePath, false))
                        {
                            var columnCount = dataGridView1.ColumnCount - 1;
                            var columnHeader = "";

                            // Write coulumn headers to file
                            if (columnCount >= 0)
                                columnHeader = dataGridView1.Columns[0].HeaderText;

                            for (int i = 0; i <= columnCount; i++)
                                columnHeader = columnHeader + ";" + dataGridView1.Columns[i].HeaderText;
                            sw.WriteLine(columnHeader);
                            /* fix
                            // Write datagridrow data to file
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    var rowData = row.Cells[0].Value.ToString();
                                    for (int i = 1; i <= columnCount; i++)
                                        rowData = rowData + ";" + row.Cells[i].Value.ToString();
                                    sw.WriteLine(rowData);
                                }
                            }
                             */
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
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
            SaveFileShow();
        }
        #endregion

        #region Menu: Help

        // About
        private void omToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = "README.txt";
            MessageBox.Show(fileName);
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
            if (settings.ShowDialog() == DialogResult.OK)
            {
                config.Restart = true;
                Application.Restart();
            }
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
                mySerialPort.ReadTimeout = config.ReadTimeout;
                mySerialPort.WriteTimeout = config.WriteTimeout;
                mySerialPort.DataBits = config.DataBits;
                mySerialPort.DtrEnable = config.DtrEnable;
                mySerialPort.RtsEnable = config.RtsEnable;
                mySerialPort.BaudRate = config.BaudRate;
                mySerialPort.Parity = Parity.None;
                mySerialPort.StopBits = StopBits.One;
                mySerialPort.Handshake = Handshake.None;

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
