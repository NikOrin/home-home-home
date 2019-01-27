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
    public Sprite MapAppIcon;

    public GameObject ToDoListCanvas;
    public Sprite ToDoListAppIcon;

    public GameObject EmailAppCanvas;
    public Sprite EmailAppIcon;

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
                    AppCanvas = MapAppCanvas,
                    AppIconImage = MapAppIcon
                };
            case "ToDoListApp":
                return new AppButtonInfo
                {
                    AppCanvas = ToDoListCanvas,
                    AppIconImage = ToDoListAppIcon
                };
            case "EmailApp":
                return new AppButtonInfo
                {
                    AppCanvas = EmailAppCanvas,
                    AppIconImage = EmailAppIcon
                };
        }
        return null;
    }
}
