using UnityEngine;
using System.Collections;

[AddComponentMenu("Squad/Squad Member")]

public class SquadMember : MonoBehaviour {

	public SquadMemberState currentState = SquadMemberState.IDLE;
	public Task currentTask;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch (currentState) {
			case SquadMemberState.IDLE:
				// Wander around
				break;
			case SquadMemberState.INTERACTING:
				Interact();
				break;
			case SquadMemberState.NAVIGATING:
				// If squad member is near object
				if(Vector3.Distance(gameObject.transform.position, currentTask.taskObject.transform.position) <= 2) {
					Debug.Log("NEAR OBJECT");
					// Interact with object and stop moving
					currentState = SquadMemberState.INTERACTING;
					gameObject.GetComponent<AISimpleLerp>().canMove = false;
				}
				break;
		}
	}

	public void GiveTask(Task t) {
		currentTask = t;
		currentState = SquadMemberState.NAVIGATING;

		// Set target position and allow squad member to move
		gameObject.GetComponent<AISimpleLerp>().target = t.taskObject.transform;
		gameObject.GetComponent<AISimpleLerp>().canMove = true;
	}

	public void CompleteTask() {
		currentTask.taskObject.GetComponent<EntityStats>().tasked = false;
		currentTask = null;
		currentState = SquadMemberState.IDLE;
	}

	void Interact() {

		CompleteTask();
	}


}

public enum SquadMemberState
{
	IDLE,
	NAVIGATING,
	INTERACTING
}