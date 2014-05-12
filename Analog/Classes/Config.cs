using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Analog.Properties;

namespace Analog.Classes
{
    class Config
    {
        Settings s = new Properties.Settings();

        #region RS232 Settings
        public string SerialPort
        {
            get
            {
                return s.SerialPort;
            }
            set 
            {
                s.SerialPort = value;
                s.Save();
            }
        }

        public int BaudRate
        {
            get
            {
                return s.BaudRate;
            }
            set
            {
                s.BaudRate = value;
                s.Save();
            }
        }

        public int DataBits
        {
            get
            {
                return s.DataBits;
            }
            set
            {
                s.DataBits = value;
                s.Save();
            }
        }

        public int ReadTimeout
        {
            get
            {
                return s.ReadTimeout;
            }
            set
            {
                s.ReadTimeout = value;
                s.Save();
            }
        }

        public int WriteTimeout
        {
            get
            {
                return s.WriteTimeout;
            }
            set
            {
                s.WriteTimeout = value;
                s.Save();
            }
        }

        public bool DtrEnable
        {
            get
            {
                return s.DtrEnable;
            }
            set
            {
                s.DtrEnable = value;
                s.Save();
            }
        }

        public bool RtsEnable
        {
            get
            {
                return s.RtsEnable;
            }
            set
            {
                s.RtsEnable = value;
                s.Save();
            }
        }
        #endregion

        #region Application Settings

        public int ErrorCount;

        public bool AutoUpdate
        {
            get
            {
                return s.AutoUpdate;
            }
            set
            {
                s.AutoUpdate = value;
                s.Save();
            }
        }

        public bool Debug
        {
            get
            {
                return s.Debug;
            }
            set
            {
                s.Debug = value;
                s.Save();
            }
        }

        public string Regex
        {
            get
            {
                return s.Regex;
            }
            set
            {
                s.Regex = value;
                s.Save();
            }
        }

        public int NumericUpDown_High
        {
            get
            {
                return s.NumericUpDown_High;
            }
            set
            {
                s.NumericUpDown_High = value;
                s.Save();
            }
        }

        public int NumericUpDown_Low
        {
            get
            {
                return s.NumericUpDown_Low;
            }
            set
            {
                s.NumericUpDown_Low = value;
                s.Save();
            }
        }
        #endregion

    }
}
