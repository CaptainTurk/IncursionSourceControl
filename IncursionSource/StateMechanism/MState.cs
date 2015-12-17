using UnityEngine;
using System.Collections;

public abstract class MState<Type> //abstract for not allowing instantiation
{

	protected Type ownerObject;
	protected StateMachineMain<Type> ownerStateMachine;

	public abstract void CheckForNewState();

	public abstract void Update();

	public virtual void OnEnable(Type owner, StateMachineMain<Type> newStateMachine)
	{
	
		ownerObject = owner;
		ownerStateMachine = newStateMachine;

	}

	public virtual void OnDisable()

	{
		//
	}
}
