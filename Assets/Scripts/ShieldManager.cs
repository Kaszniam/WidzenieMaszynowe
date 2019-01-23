using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{

	public GameObject red;
	public GameObject blue;

	private GameManager _gameManager;
	private GameObject currentPortal;
	private MeshRenderer _meshRenderer;
	// Use this for initialization
	void Start ()
	{
		_gameManager = FindObjectOfType<GameManager>();
		gameObject.layer = LayerMask.NameToLayer(gameObject.CompareTag("Left") ? "Red" : "Blue");
		currentPortal = gameObject.CompareTag("Left") ? red : blue;
		currentPortal.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		if (true)
		{
			if(transform.rotation.eulerAngles.z>45f || transform.rotation.eulerAngles.z<-45f)
			{
				GameObject portal = gameObject.CompareTag("Left") ? blue : red;
				if (currentPortal != portal)
				{
					currentPortal.SetActive(false);
				}
				currentPortal = portal;
				currentPortal.SetActive(true);
				gameObject.layer = LayerMask.NameToLayer(gameObject.CompareTag("Left") ? "Blue" : "Red");
			}
			else
			{
				GameObject portal = gameObject.CompareTag("Left") ? red : blue;
				if (currentPortal != portal)
				{
					currentPortal.SetActive(false);
				}
				currentPortal = portal;
				currentPortal.SetActive(true);
				gameObject.layer = LayerMask.NameToLayer(gameObject.CompareTag("Left") ? "Red" : "Blue");
			}
		}
	}
}
