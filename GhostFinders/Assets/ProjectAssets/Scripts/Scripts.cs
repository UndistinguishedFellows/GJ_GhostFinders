using UnityEngine;
using System.Collections;



public class Scripts : MonoBehaviour {    
    public enum colors
    {
        unknown = 0,
        blue,
        red,
        green,
        cyan,
        magenta,
        yellow
    }

    public enum DIRECTION
    {
        D_UP = 0,
        D_UP_RIGHT,
        D_RIGHT,
        D_BACK_RIGHT,
        D_DOWN_RIGHT,
        D_DOWN,
        D_DOWN_LEFT,
        D_LEFT,
        D_UP_LEFT,
        D_UNKNOWN
    }


    //--------------------------

    public static Color getColor(colors col)
    {
        Color ret = Color.black;

        switch(col)
        {
            case colors.blue:
                ret = Color.blue;
        break;
            case colors.red:
                ret = Color.red;
                break;
            case colors.green:
                ret = Color.green;
                break;
            case colors.cyan:
                ret = Color.cyan;
                break;
            case colors.magenta:
                ret = Color.magenta;
                break;
            case colors.yellow:
                ret = Color.yellow;
                break;
        }

        return ret;
    }


    void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}
}
