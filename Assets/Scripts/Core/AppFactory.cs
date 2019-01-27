using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Application;

public class AppFactory : MonoBehaviour
{
    public GameObject MessageAppCanvas;
    public Sprite MessageAppIcon;
    public GameObject MapAppCanvas;
    public GameObject ToDoListCanvas;
    public Sprite ToDoListAppIcon;

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
                    AppCanvas = MessageAppCanvas,
                    AppIconImage = MessageAppIcon
                };
            case "MapApp":
                return new AppButtonInfo
                {
                    AppCanvas = MapAppCanvas
                };
            case "ToDoListApp":
                return new AppButtonInfo
                {
                    AppCanvas = ToDoListCanvas,
                    AppIconImage = ToDoListAppIcon
                };
        }
        return null;
    }
}
