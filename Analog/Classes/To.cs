using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Analog.Classes
{
    class To
    {
        public static int? int32(string input)
        {
            int numValue;
            bool parsed = Int32.TryParse(input, out numValue);

            if (!parsed)
                return null;

            return numValue;
        }
    }
}
