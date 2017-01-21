﻿using UnityEngine;
using System.Collections;



public class PlayerController : MonoBehaviour {

    public Light flashLight = null;
    public Camera flashLightFrustum = null;

    Vector3 lastFrameMousePos = Vector3.zero;
    Scripts.DIRECTION direction = Scripts.DIRECTION.D_UNKNOWN;

    //----------------------------

    void Start ()
    {
	
	}
	
	void Update ()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.y = 0;

        if (mousePos != lastFrameMousePos)
        {
            lastFrameMousePos = mousePos;
            Vector3 dir = mousePos - transform.position;
            dir.Normalize();
            dir.y = 0;

            float angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
            transform.LookAt(dir * 100);
            


            if (angle < 22.5 && angle > -22.5)
                direction = Scripts.DIRECTION.D_RIGHT;
            else if (angle >= 22.5 && angle <= 67.5)
                direction = Scripts.DIRECTION.D_UP_RIGHT;
            else if (angle > 67.5 && angle < 112.5)
                direction = Scripts.DIRECTION.D_UP;
            else if (angle >= 112.5 && angle <= 157.5)
                direction = Scripts.DIRECTION.D_UP_LEFT;
            else if (angle > 157.5 || angle < -157.5)
                direction = Scripts.DIRECTION.D_LEFT;
            else if (angle >= -157.5 && angle <= -112.5)
                direction = Scripts.DIRECTION.D_DOWN_LEFT;
            else if (angle > -112.5 && angle < -67.5)
                direction = Scripts.DIRECTION.D_DOWN;
            else if (angle >= -67.5 && angle <= -22.5)
                direction = Scripts.DIRECTION.D_DOWN_RIGHT;
            else
                direction = DIRECTION.D_UNKNOWN;

            switch (direction)
            {
                case Scripts.DIRECTION.D_UP:
                    Debug.Log("UP");
                    break;
                case Scripts.DIRECTION.D_UP_RIGHT:
                    Debug.Log("D_UP_RIGHT");
                    break;
                case Scripts.DIRECTION.D_RIGHT:
                    Debug.Log("D_RIGHT");
                    break;
                case Scripts.DIRECTION.D_DOWN_RIGHT:
                    Debug.Log("D_DOWN_RIGHT");
                    break;
                case Scripts.DIRECTION.D_DOWN:
                    Debug.Log("D_DOWN");
                    break;
                case Scripts.DIRECTION.D_DOWN_LEFT:
                    Debug.Log("D_DOWN_LEFT");
                    break;
                case Scripts.DIRECTION.D_LEFT:
                    Debug.Log("D_LEFT");
                    break;
                case Scripts.DIRECTION.D_UP_LEFT:
                    Debug.Log("D_UP_LEFT");
                    break;
                case Scripts.DIRECTION.D_UNKNOWN:
                    Debug.Log("D_UNKNOWN");
                    break;
            }

        }
        
    }

    void OnDrawGizmos()
    {

    }
}