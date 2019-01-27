using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToDoListController : BaseAppController
{
	public Image bkgToChange;
	public Sprite targetImage;
	public Sprite CurrentImage;

    // Start is called before the first frame update
    void Start()
    {
        var toDoList = Instantiate(StoryController.GetPrefab("ToDoList"));
        toDoList.transform.SetParent(transform);
    }

	void Update()
	{
	    // Press Space to Change the Sprite of the Image
		if(Input.GetKey(KeyCode.Space))
		{
			bkgToChange.sprite = targetImage;
		}
	}

	void DummyImage()
	{
		bkgToChange.sprite = targetImage;
	}
}
