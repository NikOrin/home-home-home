using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpensApp : MonoBehaviour
{
    public GameObject AppCanvas;
    public GameObject HomeButton;
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
        HomeButton.GetComponent<HomeButtonController>().CurrentApp = Instantiate(AppCanvas);
    }
}
