using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	/*
	The gamemanager script+object is used as a singleton to track certain game action/events
	Such as checking for loss conditions.
	*/
	
	public static GameManager gameManager{get; private set;}
	
	public HitPoint playerHP = new HitPoint(20, 20);

    public Text GoldToScore;

	int CurrentScore;

    void Awake()
	{
        
        //if there is another GameManager, destroy one.
        if (gameManager != null && gameManager != this)
		{
			Destroy(this);
		}
		else
		{
			gameManager = this;
        }
    }
    void Start()
    {
 
    }
    public void ScoreAfterMonsterDie() 
	{
		CurrentScore = PlayerPrefs.GetInt("gold_score_counter");
        CurrentScore += 20;
        GoldToScore.text = CurrentScore.ToString();
        PlayerPrefs.SetInt("gold_score_counter", CurrentScore);
    }

	public void ScoreAfterPurchase()
	{
		CurrentScore = PlayerPrefs.GetInt("gold_score_counter");
		CurrentScore -= 100;
		GoldToScore.text = CurrentScore.ToString();
		PlayerPrefs.SetInt("gold_score_counter", CurrentScore);
	}
}
