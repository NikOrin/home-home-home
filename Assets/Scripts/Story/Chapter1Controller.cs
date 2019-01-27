using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Application.Messages;

public class Chapter1Controller : StoryController
{
    public GameObject Home;
    private HomeScreenController _homeController;

    public Sprite YouGotMailIcon;

    // Start is called before the first frame update
    void Start()
    {
        _homeController = Home.GetComponent<HomeScreenController>();
        _homeController.StoryController = this;

        KeyMessages.Add("Mom");
    }

    public override List<string> GetAvailableApps()
    {
        return new List<string>{
            "MessagesApp", "MapApp", "ToDoListApp", "EmailApp"
        };
    }

    public override void StoryKeyPointReached(string key)
    {
        Debug.Log("Chapter 1 key element reached");
        switch(key){
            case "OpenedMomThread":
                Debug.Log("Player opened key message from mom");
                StartCoroutine(GetEmailAlert());
                break;
        }
    }

    public override void SetMessageKey(MessageThreadController messageThreadController)
    {
        messageThreadController.MessageThreadKey = "OpenedMomThread";
    }

    public override List<MessageThread> BuildAvailableThreads(){
        return new List<MessageThread>{
            new MessageThread{ Participant="Mom", MessageSnippet="How are you doing honey? Call me soon."}
        };
    }

    private IEnumerator GetEmailAlert(){
        yield return new WaitForSeconds(1);
        var audioSource = transform.GetComponent<AudioSource>();
        audioSource.Play(0);
        _homeController.SetAlertIcon("EmailApp");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
