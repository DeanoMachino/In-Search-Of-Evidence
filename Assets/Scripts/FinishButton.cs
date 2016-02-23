using UnityEngine;
using System.Collections;

public class FinishButton : MonoBehaviour
{

    // Public

    // Private
    bool isFinishMessageVisible;
    private float displayScore;
    private string displayString;

	// Use this for initialization
	void Start ()
    {
        isFinishMessageVisible = false;
        displayScore = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        displayScore = this.GetComponent<ScoreManager>().totalScore;
        displayString = ("Score: " + displayScore);
	}
  
    void OnGUI()
    {
        if(GUI.Button(new Rect(Screen.width - 105.0f, Screen.height - 30.0f, 75.0f, 25.0f), "Finish"))
        {
            isFinishMessageVisible = !isFinishMessageVisible;
        }

        if (isFinishMessageVisible)
        {
            GUI.Box(new Rect(85.0f, Screen.height - 100.0f, 75.0f, 25.0f), displayString);
        }
    }
}
