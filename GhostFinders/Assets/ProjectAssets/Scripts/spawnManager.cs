using UnityEngine;
using System.Collections;

public class spawnManager : MonoBehaviour {
    [SerializeField]
    int minGhosts;
    [SerializeField]
    int maxGhosts;
    [SerializeField]
    GameObject ghost = null;
    public float ghostScore = 250;
    // Use this for initialization
    void Start () {
        Transform[] ts = gameObject.GetComponentsInChildren<Transform>();
       
        int nGhosts = Random.Range(minGhosts, maxGhosts);
        int[] spawnIndex= new int[nGhosts];
        //Això es una merda perque tenim son en angles home
        for (int i = 0; i < nGhosts; i++)
        {
            spawnIndex[i] = Random.Range(0, 26);   
        }

        foreach (int item in spawnIndex)
        {
            if (ghost != null)
            {
                GameObject go = (GameObject)Instantiate(ghost, ts[item].position, ts[item].rotation);
                go.GetComponent<Ghost>().ghostScore = ghostScore;
            }            
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
