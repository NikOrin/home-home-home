using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToDoListController : MonoBehaviour
{
	public Panel Story;
	public Image bkgToChange;
	public string CurrentState;

    // Start is called before the first frame update
    void Start()
    {
		bkgToChange = Story.GetComponent<Image>();
    }

	void ChangeImage()
	{
		if(CurrentState != "Nothing")
		{
			bkgToChange.
		}
	}
}
