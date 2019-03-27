using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoadSystem
{
    public static void SaveData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gd.fun";
        FileStream fStream = new FileStream(path, FileMode.Create);

        GameDataSL gdsl = new GameDataSL(true);
        formatter.Serialize(fStream, gdsl);
        fStream.Close();
    }

    public static GameDataSL LoadData()
    {
        string path = Application.persistentDataPath + "/gd.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fStream = new FileStream(path, FileMode.Open);
            GameDataSL gdsl = formatter.Deserialize(fStream) as GameDataSL;
            fStream.Close();
            return gdsl;
        }
        else
        {
            return null;
        }
    }

}
