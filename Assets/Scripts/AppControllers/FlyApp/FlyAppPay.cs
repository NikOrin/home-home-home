using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlyAppPay : MonoBehaviour
{
	public GameObject button;
	public Text txt;

	public void PayOnClick()
	{
		txt = button.GetComponentInChildren<Text>();
		if (button.tag == "Right")
		{
			txt.text = "PAID FLIGHT";
			SceneManager.LoadScene("Chapter3");
		}
	}
}
