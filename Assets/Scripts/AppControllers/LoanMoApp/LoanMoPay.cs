using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoanMoPay : MonoBehaviour
{
	public Dictionary<string, int> Friends;

	void Start()
	{
		Friends = new Dictionary<string, int>();

		Friends.Add("John", 50);
		Friends.Add("Brent", 300);
		Friends.Add("Chungus", 5000);
		Friends.Add("Karl", 2);

		Debug.Log(Friends);
	}

	public void PayOnClick()
	{
		Debug.Log("Pay!!");
	}
}
