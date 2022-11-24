using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
	public HitPoint enemyHealth = new HitPoint(10);
	public int damage = 5;
	void Start()
	{
	}
	void Update()
	{
		//THIS IS FOR TESTING PURPOSES
		if(Input.GetKeyDown(KeyCode.S))
		{
			//EnemyIsDamaged(5);
		}
		if(Input.GetKeyDown(KeyCode.W))
		{
			EnemyIsHealed(5);
		}
		if(Input.GetKeyDown(KeyCode.D))
		{
			EnemyMaxUp(5);
		}
		if(Input.GetKeyDown(KeyCode.A))
		{
			EnemyMaxDown(5);
		}
	}
	public void EnemyIsDamaged(int dmg)
	{
		//Debug.Log("enemy, dmg: " + dmg);
		enemyHealth.Damage(5);
		Debug.Log("enemy, hp: " + enemyHealth.Health);
	}
	private void EnemyIsHealed(int heal)
	{
		//Debug.Log("enemy, heal: " + heal);
		GameManager.gameManager.enemyHP.Heal(heal);
		Debug.Log("enemy, hp: " + GameManager.gameManager.enemyHP.Health);
	}
	private void EnemyMaxUp(int up)
	{
		//Debug.Log("enemy, max up: " + up);
		GameManager.gameManager.enemyHP.HPMaxInc(up);
		Debug.Log("enemy, hpMax: " + GameManager.gameManager.enemyHP.HealthMax);
	}
	private void EnemyMaxDown(int down)
	{
		//Debug.Log("enemy, max down: " + down);
		GameManager.gameManager.enemyHP.HPMaxDec(down);
		Debug.Log("enemy, hpMax: " + GameManager.gameManager.enemyHP.HealthMax);
	}
}