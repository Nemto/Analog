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
using System.Web.Script.Serialization; //REF:System.Web.Ext

namespace Analog
{
    /// <summary>
    /// Kilder:
    /// http://stackoverflow.com/questions/5525181/find-each-regex-match-in-string
    /// http://stackoverflow.com/questions/5101217/rs232-serial-port-communication-c-sharp-win7-net-framework-3-5-sp1
    /// </summary>
    /// 
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            deserializeSettings();
            textBox_ComPort.Text = serialPort;
        }
        

        private int feilTeller;
        private string versjon = Assembly.GetExecutingAssembly().GetName().Version.ToString();
       
        //instillinger
        private string regexPattern;
        private string serialPort;
        private int baudRate;
        private int dataBits;
        private int readTimeout;
        private int writeTimeout;
        private bool debug;
        private bool dtrEnable;
        private bool rtsEnable;

        /// <summary>
        /// Tools
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int convertToInt32(string input)
        {
            int numValue;
            bool parsed = Int32.TryParse(input, out numValue);

            if (!parsed)
                MessageBox.Show(string.Format("Int32.TryParse could not parse '{0}' to an int.\n", input));

            return numValue;
        }

        public void deserializeSettings()
        {
            var s = new Properties.Settings();

            //RS232
            serialPort = s.SerialPort;
            baudRate = s.BaudRate;
            dataBits = s.DataBits;
            readTimeout = s.ReadTimeout;
            writeTimeout = s.WriteTimeout;
            dtrEnable = s.DtrEnable;
            rtsEnable = s.RtsEnable;

            //App
            if(debug = s.Debug)
                this.Text += " [Debug]";
            regexPattern = s.Regex;
        }

        /// <summary>
        /// Feilteller
        /// </summary>
        private void countErrors()
        {
            if (feilTeller == 0)
                populateGrid(feilTeller.ToString(), "feil funnet", null, null, null, Color.YellowGreen); 
            else
                populateGrid(feilTeller.ToString(), "feil funnet", null, null, null, Color.Red);
        }


        /// <summary>
        /// Åpne fil
        /// </summary>
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


        /// <summary>
        /// Regex
        /// </summary>
        /// <param name="input"></param>
        private void matchText(string input)
        {

            var regex = new Regex(regexPattern, RegexOptions.IgnoreCase);

            string detektorAdresse;
            string detektorType;
            int forvarselGrense;
            int alarmGrense;
            int analogvedi;
  

            foreach (Match match in regex.Matches(input))
            {

                detektorAdresse = match.Groups[4].Value + match.Groups[5].Value;
                detektorType = match.Groups[6].Value.Replace("|", "ø");
                forvarselGrense = convertToInt32(match.Groups[2].Value);    //int
                alarmGrense = convertToInt32(match.Groups[3].Value);        //int
                analogvedi = convertToInt32(match.Groups[1].Value);         //int

                if (analogvedi < numericUpDown_Low.Value || analogvedi > numericUpDown_High.Value)
                {
                    populateGrid(detektorAdresse, detektorType, forvarselGrense, alarmGrense, analogvedi, Color.White);
                    feilTeller++;
                }
            }

            if (!checkBox_ShowAll.Checked)
                countErrors();
        }

        
        /// <summary>
        /// Vis alle verdier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ShowAll.Checked)
            {
                numericUpDown_Low.Enabled = false;
                numericUpDown_High.Enabled = false;
                numericUpDown_Low.Value = 99;
                numericUpDown_High.Value = 0;
            }
            else
            {
                numericUpDown_Low.Enabled = true;
                numericUpDown_High.Enabled = true;
                numericUpDown_Low.Value = 16;
                numericUpDown_High.Value = 30;
            }
        }


        /// <summary>
        /// Sett in i Datagrid
        /// </summary>
        /// <param name="addresse"></param>
        /// <param name="detektortype"></param>
        /// <param name="prealarm"></param>
        /// <param name="alarm"></param>
        /// <param name="analogverdi"></param>
        /// <param name="color"></param>
        private void populateGrid(string addresse, string detektortype, int? prealarm, int? alarm, int? analogverdi, Color color)
        {
            DataGridViewRow row1 = (DataGridViewRow)dataGridView1.Rows[0].Clone();

            row1.Cells[0].Value = addresse;             //loop+adress
            row1.Cells[1].Value = detektortype;         //type
            row1.Cells[2].Value = prealarm;             //pre-al
            row1.Cells[3].Value = alarm;                //alarm
            row1.Cells[4].Value = analogverdi;          //value
            row1.DefaultCellStyle.BackColor = color;    //rowcolor

            // make row grey if alarm is 99 or 0
            if (alarm == 0 || alarm == 99)
            {
                row1.DefaultCellStyle.BackColor = Color.LightGray;
                row1.Cells[1].Value += " (fjernet?)";
            }

            dataGridView1.Rows.Add(row1);
        }


        /// <summary>
        /// Meny: Fil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void åpneFilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            feilTeller = 0;
            selectFile_show();
        }

        private void tømVinduToolStripMenuItem_Click(object sender, EventArgs e)
        {
            feilTeller = 0;
            dataGridView1.Rows.Clear();
        }

        private void lagreSomToolStripMenuItem_Click(object sender, EventArgs e)
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


        /// <summary>
        /// Meny: Hjelp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hyperterminalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("- Sett EEPROM 80D5 i OP til 01\n" +
                            "- COM-port settes til 05-01-01\n\n" +
                            "- Trykk på Start kappen i dette programmet.\n"+
                            "- Trykk M:4:2:1:1:1:<velg sløyfe>:* for å starte utskrift.\n" +
                            "- Når når utskriften er ferdig trykker du på Stopp knappen for å filtrere ut adresser med for høy/lav analog verdi.", "Oppsett");
        }
        private void omToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Versjon: " + versjon + "\nStian E.S", "Om M42111");
        }


        /// <summary>
        /// RS232
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private delegate void SetTextDeleg(string data);
        public SerialPort mySerialPort;
        public void StartRS232()
        {
            try
            {
                mySerialPort = new SerialPort(textBox_ComPort.Text);

                mySerialPort.BaudRate = baudRate;
                mySerialPort.Parity = Parity.None;
                mySerialPort.StopBits = StopBits.One;
                mySerialPort.DataBits = dataBits;
                mySerialPort.Handshake = Handshake.None;
                mySerialPort.ReadTimeout = readTimeout;
                mySerialPort.WriteTimeout = writeTimeout;

                mySerialPort.DtrEnable = dtrEnable;
                mySerialPort.RtsEnable = rtsEnable;

                mySerialPort.Open();
                mySerialPort.DataReceived += DataReceivedHandler;
                
                textBox_RS232.Text = "Klar!" + Environment.NewLine;
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
                //dataGridView1.Rows.Clear();

                if(debug)
                    MessageBox.Show(textBox_RS232.Text);
                
                matchText(textBox_RS232.Text);
                mySerialPort.Close();

                textBox_RS232.Text = "Stoppet.. " + Environment.NewLine;
            }
            catch (Exception ex)
            {
                textBox_RS232.Text = ex.Message;
            }
        }

        public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            System.Threading.Thread.Sleep(500);
            string indata = sp.ReadExisting();
            this.BeginInvoke(new SetTextDeleg(DisplayToUI), new object[] { indata });
        }

        private void DisplayToUI(string displayData)
        {
            textBox_RS232.Text += displayData;
            
            //scroll down
            textBox_RS232.SelectionStart = textBox_RS232.Text.Length;
            textBox_RS232.ScrollToCaret();
            textBox_RS232.Refresh();
        }

        public void SendStringRS232(string msg)
        {
            try
            {
                if (debug)
                {
                    mySerialPort.WriteLine("ANALOGVERDI=14   FORVARSEL=45   ALARM=55\r\n");
                    mySerialPort.WriteLine("ADR.:13.001 N|dlys                    90\r\n");
                    mySerialPort.WriteLine("TID: 17.28                   DATO: 16/06\r\n");
                    mySerialPort.WriteLine("---\r\n");
                    mySerialPort.WriteLine("ANALOGVERDI=25   FORVARSEL=45   ALARM=55\r\n");
                    mySerialPort.WriteLine("ADR.:13.002 N|dlys                    90\r\n");
                    mySerialPort.WriteLine("TID: 17.28                   DATO: 16/06\r\n");
                    mySerialPort.WriteLine("---\r\n");
                    mySerialPort.WriteLine("ANALOGVERDI=00   FORVARSEL=45   ALARM=00\r\n");
                    mySerialPort.WriteLine("ADR.:13.003 N|dlys                    90\r\n");
                    mySerialPort.WriteLine("TID: 17.28                   DATO: 16/06\r\n");
                    mySerialPort.WriteLine("---\r\n");
                    mySerialPort.WriteLine("ANALOGVERDI=16   FORVARSEL=45   ALARM=55\r\n");
                    mySerialPort.WriteLine("ADR.:13.004 N|dlys                    90\r\n");
                    mySerialPort.WriteLine("TID: 17.28                   DATO: 16/06\r\n");
                    mySerialPort.WriteLine("---\r\n");
                    mySerialPort.WriteLine("ANALOGVERDI=38   FORVARSEL=45   ALARM=55\r\n");
                    mySerialPort.WriteLine("ADR.:13.05 N|dlys                     90\r\n");
                    mySerialPort.WriteLine("TID: 17.28                   DATO: 16/06\r\n");
                    mySerialPort.WriteLine("---\r\n");
                    mySerialPort.WriteLine("ANALOGVERDI=04   FORVARSEL=45   ALARM=55\r\n");
                    mySerialPort.WriteLine("ADR.:1306 N|dlys                      90\r\n");
                    mySerialPort.WriteLine("TID: 17.28                   DATO: 16/06\r\n");
                    mySerialPort.WriteLine("---\r\n");
                }
                else
                {
                    mySerialPort.WriteLine(msg + "\r\n");
                }
            }
            catch (Exception ex)
            {
                textBox_RS232.Text = ex.Message;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SendStringRS232(textBox_Send.Text);
            textBox_Send.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
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

        private void instillingerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }

    }
}
