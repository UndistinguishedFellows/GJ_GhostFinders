using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class Score
{

    public static Score current;
    public string name;
    public int points;

    public Score()
    {
        name = "";
        points = 0;
    }

}