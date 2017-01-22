using UnityEngine;
using System.Collections;

public class PointsLabel : MonoBehaviour
{
    public GUISkin guiSkin; // choose a guiStyle (Important!)

    public string text = "0"; // choose your name

    public Color color = Color.yellow;   // choose font color/size
    public float fontSize = 10;
    public float offsetX = -1.5f;
    public float offsetY = -2f;

    float upper = 1.0f;

    float boxW = 150f;
    float boxH = 20f;

    public bool messagePermanent = false;

    public float messageDuration { get; set; }

    public void showPoints(float points)
    {
        upper = 1.0f;
        text = points.ToString("F");
        messageDuration = 2;
    }

    Vector2 boxPosition;
    void Start()
    {
        //Debug.Log("Points Start");
        if (messagePermanent)
        {
            messageDuration = 2;
        }
    }
    void OnGUI()
    {
        //Debug.Log("Points ONGUI");
        if (messageDuration > 0)
        {
            if (!messagePermanent) // if you set this to false, you can simply use this script as a popup messenger, just set messageDuration to a value above 0
            {
                messageDuration -= Time.deltaTime;
            }

            GUI.skin = guiSkin;
            boxPosition = Camera.main.WorldToScreenPoint(transform.position);
            boxPosition.y = Screen.height - boxPosition.y;
            boxPosition.x -= boxW * 0.1f;
            boxPosition.y -= boxH * 0.5f;
            guiSkin.box.fontSize = 15;

            GUI.contentColor = color;

            Vector2 content = guiSkin.box.CalcSize(new GUIContent(text));

            GUI.Box(new Rect(boxPosition.x - content.x / 2 * offsetX, (boxPosition.y + offsetY) + upper, content.x, content.y), text);
            upper = upper - 1;
        }
    }
}