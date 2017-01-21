using UnityEngine;
using System.Collections;



public class Ghost : MonoBehaviour {
    [SerializeField]
    public Scripts.colors type;
    Color sprite;
    [SerializeField]
    GameObject eyes;
    [SerializeField]
    GameObject body;

    public float ghostScore = 25.0f; //This valor should be assigned from a "Ghost manager"

    //------------------------------------------

    void Start ()
    {
        //Random ghost type at spawn
        type = (Scripts.colors)Random.Range(1, 6);        
        switch (type)
        {
            case Scripts.colors.blue:
                sprite = Scripts.getColor(Scripts.colors.blue);
                break;
            case Scripts.colors.red:
                sprite = Scripts.getColor(Scripts.colors.red);
                break;
            case Scripts.colors.green:
                sprite = Scripts.getColor(Scripts.colors.green);
                break;
            case Scripts.colors.cyan:
                sprite = Scripts.getColor(Scripts.colors.cyan);
                break;
            case Scripts.colors.magenta:
                sprite = Scripts.getColor(Scripts.colors.magenta);
                break;
            case Scripts.colors.yellow:
                sprite = Scripts.getColor(Scripts.colors.yellow);
                break;
            default:
                break;
        }
        eyes.GetComponent<SpriteRenderer>().color = sprite;
        Color eyesColor = eyes.GetComponent<SpriteRenderer>().color;
        eyesColor.a = 0;
        eyes.GetComponent<SpriteRenderer>().color = eyesColor;
    }
	
	void Update ()
    {
               
    }

    //------------------------------------------

    public void onGhostDetected(Scripts.colors flashLightColor)
    {
        Debug.Log("Ghost seen!");
        float multiplier = 0.0f;
        switch (type) //Switch ghost color will calc the points multiplier
        {
            case Scripts.colors.blue:
                if (flashLightColor == Scripts.colors.yellow)
                    multiplier = 1.0f;
                else if (flashLightColor == Scripts.colors.red || flashLightColor == Scripts.colors.green)
                    multiplier = 0.5f;
                else if (flashLightColor == Scripts.colors.magenta || flashLightColor == Scripts.colors.cyan)
                    multiplier = 0.25f;
                else
                    multiplier = 0.1f;
                break;

            case Scripts.colors.red:
                if (flashLightColor == Scripts.colors.cyan)
                    multiplier = 1.0f;
                else if (flashLightColor == Scripts.colors.blue || flashLightColor == Scripts.colors.green)
                    multiplier = 0.5f;
                else if (flashLightColor == Scripts.colors.magenta || flashLightColor == Scripts.colors.yellow)
                    multiplier = 0.25f;
                else
                    multiplier = 0.1f;
                break;

            case Scripts.colors.green:
                if (flashLightColor == Scripts.colors.magenta)
                    multiplier = 1.0f;
                else if (flashLightColor == Scripts.colors.blue || flashLightColor == Scripts.colors.red)
                    multiplier = 0.5f;
                else if (flashLightColor == Scripts.colors.cyan || flashLightColor == Scripts.colors.yellow)
                    multiplier = 0.25f;
                else
                    multiplier = 0.1f;
                break;

            case Scripts.colors.cyan:
                if (flashLightColor == Scripts.colors.red)
                    multiplier = 1.0f;
                else if (flashLightColor == Scripts.colors.magenta || flashLightColor == Scripts.colors.yellow)
                    multiplier = 0.5f;
                else if (flashLightColor == Scripts.colors.green || flashLightColor == Scripts.colors.blue)
                    multiplier = 0.25f;
                else
                    multiplier = 0.1f;
                break;

            case Scripts.colors.magenta:
                if (flashLightColor == Scripts.colors.green)
                    multiplier = 1.0f;
                else if (flashLightColor == Scripts.colors.blue || flashLightColor == Scripts.colors.red)
                    multiplier = 0.5f;
                else if (flashLightColor == Scripts.colors.cyan || flashLightColor == Scripts.colors.yellow)
                    multiplier = 0.25f;
                else
                    multiplier = 0.1f;
                break;

            case Scripts.colors.yellow:
                if (flashLightColor == Scripts.colors.blue)
                    multiplier = 1.0f;
                else if (flashLightColor == Scripts.colors.magenta || flashLightColor == Scripts.colors.cyan)
                    multiplier = 0.5f;
                else if (flashLightColor == Scripts.colors.red || flashLightColor == Scripts.colors.green)
                    multiplier = 0.25f;
                else
                    multiplier = 0.1f;
                break;

            default:
                break;
        }

        Color eyesColor = eyes.GetComponent<SpriteRenderer>().color;
        eyesColor.a = multiplier;        
        eyes.GetComponent<SpriteRenderer>().color = eyesColor;

        Color bodyColor = body.GetComponent<SpriteRenderer>().color;
        bodyColor.a = multiplier;
        body.GetComponent<SpriteRenderer>().color = bodyColor;
    }

