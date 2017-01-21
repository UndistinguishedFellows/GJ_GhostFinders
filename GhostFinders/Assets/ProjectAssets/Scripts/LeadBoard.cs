using UnityEngine;
using System.Collections.Generic;

public class LeadBoard : MonoBehaviour {

    public Score currentScore;
    List<Score> leadBoards;

	void Start ()
    {
        leadBoards = new List<Score>();
        SaveLoad.Load(ref leadBoards);

        currentScore = new Score("New Score");
	}
	
	void Update ()
    {
        /*
        if (Input.GetKeyDown(KeyCode.P))
        {
            onLevelEnd();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            leadBoards = new List<Score>();
            SaveLoad.Load(ref leadBoards);

            currentScore = new Score("New Score");
        }
        if (Input.GetKeyDown(KeyCode.K))
            currentScore.points += 10;

        Debug.Log(currentScore.name + ": " + currentScore.points);*/
    }

    //-----------------------------------

    public void onLevelEnd()
    {
        //When a level is finished we should check if we have beat any record.

        List<Score> newLeadBoard = new List<Score>();

        if (leadBoards.Count < 3)
            leadBoards.Add(currentScore);

        foreach (Score s in leadBoards)
        {
            if (s.points >= currentScore.points)
                newLeadBoard.Add(s);
            else
                newLeadBoard.Add(currentScore); //Record beated!!! TODO: Any feedback?
        }

        leadBoards.Clear();
        leadBoards.AddRange(newLeadBoard);

        //New we have the new lead board list ordered by points lets set their name.

        int i = 1;
        foreach(Score s in leadBoards)
        {
            s.name = "Score " + i;
            ++i;
        }

        //Once name is setted lets save it.
        SaveLoad.Save(leadBoards);
    }
}
