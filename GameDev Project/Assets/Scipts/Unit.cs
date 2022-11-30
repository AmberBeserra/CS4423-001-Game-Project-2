using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int damage;

	public Animator myAnim;

    public HitPoint unitHP = new HitPoint(20);

    public bool Damaged(int dmg)
	{
		unitHP.Damage(dmg);


		//myAnim.SetTrigger("Damaged");

		if (unitHP.Health <= 0)//negative or 0
			{
				Debug.Log("DEAD");
				return true;
				//should trigger player/unit death event
			}
		else
			return false;
	}
	public void setStats(int dmg, int max)
	{
		damage = dmg;
		unitHP.setHealth(max);
	}
	public int getDamage()
	{
		return damage;
	}
}
