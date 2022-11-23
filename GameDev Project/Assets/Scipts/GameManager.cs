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
		if(gameManager != null && gameManager != this)
		{
			Destroy(this);
		}
		else
		{
			gameManager = this;
		}
	}
	private void Start()
	{
        PlayerPrefs.DeleteKey("gold_score_counter"); //this starts over player gold count to default, remove this line to continue "save data"
        if (SceneManager.GetActiveScene().name == "FirstScene")
		{
            if (PlayerPrefs.HasKey("gold_score_counter"))
            {
                CurrentScore = PlayerPrefs.GetInt("gold_score_counter");
                GoldToScore.text = CurrentScore.ToString();
            }
            else
            {
                CurrentScore = 100;
                GoldToScore.text = "100";
                PlayerPrefs.SetInt("gold_score_counter", 100);
            }
        }
	}
	void Update()
	{
		if (SceneManager.GetActiveScene().name == "FirstScene")
		{
			if (Input.GetKeyDown(KeyCode.A))  //for testing purposes
			{
				ScoreAfterMonsterDie();
			}
		}

    }
	public void ScoreAfterMonsterDie() 
	{
        CurrentScore += 20;
        GoldToScore.text = CurrentScore.ToString();
        PlayerPrefs.SetInt("gold_score_counter", CurrentScore);
    }
}
