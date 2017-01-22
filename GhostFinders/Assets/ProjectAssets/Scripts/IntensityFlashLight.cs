using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntensityFlashLight : MonoBehaviour {

    [SerializeField]
    GameObject[] wavesGO;
    Image[] wavesImg;
    [SerializeField]
    PlayerController pController;

    Scripts.colors last_color = Scripts.colors.red;
    int currentIndex = 0;

    void Start ()
    {
        wavesImg = new Image[wavesGO.Length];
        for(int i = 0; i < wavesGO.Length; ++i)
        {
            wavesImg[i] = wavesGO[i].GetComponent<Image>();
        }
	}
	

	void Update ()
    {
        if (last_color != pController.fLColor)
        {
            last_color = pController.fLColor;
            //Tint
            wavesImg[currentIndex].color = Scripts.getColor(last_color);
        }

        float intense = pController.flashLight.intensity;
        if (intense >= 2.0f && intense < 4.5f)
        {
            wavesGO[currentIndex].SetActive(false);
            currentIndex = 0;
            wavesGO[currentIndex].SetActive(true);

            wavesImg[currentIndex].color = Scripts.getColor(last_color);
        }
        else if (intense >= 4.5f && intense < 7.0f)
        {
            wavesGO[currentIndex].SetActive(false);
            currentIndex = 1;
            wavesGO[currentIndex].SetActive(true);

            wavesImg[currentIndex].color = Scripts.getColor(last_color);
        }
        else if (intense >= 7.0f && intense <= 8.0f)
        {
            wavesGO[currentIndex].SetActive(false);
            currentIndex = 2;
            wavesGO[currentIndex].SetActive(true);

            wavesImg[currentIndex].color = Scripts.getColor(last_color);
        }
    }
    
}
