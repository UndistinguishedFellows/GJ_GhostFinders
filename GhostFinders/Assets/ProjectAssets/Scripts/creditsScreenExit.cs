using UnityEngine;
using System.Collections;

public class creditsScreenExit : MonoBehaviour {
    float time = 5;
    float elapsedTime = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= time)
        {
            Application.Quit();
        }
	}
}
