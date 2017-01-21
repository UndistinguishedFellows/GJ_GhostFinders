using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad{
    public static List<Score> savedScores = new List<Score>();

    public static void Save(List<Score> listToSave)
    {
        //savedScores.Add(Score.current);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Scores.gd");
        bf.Serialize(file, listToSave);
        file.Close();
    }

    public static void Load(ref List<Score> listToFill)
    {
        if (File.Exists(Application.persistentDataPath + "/Scores.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Scores.gd", FileMode.Open);
            SaveLoad.savedScores = (List<Score>)bf.Deserialize(file);
            listToFill.Clear();
            listToFill.AddRange(savedScores);
            file.Close();
        }
    }
}