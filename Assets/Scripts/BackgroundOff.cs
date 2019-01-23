using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class BackgroundOff : MonoBehaviour {
 
	private bool mBackgroundWasSwitchedOff = false;
 
	// Update is called once per frame
	void Update () {
		if (!mBackgroundWasSwitchedOff)
		{
			transform.GetChild(0).gameObject.SetActive(false);

			GetComponent<BackgroundOff>().enabled = false;
		}
	}
}
