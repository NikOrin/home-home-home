using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Application.Email;

public class EmailController : MonoBehaviour
{
    public Email Email;

    public StoryController StoryController;

    // Start is called before the first frame update
    void Start()
    {
        var sender = transform.Find("Sender").GetComponent<Text>();
        sender.text = Email.Sender;
        var subject = transform.Find("Subject").GetComponent<Text>();
        subject.text = Email.Subject;

        transform.GetComponent<Button>().onClick.AddListener(OpenEmailOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenEmailOnClick()
    {
        if (!string.IsNullOrEmpty(Email.StoryKey))
            StoryController.StoryKeyPointReached(Email.StoryKey);

        var openEmail = Instantiate(Email.OpenEmail);

        openEmail.transform.SetParent(transform);
    }
}
