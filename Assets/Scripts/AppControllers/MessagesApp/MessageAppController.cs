using System.Collections;
using System.Collections.Generic;
using Application.Messages;
using UnityEngine;
using System;

public class MessageAppController : BaseAppController
{
    public List<MessageThread> MessageThreads;
    public GameObject MessageThreadPrefab;

    public int Margin;

    // Start is called before the first frame update
    void Start()
    {
        //Get messages information from story controller
        //test method for building fake data for now;
        MessageThreads = StoryController.BuildAvailableThreads();

        int height = (int)MessageThreadPrefab.GetComponent<RectTransform>().rect.height;
        int rowPointer = Screen.height/2 - TopMargin - height/2;

        Debug.Log("Message app controller");
        Debug.Log(StoryController);
        foreach (var messageThread in MessageThreads)
        {
            var thread = Instantiate(MessageThreadPrefab);
            thread.name = messageThread.Participant;
            thread.transform.SetParent(transform);
            var threadController = thread.GetComponent<MessageThreadController>();
            threadController.MessageThread = messageThread;
            thread.GetComponent<RectTransform>().localPosition = new Vector3(0, rowPointer, 0);
            rowPointer -= (height + Margin);

            if (StoryController.KeyMessages.Contains(messageThread.Participant))
                StoryController.SetMessageKey(threadController);
            threadController.StoryController = StoryController;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BuildDummyData()
    {
        MessageThreads = new List<MessageThread>();

        var thread = new MessageThread
        {
            Participant = "Mom"
        };

        var message = new Message
        {
            Sender = "Mom",
            SentOn = new DateTime(2019, 1, 26),
            MessageText = "Come home you awful child"
        };

        var message2 = new Message
        {
            Sender = "Mom",
            SentOn = new DateTime(2019, 1, 27),
            MessageText = "We have burritos"
        };

        var thread2 = new MessageThread { Participant = "Bad Coworker" };
        var comessage = new Message
        {
            Sender = "Bad Coworker",
            SentOn = new DateTime(2019, 01, 26),
            MessageText = "Hey, are you excited for some unpaid overtime?!"
        };

        thread.Messages.Add(message);
        thread.Messages.Add(message2);

        thread2.Messages.Add(comessage);

        MessageThreads.Add(thread);
        MessageThreads.Add(thread2);
    }
}
