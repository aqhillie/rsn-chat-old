using Prism.Commands;
using System.ComponentModel;
using System.Windows;
using RsN_Chat.Classes;
using RsN_Chat.Models;
using RsN_Chat.Views;
using RsN_Chat.Properties;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System;

namespace RsN_Chat.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DelegateCommand<string> MenuCommand { get; set; }

        public Channel MainChannel { get; set; }

        public MainWindowViewModel()
        {
            MainChannel = new Channel();
            MainChannel.Echo("Welcome to");
            AsciiLogos.Logo2(MainChannel);

            MenuCommand = new DelegateCommand<string>(
                command => { PerformMenuAction(command); }, // OnExecute
                command => { return true; } // CanExecute
            );
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
