using UnityEngine;
using System.Collections;

public class ChargePlayer : MState<Enemy> {

	public override void CheckForNewState(){
		if ((ownerObject.transform.position - ownerObject.target.position).sqrMagnitude > 100)
		{
			ownerStateMachine.CurrentState = new FollowPath();
		}
	}

	public override void Update(){

		//empty update

	}

	public override void OnEnable(Enemy owner, StateMachineMain<Enemy> newStateMachineMain) {
		base.OnEnable(owner, newStateMachineMain);

		owner.target = Object.FindObjectOfType<Player>().transform; 
	}	                             
}
