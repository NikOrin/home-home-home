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
        var participant = transform.Find("ParticipantLabel").GetComponent<Text>();
        participant.text = MessageThread.Participant;
        var latestMessage = transform.Find("MessageSnippet").GetComponent<Text>();
        latestMessage.text = MessageThread.LatestMessage;
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
