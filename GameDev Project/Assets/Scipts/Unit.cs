using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int damage;

    public int maxHP;
    public int currentHP;
    public HitPoint unitHP = new HitPoint(20);

    public bool Damaged(int dmg)
	{
		//Debug.Log("enemy, dmg: " + dmg);
		unitHP.Damage(5);
		Debug.Log("enemy, hp: " + unitHP.Health);

		if(unitHP.Health <= 0)//negative or 0
			{
				Debug.Log("DEAD");
				return true;
				//should trigger player/unit death event
			}
		else
			return false;
	}
}
