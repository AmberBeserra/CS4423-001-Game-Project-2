using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoint
{
	//Fields
	int maxHP;
	int currentHP;
	//Properties
	public int Health
	{
		get
		{
			return currentHP;
		}
		set
		{
			currentHP = value;
		}
	}
	public int HealthMax
	{
		get
		{
			return maxHP;
		}
		set
		{
			maxHP = value;
		}
	}
	//Constructors
	public HitPoint(int H, int mH)
	{
		currentHP = H;
		maxHP = mH;
	}
	
	public HitPoint(int H)
	{
		currentHP = H;
		maxHP = H;
	}
	//Methods
	public void Damage(int dmg)
	{
		if(currentHP > 0)
		{
			currentHP -= dmg;
			if(currentHP <= 0)//negative or 0
			{
				Debug.Log("DEAD");
				//should trigger player/unit death event
			}
		}
	}
	public void Heal(int heal)
	{
		if(currentHP < maxHP)//heals only when there is damage to heal
		{
			currentHP += heal;
			if(currentHP > maxHP)//when overhealed, set health to max
			{
				currentHP = maxHP;
				Debug.Log("OVERHEALED");
			}
		}
		else
		{
			Debug.Log("MAX HP");
		}
	}
	public void HPMaxInc(int up)
	{
		maxHP += up;
		currentHP += up;
	}
	public void HPMaxDec(int down)
	{
		maxHP -= down;
		if(currentHP > maxHP)
		{
			currentHP = maxHP;
			Debug.Log("HP CUT TO MAX");
		}
	}
}