using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Application.Email;

public class EmailAppController : BaseAppController
{
    public List<Email> Emails;
    public GameObject EmailThreadPrefab;

    public int Margin;

    // Start is called before the first frame update
    void Start()
    {
        Emails = StoryController.BuildAvailableEmails();

        BuildEmails();
    }

    public void BuildEmails(){
        int height = (int)EmailThreadPrefab.GetComponent<RectTransform>().rect.height;
        int rowPointer = Screen.height / 2 - height - TopMargin - 40;

        foreach (var email in Emails)
        {
            var emailObject = Instantiate(EmailThreadPrefab);
            emailObject.name = email.Sender;
            emailObject.transform.SetParent(transform);
            var emailController = emailObject.GetComponent<EmailController>();
            emailController.Email = email;
            emailObject.GetComponent<RectTransform>().localPosition = new Vector3(0, rowPointer, 0);
            rowPointer -= (height + Margin);

            emailController.StoryController = StoryController;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
