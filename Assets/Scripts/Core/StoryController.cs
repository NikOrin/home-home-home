using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Application.Messages;

public class StoryController : MonoBehaviour
{
    public List<string> KeyMessages;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void StoryKeyPointReached(string key){

    }

    public virtual void SetMessageKey(MessageThreadController messageThreadController){

    }

    public virtual List<MessageThread> BuildAvailableThreads(){
        return null;
    }

    public virtual List<string> GetAvailableApps(){
        return null;
    }
}
