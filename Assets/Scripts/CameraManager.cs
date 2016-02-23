using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera/CameraManager")]

public class CameraManager : MonoBehaviour
{
	// Debug.Log( "(" + cameraPosition.x + ", " + cameraPosition.y + ", " + cameraPosition.z + ")" );

	// Public variables
	public float dragSensitivity; // 0.0025 works well
	public float zoomSpeed, minZoom, maxZoom; // 0.5, 1, 10
	public Camera thisCamera;

	// Private variables
	private Vector3 cameraPosition;
	private Vector3 lastMousePosition, currentMousePosition, differenceMousePosition;
	private bool panning;

	// Use this for initialization
	void Start ()
	{
		// Initialise camera position to position in Unity Editor
		cameraPosition = thisCamera.transform.position;

		// Initialise mouse position to origin
		lastMousePosition = new Vector3 (0, 0, 0);
		currentMousePosition = new Vector3 (0, 0, 0);
		differenceMousePosition = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Update current camera position each frame
		currentMousePosition = Input.mousePosition;

		Pan();
		Zoom();
	}

	void Pan()
	{
		// Camera translated by difference between current mouse position and last mouse position * -1 * sensitivity * zoom (Drag speed based on zoom)
		
		if (Input.GetMouseButtonDown(0))
		{
			// Set last mouse position to current mouse position for initial click
			lastMousePosition = currentMousePosition;
		}

		if  (Input.GetMouseButton(0))
		{
			// Calculate difference between current and last mouse position before translate and then update last mouse position to current
			differenceMousePosition = currentMousePosition - lastMousePosition;
			thisCamera.gameObject.transform.Translate(differenceMousePosition.x * -1 * dragSensitivity * thisCamera.orthographicSize, differenceMousePosition.y * -1 * dragSensitivity * thisCamera.orthographicSize, 0);
			lastMousePosition = currentMousePosition;
		}
	}

	void Zoom()
	{
		if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
		{
			// Zoom in
			thisCamera.orthographicSize -= zoomSpeed;
		}
		else if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
		{
			// Zoom out
			thisCamera.orthographicSize += zoomSpeed;
		}

		// Keep zoom within max and min zoom
		if(thisCamera.orthographicSize >= maxZoom)
		{
			thisCamera.orthographicSize = maxZoom;
		}
		else if(thisCamera.orthographicSize <= minZoom)
		{
			thisCamera.orthographicSize = minZoom;
		}
	}
}