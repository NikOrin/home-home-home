using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Application.Messages;
using Application.Email;
using System.Linq;
using UnityEngine.SceneManagement;

public class Chapter2Controller : StoryController
{
    public GameObject Home;
    private HomeScreenController _homeController;
    // Start is called before the first frame update

    public GameObject LastMomMessage;

    public GameObject AlexInitial;
    public GameObject AlexMultipleChoice;

    public GameObject BritInitial;

    public GameObject ToDoList;

    void Start()
    {
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
            ThreadPrefab = LastMomMessage
        });

        AvailableThreads.Add(new MessageThread
        {
            Participant = "Alex",
            MessageSnippet = "okay you didn't reply so i'm...",
            ThreadPrefab = AlexInitial
        });

        AvailableThreads.Add(new MessageThread
        {
            Participant = "Brit",
            MessageSnippet = "The usual place.. not sure wha...",
            ThreadPrefab = BritInitial
        });
    }

    public override List<string> GetAvailableApps()
    {
        return new List<string>{
            "MessagesApp", "ToDoListApp", "EmailApp", "MapApp"
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

    public override void TriggerCallback(string key, params string[] args)
    {
        switch(key){
            case "MapApp":
                var alex = AvailableThreads.First(x => x.Participant == "Alex");
                alex.ThreadPrefab = AlexMultipleChoice;
                break;
            case "LocationSelected":
                var fade = Instantiate(FadeInOut);

                fade.transform.SetAsLastSibling();
                if (args[0] == "Correct")
                    fade.GetComponent<FadeOut>().Scene = "Scenes/Chapter3";
                else fade.GetComponent<FadeOut>().Scene = "Scenes/Chapter2";
                break;
        }
    }

    public override bool HasCustomCallback(string key) {
        switch(key){
            case "MapApp":
                return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
