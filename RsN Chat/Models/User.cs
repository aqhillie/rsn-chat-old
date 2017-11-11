using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RsN_Chat.Models
{
    public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Username { get; private set; }
        public string Nickname { get; private set; }
        public string Color { get; private set; }

        public User(string _username, string _color)
        {
            Username = _username;
            Nickname = _username;
            Color = _color;
        }


        public void setNickname(string name)
        {
            Nickname = name;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Nickname"));
            }
        }
    }
}
