using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveData
{
    public static void SaveScore(int score)
    {
        if(score > LoadScore())
        {
            string path = Application.persistentDataPath + "/playerScore.sc";

            BinaryFormatter bf = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Create);

            bf.Serialize(stream, score);

            stream.Close();
        }
    }

    public static int LoadScore()
    {
        string path = Application.persistentDataPath + "/playerScore.sc";

        if(File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            int score = (int) bf.Deserialize(stream);

            stream.Close();

            return score;
        }
        else
        {
            Debug.LogError("File not found in " + path);

            return -999;
        }
    }
}
