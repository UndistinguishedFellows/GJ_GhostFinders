using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Light flashLight = null;
    public Camera flashLightFrustum = null;

    Vector3 mouseScreenPos = Vector3.zero;

    //----------------------------

    void Start ()
    {
	
	}
	
	void Update ()
    {
        mouseScreenPos = Input.mousePosition;
        Debug.Log(mouseScreenPos);
	}

    void OnDrawGizmos()
    {

    }
}
