using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

	public GameObject red;
	public GameObject green;
	public GameObject blue;
	public GameObject yellow;
	
	public Transform target;

	public GameObject prefab;

	public float secBetweenSpawns;

	private GameManager _gameManager;
	private Vector3 _targetPosition;
	RaycastHit hit;
	// Use this for initialization
	void Start ()
	{
		_gameManager = FindObjectOfType<GameManager>();
		_targetPosition = target.position;
		StartCoroutine(Spawn());
	}

	IEnumerator Spawn()
	{
		while (true)
		{
			int random = _gameManager.hardMode?Random.Range(0,4):Random.Range(0,2);
			switch (random)
			{
				case 0:
					SpawnRed();
					break;
				case 1:
					SpawnBlue();	
					break;
				case 2:
					SpawnGreen();
					break;
				case 3:
					SpawnYellow();
					break;
			}
			yield return new WaitForSeconds(Random.Range(secBetweenSpawns, 2*secBetweenSpawns+1));
		}
	}

	public void SpawnRed()
	{
		GameObject projectile = Instantiate(red, transform.position, Quaternion.identity);
		projectile.layer = LayerMask.NameToLayer("RedP");
		projectile.transform.LookAt(_targetPosition);
		projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * _gameManager.speed*100);
	}
	
	public void SpawnGreen()
	{
		GameObject projectile = Instantiate(green, transform.position, Quaternion.identity);
		projectile.layer = LayerMask.NameToLayer("GreenP");
		projectile.transform.LookAt(_targetPosition);
		projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * _gameManager.speed*100);
	}
	
	public void SpawnBlue()
	{
		GameObject projectile = Instantiate(blue, transform.position, Quaternion.identity);
		projectile.layer = LayerMask.NameToLayer("BlueP");
		projectile.transform.LookAt(_targetPosition);
		projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * _gameManager.speed*100);
	}
	
	public void SpawnYellow()
	{
		GameObject projectile = Instantiate(yellow, transform.position, Quaternion.identity);
		projectile.layer = LayerMask.NameToLayer("YellowP");
		projectile.transform.LookAt(_targetPosition);
		projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * _gameManager.speed*100);
	}
}
