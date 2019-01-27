using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReplyToMom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ReplyBarOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReplyBarOnClick(){
        var storyController = GetComponentInParent<MessageThreadController>().StoryController;

        storyController.StoryKeyPointReached("AskMom", transform.parent.gameObject);
    }
}
