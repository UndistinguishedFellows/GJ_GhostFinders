using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    [SerializeField]
    float playerMoveSpeed = 5.0f;
    PlayerController plController = null;
    Rigidbody rb;
    [SerializeField]
    Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        plController = GetComponentInChildren<PlayerController>();
    }

	void Start ()
    {
        anim = GetComponentInChildren<Animator>();
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
                anim.SetInteger("State", 1);
                rb.AddForce(Vector3.forward * playerMoveSpeed);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetInteger("State", 0);
            }

            if (Input.GetKey(KeyCode.S))
            {
                anim.SetInteger("State", 1);
                rb.AddForce(-Vector3.forward * playerMoveSpeed);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                anim.SetInteger("State", 0);
            }

            if (Input.GetKey(KeyCode.A))
            {
                anim.SetInteger("State", 1);
                rb.AddForce(-Vector3.right * playerMoveSpeed);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                anim.SetInteger("State", 0);
            }

            if (Input.GetKey(KeyCode.D))
            {
                anim.SetInteger("State", 1);
                rb.AddForce(Vector3.right * playerMoveSpeed);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                anim.SetInteger("State", 0);
            }
        }
    }
}
