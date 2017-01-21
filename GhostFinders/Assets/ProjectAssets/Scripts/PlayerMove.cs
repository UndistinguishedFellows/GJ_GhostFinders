using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    float playerMoveSpeed = 5.0f;
    PlayerController plController = null;
	
    void Awake()
    {
        plController = GetComponentInChildren<PlayerController>();
    }

	void Start ()
    {
	    if(plController == null)
            plController = GetComponentInChildren<PlayerController>();
    }
	
	void Update ()
    {
        if (plController == null)
            plController = GetComponentInChildren<PlayerController>();

        //TODO: Would be cool to slow speed of facing direction is diferent to movement direction.
        if (plController.canMove)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Vector3.forward * playerMoveSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= Vector3.forward * playerMoveSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= Vector3.right * playerMoveSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * playerMoveSpeed * Time.deltaTime;
            }
        }
    }
}
