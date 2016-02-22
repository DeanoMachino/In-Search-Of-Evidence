using UnityEngine;
using System.Collections;

public class Waddle : MonoBehaviour
{
	private Vector3 lastPosition, currentPosition;
	private bool isWaddling;

	// Use this for initialization
	void Start ()
	{
		lastPosition = this.gameObject.transform.position;
		currentPosition = this.gameObject.transform.position;
		isWaddling = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		lastPosition = currentPosition;
		currentPosition = this.gameObject.transform.position;

		if (currentPosition.x != lastPosition.x || currentPosition.z != lastPosition.z)
		{
			isWaddling = true;
		}
		else
		{
			isWaddling = false;
		}

		if (isWaddling)
		{
			// Waddle logic here
		}
	}
}
