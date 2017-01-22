using UnityEngine;
using System.Collections;

public class FlashlighManager : MonoBehaviour {
    [SerializeField]
    GameObject[] lanterns;
    [SerializeField]
    PlayerController pController;
    Scripts.colors current_color;
    Scripts.colors last_color = Scripts.colors.red;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (last_color != pController.fLColor)
        {
            lanterns[(int)last_color - 1].SetActive(false);
            last_color = pController.fLColor;
            lanterns[(int)last_color - 1].SetActive(true);
        }
	}
}
