using UnityEngine;
using System.Collections;

public class Waddle : MonoBehaviour
{
	// Public
	public float waddleAmount, waddleSpeed;

	// Private
	private Vector3 lastPosition, currentPosition;
	private bool isWaddling, positiveRotation;
	private float currentRotation;

	// Use this for initialization
	void Start ()
	{
		lastPosition = this.gameObject.transform.position;
		currentPosition = this.gameObject.transform.position;
		isWaddling = false;
		positiveRotation = true;
        currentRotation = this.transform.rotation.z;
	}
	
	// Update is called once per frame
	void Update ()
	{
		lastPosition = currentPosition;
		currentPosition = this.gameObject.transform.position;
		currentRotation = this.gameObject.transform.rotation.z;

		if (currentPosition.x == lastPosition.x && currentPosition.z == lastPosition.z)
		{
			isWaddling = false;
		}
		else 
		{
			isWaddling = true;
		}

        if (currentRotation >= waddleAmount) 
        {
            positiveRotation = false;
        }
        else if (currentRotation <= -waddleAmount)
        {
            positiveRotation = true;
        }

		if (isWaddling)
		{  
            if (positiveRotation)
			{
				this.gameObject.transform.Rotate (new Vector3 (0, 0, waddleSpeed));
			} 
			else if (!positiveRotation)
			{
                this.gameObject.transform.Rotate (new Vector3 (0, 0, -waddleSpeed));
			}
		}
	}
}
