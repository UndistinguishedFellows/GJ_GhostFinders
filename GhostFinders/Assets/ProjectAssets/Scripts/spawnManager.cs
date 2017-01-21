using UnityEngine;
using System.Collections;

public class spawnManager : MonoBehaviour {
    [SerializeField]
    int minGhosts;
    [SerializeField]
    int maxGhosts;
    [SerializeField]
    GameObject ghost = null;
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
                Instantiate(ghost, ts[item].position, ts[item].rotation);
            }            
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
