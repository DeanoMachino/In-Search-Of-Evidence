using UnityEngine;
using System.Collections;

public class PoliceUI : MonoBehaviour
{
	private float totalPolice, availablePolice;
	private string policeString;

	// Use this for initialization
	void Start ()
	{
		// Initialise total police and available police to same number (all police available at start)
		totalPolice = 4;
		availablePolice = totalPolice;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Update police numbers here from game logic
		// totalPolice = ...
		// availablePolice = ...

		policeString = string.Format ("{0}/{1} Police", availablePolice, totalPolice);
	}

	void OnGUI()
	{
		GUI.Box(new Rect(85.0f, 0.0f, 75.0f, 25.0f), policeString);
	}
}