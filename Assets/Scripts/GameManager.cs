using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

	public Text pointsText;
	public int points = 0;
	public bool hardMode = false;
	public float speed;
	
	public float startingSpeed;
	public int bonusCounter;
	
	// Use this for initialization
	void Awake ()
	{
		speed = startingSpeed;
		bonusCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddPoint(int amount)
	{
		bonusCounter += amount;
		if (bonusCounter > 5)
			bonusCounter = 5;
		points += bonusCounter;
		pointsText.text = "Points: " + points;
		speed = startingSpeed+Mathf.CeilToInt(points / 10f);
	}
	
	public void RemovePoints()
	{
		bonusCounter = 0;
		points -= 2;
		if (points < 0)
			points = 0;
		pointsText.text = "Points: " + points;
		speed = Mathf.Max(startingSpeed,startingSpeed+Mathf.CeilToInt(points / 10f));
	}
}
