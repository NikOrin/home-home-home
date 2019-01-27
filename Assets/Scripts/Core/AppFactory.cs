using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Application;

public class AppFactory : MonoBehaviour
{
    public GameObject MessageAppCanvas;
    public GameObject MapAppCanvas;
    public GameObject ToDoListCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AppButtonInfo GetAppCanvas(string appName)
    {
        switch(appName)
        {
            case "MessagesApp":
                return new AppButtonInfo
                {
                    AppCanvas = MessageAppCanvas
                };
            case "MapApp":
                return new AppButtonInfo
                {
                    AppCanvas = MapAppCanvas
                };
            case "ToDoListApp":
                return new AppButtonInfo
                {
                    AppCanvas = ToDoListCanvas
                };
        }
        return null;
    }
}
