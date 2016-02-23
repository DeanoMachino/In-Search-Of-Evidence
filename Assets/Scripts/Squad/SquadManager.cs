using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Squad/Squad Manager")]

public class SquadManager : MonoBehaviour {

	public List<GameObject> squadList;
	public List<Task> taskList = new List<Task>();

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CheckTasks();
	}

	void OnGUI() {
		// Squad task box
		GUI.Box(new Rect(85.0f, 0.0f, 200.0f, 25.0f * (squadList.Count + 1)), "Squad (" + GetIdle() + "/" + squadList.Count + ")");
		for(int i = 0; i < squadList.Count; ++i) {
			if (squadList[i].GetComponent<SquadMember>().currentTask != null) {
				GUI.Box(new Rect(85.0f, 25.0f + (i * 25.0f), 200.0f, 25.0f),
					"Officer " + (i+1) + ": " + squadList[i].GetComponent<SquadMember>().currentTask.type.ToString() + " " + squadList[i].GetComponent<SquadMember>().currentTask.taskObject.transform.tag.ToString());
			} else {
				GUI.Box(new Rect(85.0f, 25.0f + (i * 25.0f), 200.0f, 25.0f),
					"Officer " + (i+1) + ": Idle");
			}
		}

		// Task list box
		GUI.Box(new Rect(Screen.width - 285.0f, 0.0f, 200.0f, 25.0f), "Task Queue (" + taskList.Count + ")");
		for (int i = 0; i < taskList.Count; ++i) {
			Debug.Log("Task Queue -- " + taskList.Count);
			GUI.Box(new Rect(Screen.width - 285.0f, 25.0f + i * 25.0f, 200.0f, 25.0f),
				(i+1) + ". " + taskList[i].type.ToString() + " " + taskList[i].taskObject.tag);
		}
	}

	public void AddTask(GameObject object_, TaskType type) {
		Task t = new Task(object_, type);
		taskList.Add(t);
	}

	public void CheckTasks() {
		// Check each polis for an idle
		foreach (GameObject g in squadList) {
			// If squad member is idle and there are tasks to complete
			if (g.GetComponent<SquadMember>().currentState == SquadMemberState.IDLE && taskList.Count > 0) {
				Debug.Log("CheckTasks: IDLE");
				// Get first task
				Task t = taskList[0];
				taskList.RemoveAt(0);
				// Give task to squad member
				g.GetComponent<SquadMember>().GiveTask(t);
			}
		}
	}

	int GetIdle() {
		// Get the number of squad members currently idle
		int idle = 0;

		foreach(GameObject g in squadList) {
			if(g.GetComponent<SquadMember>().currentState == SquadMemberState.IDLE) {
				++idle;
			}
		}

		return idle;
	}
}
