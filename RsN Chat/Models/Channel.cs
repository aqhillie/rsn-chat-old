﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Text;
using System.Threading.Tasks;
using RsN_Chat.ViewModels;
using RsN_Chat.Models;
using RsN_Chat.Properties;
using System.Windows.Data;

namespace RsN_Chat.Models
{
    public class Channel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public User MyUser = new User(Settings.Default.Username, Settings.Default.UserColor);

        private SortedList<string, User> _users;
        public List<User> Users {
            get
            {
                return _users.Values.ToList();
            }
        }

        public List<Object> Chat { get; set; }

        public Channel()
        {
            _users = new SortedList<string,User>();

            AddUser(MyUser);
            AddUser(new User("JayMartini", "Purple"));
            AddUser(new User("greekhotfunx2", "Green"));
            AddUser(new User("meander25", "Gray"));
            AddUser(new User("Johnson", "Blue"));
            AddUser(new User("JackRabbitSlim", "Brown"));
            AddUser(new User("JimmysChickenShack", "Brown"));
            AddUser(new User("mobafan88", "Gray"));
            AddUser(new User("YourNo1Fan", "Blue"));
            AddUser(new User("NoobPatrol", "Red"));
            AddUser(new User("DearJohn55", "Black"));
            AddUser(new User("Mookid", "Purple"));
            AddUser(new User("JimmySixtySix", "Brown"));

            Chat = new List<Object>();
        }

        public void AddChatLine(User sender, string type, string message)
        {
            switch (type)
            {
                case "ChatLineSystem":
                    Chat.Add(new ChatMessageSystem(null, message));
                    break;
                case "ChatLinePublic":
                    Chat.Add(new ChatMessagePublic(sender, message));
                    break;
                case "ChatLineMe":
                    Chat.Add(new ChatMessageMe(sender, message));
                    break;
            }

            ICollectionView view = CollectionViewSource.GetDefaultView(Chat);
            view.Refresh();

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Chat"));
            }
        }

        private void AddUser(User user)
        {
            _users.Add(user.Nickname, user);

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Users"));
            }
        }
    }
}
