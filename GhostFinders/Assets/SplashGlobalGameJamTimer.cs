using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashGlobalGameJamTimer : MonoBehaviour {
    float time = 2f;
    float elapsedTime = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= time)
        {
            SceneManager.LoadScene("Level_1");
        }
	}
}
