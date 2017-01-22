using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextAnim : MonoBehaviour {

    public Text txt;
    public string texto;
    public GameObject cont;
    public GameObject ant;
    public GameObject sig;
    bool click = false;
	// Use this for initialization
	void Start () {
        StartCoroutine(dictado(texto));
	}
	
	// Update is called once per frame
	void Update () {
        if (!cont.gameObject.activeSelf && click == true) cont.SetActive(true);

        if (Input.GetMouseButtonDown(0) && cont.gameObject.activeSelf)
        {
            ant.SetActive(false);
            cont.SetActive(false);
            sig.SetActive(true);
        }
    }

    IEnumerator dictado(string frase)
    {
        int letra = 0;
        txt.text = "";
        while (letra < frase.Length)
        {
            txt.text += frase[letra];
            letra += 1;
            yield return new WaitForSeconds(0.02f);
        }
        click = true;
    }

}
