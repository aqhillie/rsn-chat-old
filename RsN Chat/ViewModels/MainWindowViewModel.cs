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
using System.IO;

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

            if (IrcSettings.Set.autoload_scripts)
            {
                if (!Directory.Exists(IrcSettings.Set.autoload_dir))
                {
                    Directory.CreateDirectory(IrcSettings.Set.autoload_dir);
                }

                string[] scripts = Directory.GetFiles(IrcSettings.Set.autoload_dir, "*.irc", SearchOption.AllDirectories);

                if (scripts.Length > 0)
                {
                    MainChannel.EchoList(Commands.ProcessCommand("load", scripts.ToList()));
                }
                else
                {
                    MainChannel.Echo(IrcSettings.Set.banner + "No scripts to load.");
                }
            }

            MainChannel.Echo(IrcSettings.Set.banner + "Welcome to");
            MainChannel.EchoList(AsciiLogos.Logo2());

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
