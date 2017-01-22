using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour {

    bool exitGame = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(exitGame) Application.Quit();

    }

    public void onClick()
    {
        Debug.Log("EXIT");
        Application.Quit();
        exitGame = false;
    }

}
