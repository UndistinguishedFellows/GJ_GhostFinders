using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Win : MonoBehaviour {
    [SerializeField]
    public bool endGame = false;
    [SerializeField]
    GameObject player = null;
    [SerializeField]
    GameObject spawner = null;
    [SerializeField]
    float timeLeft = 0;
    [SerializeField]
    Text timer = null;
    [SerializeField]
    Text ghostsLeft = null;
    [SerializeField]
    Text points = null;
    [SerializeField]
    LeadBoard lb = null;
    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        
        if (!endGame)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                timeLeft = 0;
                endGame = true;
                lb.onLevelEnd();
            }
        }
        float t = Mathf.Round(timeLeft * 1.0f) / 1.0f;
        timer.text = t.ToString() + " seconds";
        ghostsLeft.text = "Ghosts left: " + spawner.GetComponent<spawnManager>().ghostCounter.ToString();
        points.text = "Points: " + lb.currentScore.points.ToString();

        if (endGame)
        {
            spawner.GetComponent<spawnManager>().clearGhosts();
        }
	}
}
