using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LeaderboardMenu : MonoBehaviour {
    
    List<Score> leadBoards;

    public GameObject lbPanel = null;
    public GameObject lbLabelsParetn = null;
    Text[] labels;

    int leadBoardSize = 5;

    void Start()
    {
        leadBoards = new List<Score>();
        SaveLoad.Load(ref leadBoards);
        Debug.Log("Loaded leadboard file and got a " + leadBoards.Count + "list of scores.");

        labels = lbLabelsParetn.GetComponentsInChildren<Text>();
        lbPanel.SetActive(false);
    }

    void Update()
    {
        
    }

    //-----------------------------------

    public void onLeadBoardButtonClick()
    {
        lbPanel.SetActive(true);
        int j = 0;
        foreach (Score s in leadBoards)
        {
            labels[j].text = (j + 1).ToString() + ". " + s.name + ": " + s.points;
            ++j;
        }
        if (j < 4) //If not 5 scores set text to ....
        {
            for (; j < 5; ++j)
            {
                labels[j].text = (j + 1).ToString() + ". ??????: ???";
            }
        }
    }

    public void onCloseLeadBoardClick()
    {
        lbPanel.SetActive(false);
    }
}
