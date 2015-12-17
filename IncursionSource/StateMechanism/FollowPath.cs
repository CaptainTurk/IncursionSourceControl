using UnityEngine;
using System.Collections;

public class FollowPath : MState<Enemy> {

	int nodeIndex = 0; // How many nodes to follow

	public override void CheckForNewState()
	{
		Collider[] otherObjects = Physics.OverlapSphere(ownerObject.transform.position, 8.0f, 1 << LayerMask.NameToLayer("Characters"));

		for (int i = 0; i < otherObjects.Length; i++) {
		
			if(otherObjects [i].GetComponent<Player>() != null){

				ownerStateMachine.CurrentState = new ChargePlayer();

			}
		
		}

	}

	public override void Update()
	{
		if ((ownerObject.pathNodes [nodeIndex].position - ownerObject.transform.position).sqrMagnitude < 1) {		
			nodeIndex++;

			if (nodeIndex >= ownerObject.pathNodes.Count){
				nodeIndex = 0; // the amount of the nodes
			}
			ownerObject.target = ownerObject.pathNodes[nodeIndex];
		}
	}

	public override void OnEnable(Enemy owner, StateMachineMain<Enemy> newStateMachineMain){
		base.OnEnable (owner, newStateMachineMain);
		float closestDistance = float.MaxValue;

		for (int i = 0; i < owner.pathNodes.Count; i++) {

			//Move to the closest Path Node first in distance.
			float currentDistance = (owner.transform.position - owner.pathNodes[i].position).sqrMagnitude;

			if (currentDistance < closestDistance){
				closestDistance = currentDistance;
				nodeIndex = i;
			}
		}

		ownerObject.target = owner.pathNodes [nodeIndex];
	}

}
