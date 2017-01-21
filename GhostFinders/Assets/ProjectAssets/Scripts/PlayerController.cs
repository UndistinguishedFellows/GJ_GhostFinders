using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class PlayerController : MonoBehaviour {

    public Light flashLight = null;
    public Camera frustum = null;

    public LayerMask ghostMask;

    Vector3 lastFrameMousePos = Vector3.zero;
    float lastFrameMouseWheel = 0;

    Scripts.DIRECTION direction = Scripts.DIRECTION.D_UNKNOWN;

    Color flashLightColor = Color.white;
    Scripts.colors fLColor = Scripts.colors.blue;

    private List<GameObject> ghostsDetected;
    private List<GameObject> ghostsDetectedNow;
    private Ray ray;


    //----------------------------

    void Awake()
    {
        ghostsDetected = new List<GameObject>();
        ghostsDetectedNow = new List<GameObject>();
        ray = new Ray();
    }

    void Start ()
    {
	
	}
	
	void Update ()
    {
        handleInput();  //TODO: Maybe only handle input every certain ammount of time.

        checkForGhosts();   //TODO: Maybe only check ghosts every certain ammount of time, prob is more important to limit this than limit input.

    }

    void OnDrawGizmos()
    {

    }

    //---------------------------------

    void calcDirection(Vector3 dir)
    {
        float angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;

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
            direction = Scripts.DIRECTION.D_UNKNOWN;
    }

    void handleInput()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.y = 0;

        if (mousePos != lastFrameMousePos)
        {
            lastFrameMousePos = mousePos;
            Vector3 dir = mousePos - transform.position;
            dir.Normalize();
            dir.y = 0;
            transform.LookAt(dir * 100);

            calcDirection(dir);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            fLColor = (Scripts.colors)1;
            flashLightColor = Scripts.getColor(fLColor);
            flashLight.color = flashLightColor;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            fLColor = (Scripts.colors)2;
            flashLightColor = Scripts.getColor(fLColor);
            flashLight.color = flashLightColor;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            fLColor = (Scripts.colors)3;
            flashLightColor = Scripts.getColor(fLColor);
            flashLight.color = flashLightColor;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            fLColor = (Scripts.colors)4;
            flashLightColor = Scripts.getColor(fLColor);
            flashLight.color = flashLightColor;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
        {
            fLColor = (Scripts.colors)5;
            flashLightColor = Scripts.getColor(fLColor);
            flashLight.color = flashLightColor;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
        {
            fLColor = (Scripts.colors)6;
            flashLightColor = Scripts.getColor(fLColor);
            flashLight.color = flashLightColor;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if ((int)fLColor == 1)
                fLColor = (Scripts.colors)6;
            else
                fLColor -= 1;

            flashLightColor = Scripts.getColor(fLColor);
            flashLight.color = flashLightColor;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if ((int)fLColor == 6)
                fLColor = (Scripts.colors)1;
            else
                fLColor += 1;

            flashLightColor = Scripts.getColor(fLColor);
            flashLight.color = flashLightColor;
        }

        float wheel = Input.GetAxis("Mouse ScrollWheel");
        if (wheel != lastFrameMouseWheel)
        {
            lastFrameMouseWheel = wheel;

            if (wheel > 0)
            {
                if ((int)fLColor == 6)
                    fLColor = (Scripts.colors)1;
                else
                    fLColor += 1;

                flashLightColor = Scripts.getColor(fLColor);
                flashLight.color = flashLightColor;
            }
            else if (wheel < 0)
            {
                if ((int)fLColor == 1)
                    fLColor = (Scripts.colors)6;
                else
                    fLColor -= 1;

                flashLightColor = Scripts.getColor(fLColor);
                flashLight.color = flashLightColor;
            }
        }
    }

    void checkForGhosts()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, frustum.farClipPlane, ghostMask);
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(frustum);

        ghostsDetectedNow.Clear();

        foreach (Collider col in colliders)
        {
            if (col.gameObject != gameObject && GeometryUtility.TestPlanesAABB(planes, col.bounds))
            {
                RaycastHit hit;
                ray.origin = transform.position;
                ray.direction = (col.transform.position - transform.position).normalized;
                ray.origin = ray.GetPoint(frustum.nearClipPlane);

                if (Physics.Raycast(ray, out hit, frustum.farClipPlane, ghostMask))
                {
                    if (hit.collider.gameObject.CompareTag("Ghost"))
                        ghostsDetectedNow.Add(col.gameObject);
                }
            }
        }

        // Compare detected with detected_now -------------------------------------
        foreach (GameObject go in ghostsDetectedNow)
        {
            if (ghostsDetected.Contains(go) == false)
            {
                //New ghost seen
                go.GetComponent<Ghost>().onGhostDetected(fLColor);
            }
        }

        foreach (GameObject go in ghostsDetected)
        {
            if (ghostsDetectedNow.Contains(go) == false)
            {
                //Ghost lost
                go.GetComponent<Ghost>().onGhostLost();
            }

        }

        ghostsDetected.Clear();
        ghostsDetected.AddRange(ghostsDetectedNow);
    }


    //--------------------------------
}
