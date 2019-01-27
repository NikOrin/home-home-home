using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Application.Messages;
using Application.Email;

public class Chapter1Controller : StoryController
{
    public GameObject Home;
    private HomeScreenController _homeController;

    public List<MessageThread> AvailableThreads = new List<MessageThread>();

    public List<Email> AvailableEmails = new List<Email>();

    public GameObject MomInitialMessage;
    public GameObject ReplyToMom;
    public GameObject FinalConversationWithMom;
    public GameObject HREmail;

    // Start is called before the first frame update
    void Start()
    {
        AvailableThreads.Add(new MessageThread
        {
            Participant = "Mom",
            MessageSnippet = "How are you doing honey? Call me soon.",
            StoryKey = "OpenedMomThread",
            ThreadPrefab = MomInitialMessage
        });
        _homeController = Home.GetComponent<HomeScreenController>();
        _homeController.StoryController = this;
        KeyMessages.Add("Mom");
    }

    public override List<string> GetAvailableApps()
    {
        return new List<string>{
            "MessagesApp", "ToDoListApp", "EmailApp"
        };
    }

    public override void StoryKeyPointReached(string key, GameObject gameObject = null)
    {
        Debug.Log("Chapter 1 key element reached");
        switch(key){
            case "OpenedMomThread":
                Debug.Log("Player opened key message from mom");
                StartCoroutine(GetEmailAlert());
                break;
            case "OpenedHREmail":
                Debug.Log("HR email was opened");
                _homeController.RemoveAlertIcon("EmailApp");
                AvailableThreads[0].ThreadPrefab = ReplyToMom;
                AvailableThreads[0].StoryKey = null;
                AvailableEmails[0].StoryKey = null;
                break;
            case "AskMom":
                var audio = transform.Find("MessageReply").GetComponent<AudioSource>();
                audio.Play(0);
                var parentCanvas = gameObject.transform.parent;
                Destroy(gameObject);
                var newView = Instantiate(FinalConversationWithMom);
                newView.transform.SetParent(parentCanvas);
                break;
        }
    }

    public override void SetMessageKey(MessageThreadController messageThreadController)
    {
        messageThreadController.MessageThreadKey = "OpenedMomThread";
    }

    public override List<MessageThread> BuildAvailableThreads(){
        return AvailableThreads;
    }

    public override List<Email> BuildAvailableEmails(){
        return AvailableEmails;
    }

    private IEnumerator GetEmailAlert(){
        yield return new WaitForSeconds(1);
        var audioSource = transform.Find("EmailReceiveAudio").GetComponent<AudioSource>();
        audioSource.Play(0);
        _homeController.SetAlertIcon("EmailApp");
        AvailableEmails.Add(new Email
        {
            Sender = "HR",
            Subject = "Welcome to Ruckus!",
            OpenEmail = HREmail,
            StoryKey = "OpenedHREmail"
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
