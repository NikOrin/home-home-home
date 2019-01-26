using System;
using System.Collections.Generic;
using Application.Messages;

namespace Application.Story
{
    public interface ICreateMessageThreads
    {
        List<MessageThread> GetMessages();
    }
}
