using UnityEngine;
using System.Collections;
using System;

public class Score
{
    public string name;
    public float points;

    public Score()
    {
        name = "";
        points = 0;
    }

    public Score(string _name)
    {
        name = _name;
        points = 0;
    }
}