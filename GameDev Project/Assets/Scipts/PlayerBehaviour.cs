using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
	//public HitPoint playerHP = new HitPoint(20, 20);
	private GameManager gameManager;

	void Start()
	{
		/*gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		gameManager.ScoreAfterMonsterDie();
        gameManager.ScoreAfterMonsterDie();
        gameManager.ScoreAfterMonsterDie();
        gameManager.ScoreAfterMonsterDie();*/
		//use this for the MonsterBehaviour, I just could'nt find the script
    }
	
	void Update()
	{
		//THIS IS FOR TESTING PURPOSES
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			PlayerIsDamaged(5);
			Debug.Log("HP: " + GameManager.gameManager.playerHP.Health);
		}
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			PlayerIsHealed(5);
			Debug.Log("HP: " + GameManager.gameManager.playerHP.Health);
		}
		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			PlayerMaxUp(5);
			Debug.Log("MAX: " + GameManager.gameManager.playerHP.HealthMax);
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			PlayerMaxDown(5);
			Debug.Log("MAX: " + GameManager.gameManager.playerHP.HealthMax);
		}
		
	}
	
	private void PlayerIsDamaged(int dmg)
	{
		GameManager.gameManager.playerHP.Damage(dmg);
		//Debug.Log(GameManager.gameManager.playerHP.Health);
	}
	private void PlayerIsHealed(int heal)
	{
		GameManager.gameManager.playerHP.Heal(heal);
		//Debug.Log(GameManager.gameManager.playerHP.Health);
	}
	private void PlayerMaxUp(int up)
	{
		GameManager.gameManager.playerHP.HPMaxInc(up);
		//Debug.Log(GameManager.gameManager.playerHP.HealthMax);
	}
	private void PlayerMaxDown(int down)
	{
		GameManager.gameManager.playerHP.HPMaxDec(down);
		//Debug.Log(GameManager.gameManager.playerHP.HealthMax);
	}
}
