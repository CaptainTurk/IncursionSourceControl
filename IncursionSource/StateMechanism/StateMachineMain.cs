using UnityEngine;
using System.Collections;

public class StateMachineMain <Type>
{
	Type ownerObject;
	private MState<Type> currentState;
	public MState<Type> CurrentState  //property
	{
		get	{
			return currentState;
		}
		set	{
			if (currentState != null) {
				currentState.OnDisable();
		}
				currentState = value;
				if (currentState != null)
				{
					currentState.OnEnable(ownerObject, this);

				}

			}

		}
		//Constructer
		public StateMachineMain(MState<Type> defaultState, Type owner)
		{
			ownerObject = owner;
			CurrentState = defaultState;
		}

		public void Update(){
				if (currentState != null){
				currentState.CheckForNewState();
				currentState.Update();

			}

		}

}
