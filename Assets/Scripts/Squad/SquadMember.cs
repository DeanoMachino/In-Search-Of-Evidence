using UnityEngine;
using System.Collections;

[AddComponentMenu("Squad/Squad Member")]

public class SquadMember : MonoBehaviour {

    // Public
	public SquadMemberState currentState = SquadMemberState.IDLE;
	public Task currentTask;

    // Private
    private float activateTime, currentTime, differenceTime;
    private float seconds, milliseconds;
    private bool isInspecting, taskCompleted;
    private string timeString;

	// Use this for initialization
	void Start ()
    {
        isInspecting = false;
        taskCompleted = false;
        currentTime = 0;
        activateTime = 0;
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

        /*if (isInspecting)
        {
            Inspect();
            currentState = SquadMemberState.INTERACTING;
        }*/

        currentTime += Time.deltaTime;
        differenceTime = currentTime - activateTime;
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

        switch (currentTask.type)
        {
            case(TaskType.DISCONNECT):
                break;
            case(TaskType.INSPECT):
                if (!isInspecting)
                {
                    StartInspect();
                }
                Inspect();
                break;
            case(TaskType.POWER_OFF):
                break;
            case(TaskType.SEIZE):
                currentTask.taskObject.SetActive(false);
                break;
            case(TaskType.TAKE_EVIDENCE):
                break;
            default:
                break;
        }                

		CompleteTask();
	}

    void StartInspect()
    {
        activateTime = currentTime;
        isInspecting = true;
        Debug.Log("Inspecting " + currentTask.taskObject.transform.tag);
    }

    void Inspect()
    {
        seconds = Mathf.Floor(differenceTime % 60);
        milliseconds = Mathf.Floor(differenceTime * 1000 % 1000);
        timeString = string.Format("{0:00}:{1:000}", seconds, milliseconds);

        if (differenceTime >= 5.0f)
        {
            isInspecting = false;
        }
    }

    void OnGUI()
    {
        if (isInspecting)
        {
            GUI.Box(new Rect(Screen.width/2, Screen.height/2, 75.0f, 25.0f), timeString);
        }
    }

}

public enum SquadMemberState
{
	IDLE,
	NAVIGATING,
	INTERACTING
}