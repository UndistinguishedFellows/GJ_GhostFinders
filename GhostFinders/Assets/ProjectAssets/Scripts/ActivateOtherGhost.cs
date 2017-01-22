using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ActivateOtherGhost : MonoBehaviour {

    public Collider col;
    public GameObject ghost;
    public GameObject spawn;

    public GameObject exitLabel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!col.enabled)
        {
            exitLabel.SetActive(true);
            GameObject tmp = (GameObject)Instantiate(ghost, spawn.transform.position, spawn.transform.rotation);
            tmp.GetComponent<NavMeshAgent>().enabled = false;
            tmp.GetComponent<SteeringWander>().enabled = false;
            col = tmp.GetComponent<Collider>();
        }

        if (Input.GetKey(KeyCode.Escape)){
            SceneManager.LoadScene("MainMenu");
        }

    }
}
