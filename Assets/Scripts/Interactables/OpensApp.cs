using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpensApp : MonoBehaviour
{
    public GameObject AppCanvas;
    public GameObject HomeButton;
    public StoryController StoryController;
    public string StoryKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenAppCanvas()
    {
        var app = Instantiate(AppCanvas);
        HomeButton.GetComponent<HomeButtonController>().CurrentApp = app;
        if (app.GetComponent<BaseAppController>() != null)
        {
            app.GetComponent<BaseAppController>().StoryController = this.StoryController;
        }
        if (!string.IsNullOrEmpty(StoryKey))
            StoryController.TriggerCallback(StoryKey);
    }
}
