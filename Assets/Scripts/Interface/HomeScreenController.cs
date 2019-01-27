using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeScreenController : MonoBehaviour
{
    //public List<Button> Apps;
    public List<string> Apps;
    public GameObject GenericAppButtonPrefab;
    public GameObject HomeButton;

    //Used for the offset from the edge of the top for the battery bar
    public int TopMargin = 60;
    //used for the offset from the bottom edge of the screen (for the home button)
    public int BottomMargin;
    public int ButtonMargins;


    // Start is called before the first frame update
    void Start()
    {
        var appFactory = transform.Find("AppFactoryObject").GetComponent<AppFactory>();

        int height = (int)GenericAppButtonPrefab.GetComponent<RectTransform>().rect.height;
        int rowPointer = Screen.height / 2 - TopMargin - height/2;

        int width = (int)GenericAppButtonPrefab.GetComponent<RectTransform>().rect.width;
        int columnPointer = -Screen.width / 2 + ButtonMargins / 2 + width/2;



        foreach(var app in Apps)
        {
            Debug.Log("making buttons");
            var buttonObject = Instantiate(GenericAppButtonPrefab);
            buttonObject.name = $"{app}Button";
            var button = buttonObject.GetComponent<Button>();
            button.onClick.AddListener(() => Test(button));
            buttonObject.transform.SetParent(transform);
            var btnRect = buttonObject.GetComponent<RectTransform>();
            btnRect.localPosition = new Vector3(columnPointer, rowPointer, 0);

            //rowPointer -= (height + ButtonMargins);
            columnPointer += (width + ButtonMargins);

            var opensApp = button.GetComponent<OpensApp>();
            opensApp.HomeButton = HomeButton;
            opensApp.AppCanvas = appFactory.GetAppCanvas(app).AppCanvas;


            var text = buttonObject.transform.Find("Text").GetComponent<Text>();
            text.text = app;
        }

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Test(Button b)
    {
        Debug.Log("Test button was clicked");
        b.GetComponent<OpensApp>().OpenAppCanvas();

        gameObject.SetActive(false);
    }
}
