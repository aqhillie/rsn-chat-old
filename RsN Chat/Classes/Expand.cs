using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RsN_Chat.Classes
{
    public static class Expand
    {
        public static List<string> DollarArgs(List<string> list, List<string> args)
        {
            string s = string.Join(" ", list);
            for (int i = 1; i <= args.Count; i++)
            {
                Regex rx = new Regex("\\$" + i);
                s = rx.Replace(s, args[i-1]);
            }

            Regex r = new Regex("\\$[0-9]");
            s = r.Replace(s, "");

            return s.Split(' ').ToList();
        }
    }
}
