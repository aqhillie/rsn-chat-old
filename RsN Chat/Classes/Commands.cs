using RsN_Chat.Models;
using RsN_Chat.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Reflection;

namespace RsN_Chat.Classes
{
    public static class Commands
    {

        public static List<string> ProcessCommand(string command, List<string> args)
        {
            List<string> command_output = new List<string>();

            switch (command.ToLower())
            {
                case "#":
                case "comment":
                    // Nothing to do here
                    break;
                case "about":
                    command_output = About();
                    break;
                case "alias":
                    command_output = Alias(args);
                    break;
                case "away":
                    command_output = Away(args);
                    break;
                case "clear":
                    //May have this in a seperate area called UI commands, maybe not
                    //Channel.ClearChat();
                    break;
                case "load":
                    command_output = Load(args);
                    break;
                case "nick":
                    command_output = Nick(args);
                    break;
                case "me":
                    command_output = Me(args);
                    break;
            }

            return command_output;
        }

        public static List<string> About()
        {
            List<string> say = new List<string>();

            string description = ((AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyDescriptionAttribute), false)).Description;
            string[] array = description.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            for (int i = 0; i < array.Length; i++)
            { 
                say.Add(IrcSettings.Set.banner + array[i]);
            }

            return say;
        }

        public static List<string> Alias(List<string> args)
        {
            List<string> say = new List<string>();

            if (args.Count == 0)
            {
                say.Add("*** Aliases:");

                foreach (var alias in IrcSettings.Aliases.ToArray())
                {
                    List<string> alias_args = alias.Value.Split(' ').ToList();
                    string cmd = alias_args[0].ToUpper();
                    alias_args.RemoveAt(0);

                    say.Add("*** [" + alias.Key + "] " + cmd + " " + string.Join(" ", alias_args));
                }
            }
            else
            {
                string alias = args.First();
                if (args.Count == 0)
                {
                    List<string> alias_args = IrcSettings.Aliases[alias.ToUpper()].Split(' ').ToList();
                    string cmd = alias_args[0].ToUpper();
                    alias_args.RemoveAt(0);

                    say.Add("*** [" + alias.ToUpper() + "] " + cmd + " " + string.Join(" ", alias_args));
                }
                else
                {
                    args.RemoveAt(0);
                    IrcSettings.Aliases.Add(alias.ToUpper(), string.Join(" ", args));
                }
            }

            return say;
        }

        public static List<string> Away(List<string> args)
        {
            List<string> say = new List<string>();

            // Not sure if Twitch supports /away. If not this may just be a
            // local version that supports the answering machine

            if (args.Count == 0)
            {
                // turn away off
                say.Add("*** You are no longer set as being away.");
            }
            else
            {
                // turn away on
                say.Add("*** You have been marked as being away.");
            }

            return say;
        }

        public static List<string> Load(List<string> args)
        {
            List<string> say = new List<string>();

            for (int i = 0; i < args.Count; i++)
            {
                say.Add(IrcSettings.Set.banner + "Loading \"" + args[i] + "\"...");
                foreach (string line in File.ReadAllLines(args[i]))
                {
                    List<string> cmd_args = line.Split(' ').ToList();
                    string cmd = cmd_args[0];
                    cmd_args.RemoveAt(0);

                    Commands.ProcessCommand(cmd, cmd_args);
                }
            }

            return say;
        }

        public static List<string> Me(List<string> args)
        {
            List<string> say = new List<string>();

            // IRC SERVER ME CODE HERE

            say.Add("* " + IrcSettings.UserNick + string.Join(" ", args));

            return say;
        }

        public static List<string> Nick(List<string> args)
        {
            List<string> say = new List<string>();

            IrcSettings.UserNick = args[0];
            say.Add("*** Nickname changed to " + args[0] + ".");

            return say;
        }
    }
}
