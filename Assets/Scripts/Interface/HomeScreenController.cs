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
        button.onClick.AddListener(Test);
        buttonObject.transform.SetParent(transform);
        var btnRect = buttonObject.GetComponent<RectTransform>();
        Debug.Log($"position: {btnRect.position}");
        Debug.Log($"local position: {btnRect.localPosition}");
        btnRect.localPosition = Vector3.zero;
        Apps.Add(button);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Test()
    {
        Debug.Log("Test button was clicked");
    }
}
