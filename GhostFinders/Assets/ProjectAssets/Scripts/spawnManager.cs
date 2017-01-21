using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawnManager : MonoBehaviour {
    [SerializeField]
    int minGhosts;
    [SerializeField]
    int maxGhosts;
    [SerializeField]
    GameObject ghost = null;
    [SerializeField]
    public int ghostCounter = 0;
    [SerializeField]
    public int ghostsHunted = 0;


    public List<GameObject> ghostList = null;
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
                ghostList.Add((GameObject)Instantiate(ghost, ts[item].position, ts[item].rotation));
            }            
        }
        ghostCounter = ghostList.Count;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void clearGhosts()
    {
        foreach (GameObject item in ghostList)
        {
            Destroy(item);
        }
    }
}
