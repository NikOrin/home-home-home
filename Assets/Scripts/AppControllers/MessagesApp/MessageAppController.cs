using System.Collections;
using System.Collections.Generic;
using Application.Messages;
using UnityEngine;

public class MessageAppController : MonoBehaviour
{
    public List<MessageThread> MessageThreads;
    public GameObject MessageThreadPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //Get messages information from story controller
        //test method for building fake data for now;
        BuildDummyData();
        Debug.Log("You've opened the messages app");

        foreach (var messageThread in MessageThreads)
        {
            var thread = Instantiate(MessageThreadPrefab);
            thread.name = messageThread.Participant;
            thread.transform.SetParent(transform);
            var threadController = thread.GetComponent<MessageThreadController>();
            threadController.MessageThread = messageThread;
            thread.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
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
            SentOn = new System.DateTime(2019, 1, 26),
            MessageText = "Come home you awful child"
        };

        thread.Messages.Add(message);
        MessageThreads.Add(thread);
    }
}
