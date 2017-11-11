using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RsN_Chat.Models
{
    public class ChatMessage
    {
        protected bool _deleted = false;
        protected string _message;

        public User Sender { get; set; }
        public string Message
        {
            get
            {
                return (_deleted) ? "<Message Deleted>" : _message;
            }
        }

        public ChatMessage(User sender, string message)
        {
            Sender = sender;
            _message = message;
        }

        public void Delete()
        {
            _deleted = true;
        }
    }

    public class ChatMessagePublic : ChatMessage
    {
        public ChatMessagePublic(User sender, string message) : base(sender, message) { }
    }

    public class ChatMessageMe : ChatMessage
    {
        public ChatMessageMe(User sender, string message) : base(sender, message) { }
    }

    public class ChatMessageSystem : ChatMessage
    {
        // System messages can't be deleted.
        public new string Message
        {
            get
            {
                return _message;
            }
        }

        public ChatMessageSystem(User sender, string message) : base(sender, message) { }
    }
}
