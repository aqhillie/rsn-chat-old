using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RsN_Chat.Models
{
    public class ChatMessage
    {
        private bool _deleted = false;
        private string _message;

        public User Sender { get; set; }
        public string Type { get; set; }
        public string Message
        {
            get
            {
                return (_deleted) ? "<Message Deleted>" : _message;
            }
        }

        public ChatMessage(User sender, string type, string message)
        {
            Sender = sender;
            Type = type;
            _message = message;
        }

        public void delete()
        {
            _deleted = true;
        }
    }
}
