using UnityEngine;
using System.Collections;

public class FlashlighManager : MonoBehaviour {
    [SerializeField]
    GameObject[] lanterns;
    [SerializeField]
    PlayerController pController;

    Scripts.colors last_color = Scripts.colors.unknown;

    void Start () {
        /*lanterns[(int)Scripts.colors.red - 1].SetActive(false);
        last_color = pController.fLColor;
        lanterns[(int)last_color - 1].SetActive(true);*/
    }
	

	void Update () {
        if (last_color != pController.fLColor)
        {
            if ((int)last_color - 1 < 0)
                last_color = (Scripts.colors)1;

            lanterns[(int)last_color - 1].SetActive(false);
            last_color = pController.fLColor;
            lanterns[(int)last_color - 1].SetActive(true);
        }
	}
}
