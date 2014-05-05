using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Analog.Classes
{
    class Testing
    {

/*
    [0][0] = ANALOGVERDI=04 FORVARSEL=45 ALARM=55
    ADR.:1306 N|dlys 
    [0][1] = ANALOGVERDI=
    [0][2] = 04
    [0][3] = FORVARSEL=45 ALARM=55
    [0][4] = 45
    [0][5] = 55
    [0][6] = 9

    [0][7] = 13
    [0][8] = 06
    [0][9] = N|dlys
    [1][0] = NEDSMUSSINGSGRAD: 00 PROSENT
    ADR.:02.062 Optisk Detektor

    [1][1] = NEDSMUSSINGSGRAD: 
    [1][2] = 00
    [1][3] = PROSENT
    [1][4] = 
    [1][5] = 
    [1][6] = 

    [1][7] = 02.
    [1][8] = 062
    [1][9] = Optisk Detektor
*/
        public static List<string> daLog()
        {
            List<string> list = new List<string>();

            list.Add("                                        \r\n");
            list.Add("_____________TEST DA LOG________________\r\n");
            list.Add("                                        \r\n");
            list.Add("ANALOGVERDI=14   FORVARSEL=45   ALARM=55\r\n");
            list.Add("ADR.:1301 Optisk Detektor           XP\r\n");
            list.Add("TID: 17.28                   DATO: 16/06\r\n");
            list.Add("---\r\n");
            list.Add("ANALOGVERDI=38   FORVARSEL=45   ALARM=55\r\n");
            list.Add("ADR.:13.02 Varme Detektor            XP\r\n");
            list.Add("TID: 17.28                   DATO: 16/06\r\n");
            list.Add("---\r\n");
            list.Add("ANALOGVERDI=00   FORVARSEL=45   ALARM=00\r\n");
            list.Add("ADR.:13.003 N|dlys                    90\r\n");
            list.Add("TID: 17.28                   DATO: 16/06\r\n");
            list.Add("---\r\n");
            list.Add("ANALOGVERDI=00   FORVARSEL=45   ALARM=99\r\n");
            list.Add("ADR.:13.004 Manuell Melder            90\r\n");
            list.Add("TID: 17.28                   DATO: 16/06\r\n");
            list.Add("---\r\n");
            list.Add("ANALOGVERDI=38   FORVARSEL=45   ALARM=55\r\n");
            list.Add("ADR.:13.005 N|dlys                     90\r\n");
            list.Add("TID: 17.28                   DATO: 16/06\r\n");
            list.Add("---\r\n");
            list.Add("ANALOGVERDI=04   FORVARSEL=45   ALARM=55\r\n");
            list.Add("ADR.:13.006 Optisk Detektor           90\r\n");
            list.Add("TID: 17.28                   DATO: 16/06\r\n");
            list.Add("---\r\n");

            return list;
        }

        public static List<string> daqLog()
        {
            List<string> list = new List<string>();
            list.Add("                                        \r\n");
            list.Add("_____________TEST DAQ LOG_______________\r\n");
            list.Add("                                        \r\n");
            list.Add("NEDSMUSSINGSGRAD: 00 PROSENT            \r\n");
            list.Add("ADR.:02.016 Optisk Detektor             \r\n");
            list.Add("TID: 13.01                   DATO: 05/05\r\n");
            list.Add("  ---\r\n");
            list.Add("NEDSMUSSINGSGRAD: 10 PROSENT            \r\n");
            list.Add("ADR.:02.017 Optisk Detektor             \r\n");
            list.Add("TID: 13.02                   DATO: 05/05\r\n");
            list.Add("  ---\r\n");
            list.Add("NEDSMUSSINGSGRAD: 20 PROSENT            \r\n");
            list.Add("ADR.:02.018 Optisk Detektor             \r\n");
            list.Add("TID: 13.03                   DATO: 05/05\r\n");
            list.Add("  ---\r\n");
            list.Add("NEDSMUSSINGSGRAD: 55 PROSENT            \r\n");
            list.Add("ADR.:02.019 Optisk Detektor             \r\n");
            list.Add("TID: 13.04                   DATO: 05/05\r\n");
            list.Add("  ---\r\n");
            list.Add("NEDSMUSSINGSGRAD: 97 PROSENT            \r\n");
            list.Add("ADR.:02.020 Optisk Detektor             \r\n");
            list.Add("TID: 13.05                   DATO: 05/05\r\n");
            list.Add("  ---\r\n");
            return list;
            
        }
    }
}
