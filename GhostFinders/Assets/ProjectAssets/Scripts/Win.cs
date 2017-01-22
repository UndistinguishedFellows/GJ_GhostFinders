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

    public GameObject menu;

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

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (menu.activeSelf) menu.SetActive(false);
                else menu.SetActive(true);
            }   
            


        }
        float t = Mathf.Round(timeLeft * 1.0f) / 1.0f;
        timer.text = t.ToString();
        ghostsLeft.text = "Ghosts: " + spawner.GetComponent<spawnManager>().ghostCounter.ToString();
        points.text = lb.currentScore.points.ToString("#.##");

        if (endGame)
        {
            spawner.GetComponent<spawnManager>().clearGhosts();
        }
	}
}
