using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SerializationManager
{
    public static bool Save(string saveName, object saveData)
    {
        BinaryFormatter formatter = GetBinaryFormatter();

        if(!Directory.Exists(Application.persistentDataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }

        string path = Application.persistentDataPath + "/saves/" + saveName + ".save";
        Debug.Log(path);

        FileStream file = File.Create(path);

        formatter.Serialize(file, saveData);

        file.Close();

        // Debug.Log("Save to:" + path);

        return true;
    }

    public static object Load(string path)
    {
        if(!File.Exists(path))
        {
            // Debug.Log("Load from: " + path);
            return null;
        }

        BinaryFormatter formatter = GetBinaryFormatter();
        
        FileStream file = File.Open(path, FileMode.Open);

        try
        {
            object save = formatter.Deserialize(file);
            file.Close();

            // Debug.Log("Load from: " + path);
            return save;
        }
        catch
        {
            // Debug.LogErrorFormat("Failed to load file at ", path);
            file.Close();
            return null;
        }


    }

    public static BinaryFormatter GetBinaryFormatter()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        return formatter;
    }
}
