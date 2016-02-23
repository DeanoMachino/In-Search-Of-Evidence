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
				// If close enough to object
				// Start interaction
				break;
		}
	}

	public void GiveTask(Task t) {
		currentTask = t;
		currentState = SquadMemberState.NAVIGATING;

		gameObject.GetComponent<AISimpleLerp>().target = t.taskObject.transform;
	}

	public void CompleteTask() {
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