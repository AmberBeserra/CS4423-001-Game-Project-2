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

	public static GameManager gameManager { get; private set; }

	public HitPoint playerHP = new HitPoint(20, 20);

	public Text GoldToScore;

	public int CurrentScore;
	static int weakPotion = 0;
	static int strongPotion = 0;

	public GameObject weakPotionButton;
    public GameObject strongPotionButton;
	public GameObject continueButton;	

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
        if (GoldToScore != null) //checks to make sure GoldToScore is on the scene before providing the counter
        {
            if (PlayerPrefs.HasKey("gold_score_counter")) //checks if counter already exists at the correct amount
            {
                CurrentScore = PlayerPrefs.GetInt("gold_score_counter");
                GoldToScore.text = CurrentScore.ToString();
            }
            else //provides a new counter with a base gold of 100
            {
                CurrentScore = 100;
                GoldToScore.text = "100";
                PlayerPrefs.SetInt("gold_score_counter", 100);
            }
        }
    }
	public void ScoreAfterMonsterDie()
	{
		CurrentScore = PlayerPrefs.GetInt("gold_score_counter");
		CurrentScore += 20; //passes gold counter as an Int named CurrentScore and increments it by 20 for completing the battle
		GoldToScore.text = CurrentScore.ToString();
		PlayerPrefs.SetInt("gold_score_counter", CurrentScore);
	}

	public void BuyStrongPotion()
	{
        CurrentScore = PlayerPrefs.GetInt("gold_score_counter");
        if (CurrentScore <  80) //player can't spend more gold than the already have, provides an error message
        {
			Debug.Log("You don't have enough gold for this!");
		} else
		{
            CurrentScore -= 80; //otherwise, subtracts correct amount of gold from CurrentScore and update the gold counter on screen
            GoldToScore.text = CurrentScore.ToString();
            PlayerPrefs.SetInt("gold_score_counter", CurrentScore);
            //add item to player inventory
			strongPotion++;
        }
    }

	public void BuyWeakPotion()
	{
		CurrentScore = PlayerPrefs.GetInt("gold_score_counter");
		if (CurrentScore < 60) //player can't spend more gold than the already have, provides an error message
		{
			Debug.Log("You don't have enough gold for this!");
		}
		else
		{
			CurrentScore -= 60; //otherwise, subtracts correct amount of gold from CurrentScore and update the gold counter on screen
			GoldToScore.text = CurrentScore.ToString();
			PlayerPrefs.SetInt("gold_score_counter", CurrentScore);
			//add item to player inventory
			weakPotion++;
		}
	}
	
	public void ContinueButton()
	{
		SceneManager.LoadScene("FinalBattle");
	}
	public int GetPotions()
	{
		return weakPotion;
	}
	public int GetPotions2()
	{
		return strongPotion;
	}
	public void useWeakPotion()
	{
		weakPotion--;
	}
	public void useStrongPotion()
	{
		strongPotion--;
	}
}
