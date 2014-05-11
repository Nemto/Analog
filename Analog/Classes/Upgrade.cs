using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Analog.Classes
{
    class Upgrade
    {
        public static bool Needed(string currentVersion)
        {
            try
            {
                WebClient wc = new WebClient();
                string url = "https://github.com/Nemto/Analog/releases";
                string source = wc.DownloadString(url);

                var pattern = @"<span class=""css-truncate-target"">(.*?)</span>";
                Match match = Regex.Match(source, pattern, RegexOptions.IgnoreCase);

                if (match.Success)
                {
                    if (match.Groups[1].Value != currentVersion)
                        return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
