using Prism.Commands;
using System.ComponentModel;
using System.Windows;
using RsN_Chat.Models;
using RsN_Chat.Views;
using RsN_Chat.Properties;
using System.Linq;
using System.Collections.Generic;
using System;

namespace RsN_Chat.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string ChatCommandString { get; set; }

        public DelegateCommand<string> ChatCommand { get; set; }
        public DelegateCommand<string> MenuCommand { get; set; }

        public Channel MainChannel { get; set; }

        public MainWindowViewModel()
        {
            MainChannel = new Channel();
            MainChannel.AddChatLine(MainChannel.MyUser, "ChatLinePublic", "Welcome to RsN Chat!");

            ChatCommand = new DelegateCommand<string>(
                command => { PerformChatAction(); }, // OnExecute
                command => { return true; } // CanExecute
            );

            MenuCommand = new DelegateCommand<string>(
                command => { PerformMenuAction(command); }, // OnExecute
                command => { return true; } // CanExecute
            );
        }

        private void PerformChatAction()
        {
            if (ChatCommandString[0] == '/')
            {
                string cmdString = ChatCommandString.Substring(1);
                List<string> args = cmdString.Split(' ').ToList();
                string command = args.First();
                args.RemoveAt(0);
                PerformChatCommand(command, args);
            }
            else
            {
                MainChannel.AddChatLine(MainChannel.MyUser, "ChatLinePublic", ChatCommandString);
            }
#if DEBUG
            Console.WriteLine("Clearing ChatCommandString");
            Console.WriteLine("Before: " + ChatCommandString);
#endif
            ChatCommandString = "";
#if DEBUG
            Console.WriteLine("CMS: " + ChatCommandString);
#endif
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("ChatCommandString"));
            }
        }

        private void PerformChatCommand(string command, List<string> args)
        {
            if (command.ToLower() == "nick")
            {
                Settings.Default.Nickname = args[0];
                MainChannel.MyUser.setNickname(Settings.Default.Nickname);
            }
        }

        private void PerformMenuAction(string action)
        {
            if (action == "About")
            {
                AboutRsNChat about = new AboutRsNChat();
                about.ShowDialog();
            }
        }
    }
}
