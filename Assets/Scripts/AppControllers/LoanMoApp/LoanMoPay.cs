using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoanMoPay : MonoBehaviour
{
	public GameObject button;
	public Text txt;

	public void PayOnClick()
	{
		txt = button.GetComponentInChildren<Text>();

		if(button.tag == "Right")
		{	
			txt.text = " $$ JULIE $$ ";
			Debug.Log("DING");
		}
	}
}
