using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Application.Messages;
using Application.Email;
using UnityEngine.SceneManagement;

public class Chapter1Controller : StoryController
{
    public GameObject Home;
    private HomeScreenController _homeController;



    public GameObject MomInitialMessage;
    public GameObject ReplyToMom;
    public GameObject FinalConversationWithMom;

    public GameObject AlexInitial;
    public GameObject AlexFinal;

    public GameObject BritInitial;

    public GameObject HREmail;

    // Start is called before the first frame update
    void Start()
    {
        BuildMessages();
        _homeController = Home.GetComponent<HomeScreenController>();
        _homeController.StoryController = this;
    }

    private void BuildMessages(){
        AvailableThreads.Add(new MessageThread
        {
            Participant = "Mom",
            MessageSnippet = "How are you doing honey? Call me soon.",
            StoryKey = "OpenedMomThread",
            ThreadPrefab = MomInitialMessage
        });

        AvailableThreads.Add(new MessageThread
        {
            Participant = "Alex",
            MessageSnippet = "you're new to the city so not like y...",
            ThreadPrefab = AlexInitial
        });

        AvailableThreads.Add(new MessageThread
        {
            Participant = "Brit",
            MessageSnippet = "I appreciate it, thanks (:",
            ThreadPrefab = BritInitial
        });
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
                StartCoroutine(AlexMessagesYou());
                break;
            case "End":
                StartCoroutine(NextChapter());
                break;
        }
    }

    public override void SetMessageKey(MessageThreadController messageThreadController)
    {
        messageThreadController.MessageThreadKey = "OpenedMomThread";
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

    IEnumerator AlexMessagesYou(){
        yield return new WaitForSeconds(2);
        var audioSource = transform.Find("MessageReceive").GetComponent<AudioSource>();
        audioSource.Play(0);
        _homeController.SetAlertIcon("MessagesApp");
        var alexThread = AvailableThreads.Where(x => x.Participant == "Alex").First();
        alexThread.ThreadPrefab = AlexFinal;
        alexThread.StoryKey = "End";
    }

    private IEnumerator NextChapter(){
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Scenes/Chapter2", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
