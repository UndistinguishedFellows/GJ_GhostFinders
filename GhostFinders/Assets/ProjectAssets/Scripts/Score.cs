using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
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

    public int CompareTo(Score score2)
    {
        return (points >= score2.points) ? 0 : 1;
    }
}