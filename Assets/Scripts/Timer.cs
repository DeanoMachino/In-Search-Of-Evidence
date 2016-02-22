using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{	
	//public SceneFadeInOut screenFader;	
	private float minutes, seconds, milliseconds;	// Minutes, seconds	and milliseconds
	private float totalTimePassed;					// Total time passed in seconds since level	
	private string timeString;						// Time string for display
	
	// Use this for initialization
	void Start ()
	{		
		minutes = 0;
		seconds = 0;
		milliseconds = 0;
		totalTimePassed = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Add delta time to time passed every frame
		totalTimePassed += Time.deltaTime;
		
		// Minutes and seconds passed for display
		minutes = Mathf.Floor (totalTimePassed / 60);
		seconds = Mathf.Floor(totalTimePassed % 60);
		milliseconds = Mathf.Floor(totalTimePassed * 1000 % 1000);
		
		timeString = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
	}
	
	void OnGUI()
	{
		GUI.Box(new Rect(0.0f, 0.0f, 75.0f, 25.0f), timeString);
	}
}