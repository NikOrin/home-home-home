using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Application.Messages;

public class MessageThreadController : MonoBehaviour
{
    public MessageThread MessageThread;

    public GameObject MessageThreadCanvasPrefab;
    public StoryController StoryController;

    public string MessageThreadKey;
    // Start is called before the first frame update
    void Start()
    {
        var participant = transform.Find("ParticipantLabel").GetComponent<Text>();
        participant.text = MessageThread.Participant;
        var messageSnippet = transform.Find("MessageSnippet").GetComponent<Text>();
        messageSnippet.text = MessageThread.MessageSnippet;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OpenThreadOnClick()
	{
		Debug.Log("You are reading the message thread~!");

        if (!string.IsNullOrEmpty(MessageThread.StoryKey)){
            StoryController.StoryKeyPointReached(MessageThread.StoryKey);
        }
        var thread = Instantiate(MessageThread.ThreadPrefab);
        thread.transform.SetParent(transform.parent);
        thread.transform.SetAsLastSibling();
    }
}
