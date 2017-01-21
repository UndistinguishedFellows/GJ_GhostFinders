using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    [SerializeField]
    float playerMoveSpeed = 5.0f;
    PlayerController plController = null;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
        if (plController.canMove && !plController.endGame)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(Vector3.forward * playerMoveSpeed);
            }

            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(-Vector3.forward * playerMoveSpeed);
            }

            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(-Vector3.right * playerMoveSpeed);
            }

            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(Vector3.right * playerMoveSpeed);
            }
        }
    }
}
