using System.Collections;
using System.Collections.Generic;
using Application.Messages;
using UnityEngine;

public class Chapter3Controller : StoryController
{
    public GameObject Home;
    private HomeScreenController _homeController;
    // Start is called before the first frame update

    public GameObject MomInitial;
    public GameObject AlexInitial;
    public GameObject BritInitial;

    public GameObject ToDoList;

    void Start()
    {
        SetProfilePictures();
        BuildMessages();
        _homeController = Home.GetComponent<HomeScreenController>();
        _homeController.StoryController = this;

    }

    private void BuildMessages()
    {
        AvailableThreads.Add(new MessageThread
        {
            Participant = "Mom",
            MessageSnippet = "Hope your first day went wel...",
            ThreadPrefab = MomInitial,
            ProfilePic = MomIcon
        });

        AvailableThreads.Add(new MessageThread
        {
            Participant = "Alex",
            MessageSnippet = "okay you didn't reply so i'm...",
            ThreadPrefab = AlexInitial,
            ProfilePic = AlexIcon
        });

        AvailableThreads.Add(new MessageThread
        {
            Participant = "Brit",
            MessageSnippet = "The usual place.. not sure wha...",
            ThreadPrefab = BritInitial,
            ProfilePic = BritIcon
        });
    }

    public override List<string> GetAvailableApps()
    {
        return new List<string>{
            "MessagesApp", "ToDoListApp", "EmailApp", "MapApp", "LoanMoApp"
        };
    }

    public override GameObject GetPrefab(string key)
    {
        switch (key)
        {
            case "ToDoList":
                return ToDoList;
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
