using UnityEngine;
using System.Collections;



public class Ghost : MonoBehaviour {
    [SerializeField]
    public Scripts.colors type;
    Sprite sprite = null;
    [SerializeField]
    Sprite blue;
    [SerializeField]
    Sprite red;
    [SerializeField]
    Sprite green;
    [SerializeField]
    Sprite yellow;
    [SerializeField]
    Sprite magenta;
    [SerializeField]
    Sprite cyan;

    // Use this for initialization
    void Start () {
        //Random ghost type at spawn
        type = (Scripts.colors)Random.Range(0, 5);        
        switch (type)
        {
            case Scripts.colors.blue:
                sprite = blue;
                break;
            case Scripts.colors.red:
                sprite = red;
                break;
            case Scripts.colors.green:
                sprite = green;
                break;
            case Scripts.colors.cyan:
                sprite = cyan;
                break;
            case Scripts.colors.magenta:
                sprite = magenta;
                break;
            case Scripts.colors.yellow:
                sprite = yellow;
                break;
            default:
                break;
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }
	
	// Update is called once per frame
	void Update () {
        if (Debug.isDebugBuild)
        {
            switch (type)
            {
                case Scripts.colors.blue:
                    sprite = blue;
                    break;
                case Scripts.colors.red:
                    sprite = red;
                    break;
                case Scripts.colors.green:
                    sprite = green;
                    break;
                case Scripts.colors.cyan:
                    sprite = cyan;
                    break;
                case Scripts.colors.magenta:
                    sprite = magenta;
                    break;
                case Scripts.colors.yellow:
                    sprite = yellow;
                    break;
                default:
                    break;
            }
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        }
        
    }
}
