﻿using UnityEngine;
using System.Collections;

public class Health_Script : Effect_Script {

	[SerializeField]
	private int myHealthValue, myDamageValue;

	[SerializeField]
	private Effect_Script[] myHealthEffects, myDamageEffects;

    public int currentHealth;
    public int currentMaxHealth;
    public int currentDamage;

    void Update()
    {
        Checkup();

        currentHealth = health - damage;
        currentMaxHealth = health;
        currentDamage = damage;
    }


	public int health
	{
		get
		{
			return Effect_Script.AffectsList(myHealthEffects, myHealthValue, gameObject, gameObject);
		}
	}

	public int damage
	{
		get
		{
			return Effect_Script.AffectsList(myDamageEffects, myDamageValue, gameObject, gameObject);
		}
	}

	public bool isDamaged
	{
		get
		{
			return damage > 0;
		}
	}

	public override int Affect(int input, GameObject inSubject, GameObject inObject)
	{
		return health - damage;
	}

	public void Checkup ()
	{
		if(health <= damage)
		{
            Debug.Log(gameObject.name + " has died!");
            if (gameObject.name != "EnemyPlayer"){
                transform.parent = GetComponent<Owner_Script>().myOwner.myGraveyard.transform;  
                transform.localPosition = Vector3.zero;
            }
		}
	}

	public void ApplyDamage(int input)
	{
		Term_Effect_Script termDamage = gameObject.AddComponent<Term_Effect_Script>();

		termDamage.myTerm = input;

		myDamageEffects = Effect_Script.Append(myDamageEffects, termDamage);
	}

}