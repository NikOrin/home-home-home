using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Application.Messages;

public class MessageThreadController : MonoBehaviour
{
    public MessageThread MessageThread;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Thread started");
        Debug.Log($"Message thread controller created for {transform.name}");
        var participant = transform.Find("ParticipantLabel").GetComponent<Text>();
        participant.text = MessageThread.Participant;
        Debug.Log($"Participant text: {MessageThread.Participant}");
        var latestMessage = transform.Find("MessageSnippet").GetComponent<Text>();
        latestMessage.text = MessageThread.LatestMessage;
        Debug.Log($"Latest message snippet: {MessageThread.LatestMessage}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
