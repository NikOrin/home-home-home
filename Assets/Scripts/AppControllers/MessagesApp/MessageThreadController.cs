using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Application.Messages;

public class MessageThreadController : MonoBehaviour
{
    public MessageThread MessageThread;

    public GameObject MessageThreadCanvasPrefab;
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

	public void OpenThreadOnClick()
	{
		Debug.Log("You are reading the message thread~!");
        Instantiate(MessageThreadCanvasPrefab);
		// Create a new Panel for Thread. 
//		GameObject newCanvas = new GameObject("Canvas");
//		Canvas t = newCanvas.AddComponent<Canvas>();
//		t.renderMode = RenderMode.ScreenSpaceOverlay;
//		newCanvas.AddComponent<CanvasScaler>();
//		newCanvas.AddComponent<GraphicRaycaster>();
//		GameObject Panel = new GameObject("Panel");
//		Panel.AddComponent<CanvasRenderer>();
//		Image i = Panel.AddComponent<Image>();
//		i.color = Color.white;
//
		//Panel.transform
	   // Panel.transform.SetParent(this.transform, false);
	}
}