    public void onGhostLost()
    {
        Debug.Log("Ghost lost...");
        Color eyesColor = eyes.GetComponent<SpriteRenderer>().color;
        eyesColor.a = 0;
        eyes.GetComponent<SpriteRenderer>().color = eyesColor;

        Color bodyColor = body.GetComponent<SpriteRenderer>().color;
        bodyColor.a = 0;
        body.GetComponent<SpriteRenderer>().color = bodyColor;
    }

    public float onPhotoTaken(Scripts.colors flashLightColor)
    {
        Debug.Log("Photo taken!");

        //1.Disable collider so that next frame wont be detected.
        GetComponent<Collider>().enabled = false;

        //2.Calc % of points you may get.
        /*
         -Oposite: 100%
         -Next to oposite: 50%
         -Next to same color: 25%
         -Same color: 10%
         */

        float multiplier = 0.0f;

        switch (type) //Switch ghost color will calc the points multiplier
        {
            case Scripts.colors.blue:
                if (flashLightColor == Scripts.colors.yellow)
                    multiplier = 1.0f;
                else if (flashLightColor == Scripts.colors.red || flashLightColor == Scripts.colors.green)
                    multiplier = 0.5f;
                else if (flashLightColor == Scripts.colors.magenta || flashLightColor == Scripts.colors.cyan)
                    multiplier = 0.25f;
                else
                    multiplier = 0.1f;
                break;

            case Scripts.colors.red:
                if (flashLightColor == Scripts.colors.cyan)
                    multiplier = 1.0f;
                else if (flashLightColor == Scripts.colors.blue || flashLightColor == Scripts.colors.green)
                    multiplier = 0.5f;
                else if (flashLightColor == Scripts.colors.magenta || flashLightColor == Scripts.colors.yellow)
                    multiplier = 0.25f;
                else
                    multiplier = 0.1f;
                break;

            case Scripts.colors.green:
                if (flashLightColor == Scripts.colors.magenta)
                    multiplier = 1.0f;
                else if (flashLightColor == Scripts.colors.blue || flashLightColor == Scripts.colors.red)
                    multiplier = 0.5f;
                else if (flashLightColor == Scripts.colors.cyan || flashLightColor == Scripts.colors.yellow)
                    multiplier = 0.25f;
                else
                    multiplier = 0.1f;
                break;

            case Scripts.colors.cyan:
                if (flashLightColor == Scripts.colors.red)
                    multiplier = 1.0f;
                else if (flashLightColor == Scripts.colors.magenta || flashLightColor == Scripts.colors.yellow)
                    multiplier = 0.5f;
                else if (flashLightColor == Scripts.colors.green || flashLightColor == Scripts.colors.blue)
                    multiplier = 0.25f;
                else
                    multiplier = 0.1f;
                break;

            case Scripts.colors.magenta:
                if (flashLightColor == Scripts.colors.green)
                    multiplier = 1.0f;
                else if (flashLightColor == Scripts.colors.blue || flashLightColor == Scripts.colors.red)
                    multiplier = 0.5f;
                else if (flashLightColor == Scripts.colors.cyan || flashLightColor == Scripts.colors.yellow)
                    multiplier = 0.25f;
                else
                    multiplier = 0.1f;
                break;

            case Scripts.colors.yellow:
                if (flashLightColor == Scripts.colors.blue)
                    multiplier = 1.0f;
                else if (flashLightColor == Scripts.colors.magenta || flashLightColor == Scripts.colors.cyan)
                    multiplier = 0.5f;
                else if (flashLightColor == Scripts.colors.red || flashLightColor == Scripts.colors.green)
                    multiplier = 0.25f;
                else
                    multiplier = 0.1f;
                break;

            default:
                break;
        }

        return ghostScore * multiplier;
    }


    //------------------------------------------
}
