using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(CapsuleCollider), typeof(Rigidbody))]
public class Enemy : MonoBehaviour {

	private bool isOnGround;
	private Vector3 lookPosition;
	private Vector3 moveInput;
	private float turnAmount;
	private Vector3 velocity;

	public NavMeshAgent agent { get; private set;}

	public Transform target;
	public float targetChangeTolerance = 1;
	private Vector3 targetPosition;

	public List<Transform> pathNodes = new List<Transform>();
	private StateMachineMain<Enemy> stateMachine;

	class RayHitComparer : IComparer{
		public int Compare(object x, object y){
		
			return ((RaycastHit)x).distance.CompareTo(((RaycastHit)y).distance);
		}
	}

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		stateMachine = new StateMachineMain<Enemy> (new FollowPath(), this);
	}

	public void Move(Vector3 desiredVelocity, Vector3 lookPos){
		moveInput = velocity = desiredVelocity;
		lookPosition = lookPos;

		ConvertMoveInput();
		GroundCheck();

		if (isOnGround) {
			HandleGroundVelocity ();
		} else {
			HandleAirVelocity();		
		}
		GetComponent<Rigidbody>().velocity = velocity;
			
	}

	void ConvertMoveInput(){
	
		Vector3 localMove = transform.InverseTransformDirection (moveInput);
		turnAmount = Mathf.Atan2 (localMove.x, localMove.z);
	}
	void GroundCheck()
	{
		Ray ray = new Ray (transform.position + Vector3.up * 0.1f, -Vector3.up);
		RaycastHit[] hits = Physics.RaycastAll (ray, 0.5f);

		if (velocity.y < 5.0f) {
			isOnGround = false;
				
			GetComponent<Rigidbody>().useGravity = true;

			foreach (RaycastHit hit in hits){
				if (!hit.collider.isTrigger){
					if (velocity.y <= 0) {
						GetComponent<Rigidbody>().position = Vector3.MoveTowards (GetComponent<Rigidbody>().position, hit.point, Time.deltaTime * 5.0f);
					}
					isOnGround = true;
					GetComponent<Rigidbody>().useGravity = false;
				}
			}
		}	
	}

	void HandleGroundVelocity(){
		velocity.y = 0;

		if (Mathf.Approximately(moveInput.magnitude, 0)) {
			velocity.x = 0;
			velocity.z = 0;		
		}	
	}
	void HandleAirVelocity(){
		Vector3 airMove = new Vector3 (moveInput.x, velocity.y, moveInput.z);
		velocity = Vector3.Lerp (velocity, airMove, Time.deltaTime);
		GetComponent<Rigidbody>().useGravity = true;			
	}
	
	// Update is called once per frame
	void Update () {

		if (target != null) {
			if ((target.position - targetPosition).magnitude > targetChangeTolerance) {
				targetPosition = target.position;
				agent.SetDestination (targetPosition);
			}

			agent.transform.position = transform.position;
			Move (agent.desiredVelocity, targetPosition);
		} else {		
			Move(Vector3.zero, transform.position + transform.forward * 100);
		}

		transform.Rotate (0.0f, turnAmount * 180 * Time.deltaTime, 0.0f);
		stateMachine.Update ();

		//stateMachine.Update();
	}


}
