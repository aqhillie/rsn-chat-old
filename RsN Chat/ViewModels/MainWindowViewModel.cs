using Prism.Commands;
using System.ComponentModel;
using System.Windows;
using RsN_Chat.Models;
using System.Linq;
using System.Collections.Generic;

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
                ChatCommandString = "";
            }
        }

        private void PerformChatCommand(string command, List<string> args)
        {
        }

        private void PerformMenuAction(string action)
        {
            if (action == "About")
            {
                MessageBox.Show("RsN Chat written by Alexander Rose.", "About RsN Chat");
            }
        }
    }
}
