using UnityEngine;
using System.Collections;

public class FinishButton : MonoBehaviour
{

    // Public

    // Private
    bool isFinishMessageVisible;

	// Use this for initialization
	void Start ()
    {
        isFinishMessageVisible = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
  
    void OnGUI()
    {
        if(GUI.Button(new Rect(Screen.width - 105.0f, Screen.height - 30.0f, 75.0f, 25.0f), "Finish"))
        {
            isFinishMessageVisible = !isFinishMessageVisible;
        }

        if (isFinishMessageVisible)
        {
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 150.0f, 25.0f), "Radiators are warm");
        }
    }
}
