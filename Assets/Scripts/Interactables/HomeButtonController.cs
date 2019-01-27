using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeButtonController : MonoBehaviour
{
    public GameObject CurrentApp;
    public GameObject HomeScreen;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(HomeClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HomeClick()
    {
        Debug.Log("Home clicked");
        Destroy(CurrentApp);
        HomeScreen.SetActive(true);
    }
}
