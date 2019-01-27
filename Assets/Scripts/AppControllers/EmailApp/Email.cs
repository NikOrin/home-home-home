using System;
using UnityEngine;

namespace Application.Email
{
    public class Email
    {
        public string Sender;
        public string MessageText;
        public string Subject;
        public DateTime SentOn;
        public GameObject OpenEmail;
        public string StoryKey;
        public Email()
        {
        }
    }
}
