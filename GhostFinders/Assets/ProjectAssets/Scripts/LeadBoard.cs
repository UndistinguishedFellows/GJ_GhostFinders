using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LeadBoard : MonoBehaviour {

    public Score currentScore;
    List<Score> leadBoards;

    public GameObject lbPanel = null;
    public GameObject lbLabelsParetn = null;
    Text[] labels;

    int leadBoardSize = 5;

	void Start ()
    {
        currentScore = new Score("New Score");
        leadBoards = new List<Score>();
        SaveLoad.Load(ref leadBoards);
        Debug.Log("Loaded leadboard file and got a " + leadBoards.Count + "list of scores.");

        labels = lbLabelsParetn.GetComponentsInChildren<Text>();
        lbPanel.SetActive(false);
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            onLevelEnd();
        }
/*
        if (Input.GetKeyDown(KeyCode.L))
        {
            leadBoards = new List<Score>();
            SaveLoad.Load(ref leadBoards);

            currentScore = new Score("New Score");
        }

        if (Input.GetKeyDown(KeyCode.K))
            currentScore.points += 10;
        */
        //Debug.Log(currentScore.name + ": " + currentScore.points);
    }

    //-----------------------------------

    public void onLevelEnd()
    {
        //When a level is finished we should check if we have beat any record.
        if (leadBoards.Count < leadBoardSize)
            leadBoards.Add(currentScore);

        bool record = false;
        foreach(Score s in leadBoards)
        {
            if (currentScore.points > s.points)
                record = true;
        }

        if (record && leadBoards.Count >= leadBoardSize)
            leadBoards.Add(currentScore);

        //Sort the list again to make sure the last element is the one with less points.
        leadBoards.Sort((s1, s2) => s1.CompareTo(s2));

        //If we have added a new item and list is full, remove last.
        if(record && leadBoards.Count >= leadBoardSize)
        {
            leadBoards.RemoveAt(leadBoards.Count - 1);
        }

        //New we have the new lead board list ordered by points lets set their name.
        int i = 1;
        foreach(Score s in leadBoards)
        {
            s.name = "Score " + i;
            ++i;
        }

        //Once name is setted lets save it.
        SaveLoad.Save(leadBoards);

        //Now we have save the list lets displaye it

        lbPanel.SetActive(true);
        int j = 0;
        foreach(Score s in leadBoards)
        {
            labels[j].text = (j + 1).ToString("#.##") + ". " + s.name + ": " + s.points;
            ++j;
        }
         if(j < 4) //If not 5 scores set text to ....
        {
            for(; j < 5; ++j)
            {
                labels[j].text = (j + 1).ToString() + ". ??????: ???";
            }
        }
    }
}
