using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter1Controller : MonoBehaviour
{
    public GameObject Home;
    // Start is called before the first frame update
    void Start()
    {
        SetupAvailableApps();
        CreateMessages();
    }

    private void SetupAvailableApps()
    {
        var controller = Home.GetComponent<HomeScreenController>();
        controller.Apps = new List<string>{
            "MessagesApp", "MapApp"
        };
    }

    private void CreateMessages()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
