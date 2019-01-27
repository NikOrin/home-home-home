using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeScreenController : MonoBehaviour
{
    public Dictionary<string, GameObject> Apps;
    public Dictionary<string, GameObject> RedDotAlerts = new Dictionary<string, GameObject>();

    public GameObject GenericAppButtonPrefab;
    public GameObject HomeButton;
    //public GameObject StoryObject;
    public GameObject StoryObject;
    public StoryController StoryController;

    public GameObject RedDot;

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
        int columnPointer = -Screen.width / 2 + ButtonMargins / 2 + width/2 + 20;

        if (StoryController == null)
            StoryController = StoryObject.GetComponent<StoryController>();
        var apps = StoryController.GetAvailableApps();
        Apps = new Dictionary<string, GameObject>();
        foreach (var app in apps)
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
            opensApp.StoryController = StoryController;
            var appInfo = appFactory.GetAppCanvas(app);
            opensApp.AppCanvas = appInfo.AppCanvas;
            button.image.sprite = appInfo.AppIconImage;

            Apps.Add(app, buttonObject);
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

    public void SetAlertIcon(string buttonKey)
    {
        var button = Apps[buttonKey];
        var alertIcon = Instantiate(RedDot);
        var buttonLocation = button.GetComponent<RectTransform>().localPosition;
        alertIcon.transform.SetParent(transform);
        alertIcon.GetComponent<RectTransform>().localPosition = new Vector3(buttonLocation.x + 75, buttonLocation.y + 75, buttonLocation.z);

        RedDotAlerts.Add(buttonKey, alertIcon);
    }

    public void RemoveAlertIcon(string buttonKey)
    {
        var icon = RedDotAlerts[buttonKey];
        RedDotAlerts.Remove(buttonKey);
        Destroy(icon);
    }
}
