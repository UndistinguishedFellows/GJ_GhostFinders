using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsThings : MonoBehaviour {

    bool exitGame = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(exitGame) Application.Quit();

    }

    public void play()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void tuto()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void exit()
    {
        Debug.Log("EXIT");
        Application.Quit();
        exitGame = false;
    }

}
