using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Messages
{
    public class MessageThread
    {
        public string Participant;
        public string LatestMessage => Messages.First().MessageText.Substring(0, Math.Min(Messages.First().MessageText.Length, 50));

        public List<Message> Messages = new List<Message>();
    }
}
