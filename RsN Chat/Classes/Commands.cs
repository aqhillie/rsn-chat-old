using RsN_Chat.Properties;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace RsN_Chat.Classes
{
    public static class Commands
    {
        public static List<string> Alias(List<string> args)
        {
            List<string> say = new List<string>();

            if (args.Count == 0)
            {
                say.Add("Aliases:");

                foreach (var alias in Settings.Default.Aliases.ToArray())
                {
                    List<string> alias_args = alias.Value.Split(' ').ToList();
                    string cmd = alias_args[0].ToUpper();
                    alias_args.RemoveAt(0);

                    say.Add("[" + alias.Key + "] " + cmd + " " + string.Join(" ", alias_args));
                }
            }
            else
            {
                string alias = args.First();
                if(args.Count == 0)
                {
                    List<string> alias_args = Settings.Default.Aliases[alias.ToUpper()].Split(' ').ToList();
                    string cmd = alias_args[0].ToUpper();
                    alias_args.RemoveAt(0);

                    say.Add("[" + alias.ToUpper() + "] " + cmd + " " + string.Join(" ", alias_args));
                }
                else
                {
                    args.RemoveAt(0);
                    Settings.Default.Aliases.Add(alias.ToUpper(), string.Join(" ", args));
                }
            }

            return say;
        }
    }
}
