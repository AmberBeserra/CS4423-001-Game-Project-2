using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	/*
	The gamemanager script+object is used as a singleton to track certain game action/events
	Such as checking for loss conditions.
	*/
	
	public static GameManager gameManager{get; private set;}
	
	public HitPoint playerHP = new HitPoint(20, 20);
	
	void Awake()
	{
		//if there is another GameManager, destroy one.
		if(gameManager != null && gameManager != this)
		{
			Destroy(this);
		}
		else
		{
			gameManager = this;
		}
	}
}
