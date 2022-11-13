using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
	void Start()
	{
	}
	void Update()
	{
		//Test Inputs for methods calls
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			PlayerIsDamaged(5);
		}
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			PlayerIsHealed(5);
		}
		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			PlayerMaxUp(5);
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			PlayerMaxDown(5);
		}
	}
	private void PlayerIsDamaged(int dmg)
	{
		//Debug.Log("player, dmg: " + dmg);
		GameManager.gameManager.playerHP.Damage(dmg);
		Debug.Log("player, hp: " + GameManager.gameManager.playerHP.Health);
	}
	private void PlayerIsHealed(int heal)
	{
		//Debug.Log("player, heal: " + heal);
		GameManager.gameManager.playerHP.Heal(heal);
		Debug.Log("player, hp: " + GameManager.gameManager.playerHP.Health);
	}
	private void PlayerMaxUp(int up)
	{
		//Debug.Log("player, max hp up: " + up);
		GameManager.gameManager.playerHP.HPMaxInc(up);
		Debug.Log("player, hpMax: " + GameManager.gameManager.playerHP.HealthMax);
	}
	private void PlayerMaxDown(int down)
	{
		///Debug.Log("player, max hp up: " + up);
		GameManager.gameManager.playerHP.HPMaxDec(down);
		Debug.Log("player, hpMax: " + GameManager.gameManager.playerHP.HealthMax);
	}
}