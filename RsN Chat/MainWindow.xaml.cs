using System.Windows;
using RsN_Chat.Classes;
using RsN_Chat.Properties;
using System.ComponentModel;
using System;

namespace RsN_Chat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Settings.Default.MainWindowPlacement = WindowPlacement.GetPlacement(this);
            Settings.Default.Save();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            WindowPlacement.SetPlacement(this, Settings.Default.MainWindowPlacement);
        }

        private void CommandBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
