using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationOfPartyMultipleChoice : CustomListener
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(ShowMultipleChoices);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowMultipleChoices()
    {
        var choices = transform.parent.Find("Choices");
        choices.gameObject.SetActive(true);
        foreach(Transform child in choices){
            child.GetComponent<Button>().onClick.AddListener(() => CheckStory(child.name));
        }
    }

    void CheckStory(string buttonName)
    {
        StoryController.TriggerCallback("LocationSelected", buttonName);
    }
}
