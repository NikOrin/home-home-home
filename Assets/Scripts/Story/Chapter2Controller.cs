using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Application.Messages;
using Application.Email;

public class Chapter2Controller : StoryController
{
    public GameObject Home;
    private HomeScreenController _homeController;
    // Start is called before the first frame update

    public GameObject LastMomMessage;
    void Start()
    {
        AvailableThreads.Add(new MessageThread
        {
            Participant = "Mom",
            MessageSnippet = "Hope your first day went wel...",
            ThreadPrefab = LastMomMessage
        });
        _homeController = Home.GetComponent<HomeScreenController>();
        _homeController.StoryController = this;
    }

    public override List<string> GetAvailableApps()
    {
        return new List<string>{
            "MessagesApp", "ToDoListApp", "EmailApp", "MapApp"
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
