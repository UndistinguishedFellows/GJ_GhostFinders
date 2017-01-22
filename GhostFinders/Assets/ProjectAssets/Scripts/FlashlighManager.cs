using UnityEngine;
using System.Collections;

public class FlashlighManager : MonoBehaviour {
    [SerializeField]
    GameObject[] lanterns;
    [SerializeField]
    PlayerController pController;

    Scripts.colors last_color = Scripts.colors.red;

    void Start () {
	
	}
	

	void Update () {
        if (last_color != pController.fLColor)
        {
            lanterns[(int)last_color - 1].SetActive(false);
            last_color = pController.fLColor;
            lanterns[(int)last_color - 1].SetActive(true);
        }
	}
}
