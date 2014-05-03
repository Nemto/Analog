using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Analog.Classes
{
    class Debug
    {
        public static List<string> testPrint()
        {
            List<string> list = new List<string>();
            list.Add("ANALOGVERDI=14   FORVARSEL=45   ALARM=55\r\n");
            list.Add("ADR.:13.001 Optisk Detektor           XP\r\n");
            list.Add("TID: 17.28                   DATO: 16/06\r\n");
            list.Add("---\r\n");
            list.Add("ANALOGVERDI=38   FORVARSEL=45   ALARM=55\r\n");
            list.Add("ADR.:13.002 Varme Detektor            XP\r\n");
            list.Add("TID: 17.28                   DATO: 16/06\r\n");
            list.Add("---\r\n");
            list.Add("ANALOGVERDI=00   FORVARSEL=45   ALARM=00\r\n");
            list.Add("ADR.:13.003 N|dlys                    90\r\n");
            list.Add("TID: 17.28                   DATO: 16/06\r\n");
            list.Add("---\r\n");
            list.Add("ANALOGVERDI=16   FORVARSEL=45   ALARM=55\r\n");
            list.Add("ADR.:13.004 Manuell Melder            90\r\n");
            list.Add("TID: 17.28                   DATO: 16/06\r\n");
            list.Add("---\r\n");
            list.Add("ANALOGVERDI=38   FORVARSEL=45   ALARM=55\r\n");
            list.Add("ADR.:13.05 N|dlys                     90\r\n");
            list.Add("TID: 17.28                   DATO: 16/06\r\n");
            list.Add("---\r\n");
            list.Add("ANALOGVERDI=04   FORVARSEL=45   ALARM=55\r\n");
            list.Add("ADR.:1306 N|dlys                      90\r\n");
            list.Add("TID: 17.28                   DATO: 16/06\r\n");
            list.Add("---\r\n");

            return list;
        }
    }
}
