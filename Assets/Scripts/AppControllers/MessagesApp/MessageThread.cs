using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Messages
{
    public class MessageThread
    {
        public string Participant;
        public string MessageSnippet;
        public string PhoneNumber;
        public List<Message> Messages = new List<Message>();
    }
}
