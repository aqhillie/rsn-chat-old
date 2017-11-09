using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RsN_Chat.Models
{
    public class User
    {
        public string Username { get; private set; }
        public string Nickname { get; private set; }
        public string Color { get; private set; }

        public User(string _username, string _color)
        {
            Username = _username;
            Nickname = _username;
            Color = _color;
        }
    }
}
