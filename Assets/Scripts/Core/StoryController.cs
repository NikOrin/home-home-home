using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Application.Messages;
using Application.Email;

public class StoryController : MonoBehaviour
{
    public List<string> KeyMessages;
    public List<string> KeyEmails;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void StoryKeyPointReached(string key, GameObject gameObject = null){}

    public virtual void SetMessageKey(MessageThreadController messageThreadController){}
    public virtual void SetEmailKey(EmailController emailController){}

    public virtual List<MessageThread> BuildAvailableThreads(){return null;}

    public virtual List<Email> BuildAvailableEmails() { return null; }

    public virtual List<string> GetAvailableApps(){return null;}
}
