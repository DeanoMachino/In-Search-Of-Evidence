using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Squad/Squad Manager")]

public class SquadManager : MonoBehaviour {

	public List<GameObject> squadList = new List<GameObject>();
	public List<Task> taskList = new List<Task>();

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CheckTasks();
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
}
