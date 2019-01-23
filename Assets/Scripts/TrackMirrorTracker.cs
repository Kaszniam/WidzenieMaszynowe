using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMirrorTracker : MonoBehaviour
{
	public GameObject tracker;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {	
		transform.position = new Vector3(-tracker.transform.position.x,tracker.transform.position.y,3-tracker.transform.position.z);	
		transform.rotation = Quaternion.Euler(tracker.transform.rotation.eulerAngles.z-90,tracker.transform.rotation.eulerAngles.y+90,-tracker.transform.rotation.eulerAngles.x);
	}
}
