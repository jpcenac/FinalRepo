﻿using UnityEngine;
using System.Collections;

public class Finite_State_Machine_Script : MonoBehaviour {

	[SerializeField]
	//a reference is an enumeration right?
	protected Finite_State_Script myCurrentState;

	void Update()
	{
		if (myCurrentState)
		{
			myCurrentState.enabled = true;
		}
	}

	public Finite_State_Script CurrentState
	{
		get
		{
			return myCurrentState;
		}

		set
		{
			Finite_State_Script nextState = value;

			if(myCurrentState)
			{
				if (myCurrentState.IsValidTransition(nextState))
				{
					myCurrentState.Leave();

					myCurrentState.enabled = false;

					myCurrentState = nextState;

					myCurrentState.enabled = true;

					myCurrentState.Enter();
				}
			}
			else
			{
				myCurrentState = nextState;

				myCurrentState.enabled = true;

				myCurrentState.Enter();
			}
		}
	}
}
