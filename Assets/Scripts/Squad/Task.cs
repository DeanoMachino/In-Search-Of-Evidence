using UnityEngine;
using System.Collections;

public class Task {

	public GameObject taskObject;
	public TaskType type;
	public bool completed = false;

	public Task(GameObject object_, TaskType type_) {
		taskObject = object_;
		type = type_;
	}
}

public enum TaskType {
	INSPECT,
	SEIZE,
	TAKE_EVIDENCE,
	DISCONNECT,
	POWER_OFF
}