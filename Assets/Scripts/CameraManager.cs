using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera/CameraManager")]

public class CameraManager : MonoBehaviour
{
	// Debug.Log("(" + cameraPosition.x + ", " + cameraPosition.y + ", " + cameraPosition.z + ")");

	// Public variables
	public float zoomSpeed, minZoom, maxZoom;
	public Camera thisCamera;

	// Private variables
	private Vector3 cameraPosition;
	private bool panning;

	// Use this for initialization
	void Start ()
	{
		// Initialise camera position to position in Unity Editor
		cameraPosition = thisCamera.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Pan();
		Zoom();
	}

	// LateUpdate is called once per frame after Update
	void LateUpdate()
	{
		// Update camera position at the end of every frame
		thisCamera.transform.position = cameraPosition;
	}

	void Pan()
	{

	}

	void Zoom()
	{
		if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
		{
			thisCamera.orthographicSize -= zoomSpeed;
		}
		else if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
		{
			thisCamera.orthographicSize += zoomSpeed;
		}

		if(thisCamera.orthographicSize >= maxZoom)
		{
			thisCamera.orthographicSize = maxZoom;
		}

		if(thisCamera.orthographicSize <= minZoom)
		{
			thisCamera.orthographicSize = minZoom;
		}
	}
}