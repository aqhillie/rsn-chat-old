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
            MainChannel.Echo("Welcome to");
            AsciiLogos.Logo2(MainChannel);

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
                MainChannel.AddChatLine(MainChannel.MyUser, "Public", ChatCommandString);
            }

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("ChatCommandString"));
            }
        }

        private void PerformChatCommand(string command, List<string> args)
        {
            switch(command.ToLower())
            {
                case "nick":
                    Settings.Default.Nickname = args[0];
                    MainChannel.MyUser.SetNickname(Settings.Default.Nickname);
                    MainChannel.Echo("Nickname changed to " + MainChannel.MyUser.Nickname + ".");
                    break;
                case "me":
                    MainChannel.AddChatLine(MainChannel.MyUser, "Me", " " + string.Join(" ", args));
                    break;
            }
        }

        private void PerformMenuAction(string action)
        {
            switch(action)
            {
                case "About":
                    AboutRsNChat about = new AboutRsNChat();
                    about.ShowDialog();
                    break;
            }
        }
    }
}
