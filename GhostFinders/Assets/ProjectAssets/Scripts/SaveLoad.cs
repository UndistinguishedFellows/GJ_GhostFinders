using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad{
    public static List<Score> savedScores = new List<Score>();

    public static void Save()
    {
        savedScores.Add(Score.current);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Scores.gd");
        bf.Serialize(file, SaveLoad.savedScores);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/Scores.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Scores.gd", FileMode.Open);
            SaveLoad.savedScores = (List<Score>)bf.Deserialize(file);
            file.Close();
        }
    }
}