using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoanMoPay : MonoBehaviour
{
	public GameObject button;

    // Start is called before the first frame update
    void Start()
	{
    }

	public void PayOnClick()
	{
		if(button.tag == "Right")
		{	
			Debug.Log("DING");
		}
		else
		{
			Debug.Log("SCREAM");
		}
	}
}
