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

        BuildMessageThreads();
    }

    public void BuildMessageThreads()
    {        int height = (int)MessageThreadPrefab.GetComponent<RectTransform>().rect.height;
        int rowPointer = Screen.height / 2 - TopMargin - height / 2;

        foreach (var messageThread in MessageThreads)
        {
            var thread = Instantiate(MessageThreadPrefab);
            thread.name = messageThread.Participant;
            thread.transform.SetParent(transform);
            var threadController = thread.GetComponent<MessageThreadController>();
            threadController.MessageThread = messageThread;
            thread.GetComponent<RectTransform>().localPosition = new Vector3(0, rowPointer, 0);
            rowPointer -= (height + Margin);

            threadController.StoryController = StoryController;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
