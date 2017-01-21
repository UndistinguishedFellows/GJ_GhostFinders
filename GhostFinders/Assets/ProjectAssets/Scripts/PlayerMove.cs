using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    float playerMoveSpeed = 5.0f;
	
	void Start ()
    {
	
	}
	
	void Update ()
    {
        //TODO: Would be cool to slow speed of facing direction is diferent to movement direction.

	    if(Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * playerMoveSpeed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.S))
        {
            transform.position -= Vector3.forward * playerMoveSpeed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.position -= Vector3.right * playerMoveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * playerMoveSpeed * Time.deltaTime;
        }
    }
}
