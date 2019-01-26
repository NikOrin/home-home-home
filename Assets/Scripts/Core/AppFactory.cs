using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppFactory : MonoBehaviour
{
    public GameObject MessageAppCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetAppCanvas(string appName)
    {
        switch(appName)
        {
            case "MessagesApp":
                return MessageAppCanvas;

        }
        return null;
    }
}
