using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeScreenController : MonoBehaviour
{
    public List<Button> Apps;

    public GameObject GenericAppIcon;

    // Start is called before the first frame update
    void Start()
    {
        var buttonObject = Instantiate(GenericAppIcon);
        var button = buttonObject.GetComponent<Button>();
        button.onClick.AddListener(() => Test(button));
        buttonObject.transform.SetParent(transform);
        var btnRect = buttonObject.GetComponent<RectTransform>();
        btnRect.localPosition = Vector3.zero;

        var text = buttonObject.transform.Find("Text").GetComponent<Text>();
        text.text = "Message App";
        Apps.Add(button);
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
