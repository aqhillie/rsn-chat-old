using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;

namespace RsN_Chat.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DelegateCommand<string> MenuCommand { get; set; }

        public MainWindowViewModel()
        {
            MenuCommand = new DelegateCommand<string>(
                command => { PerformMenuAction(command); }, // OnExecute
                command => { return true; } // CanExecute
            );
        }

        private void PerformMenuAction(string action)
        {
            if (action == "About")
            {
                MessageBox.Show("RSN Chat written by Alexander Rose.", "About RsN Chat");
            }
        }
    }
}
