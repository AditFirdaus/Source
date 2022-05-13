using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class IO
{
    public static bool Save(this object obj, string path)
    {
        string filePath = Application.persistentDataPath + "/SaveData/" + path;

        if (!Directory.Exists(Path.GetDirectoryName(filePath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        }

        string json = JsonUtility.ToJson(obj, true);

        File.WriteAllText(filePath, json);

        return true;
    }

    public static bool Load<T>(string path, out T result) where T : new()
    {
        string filePath = Application.persistentDataPath + "/SaveData/" + path;

        if (!File.Exists(filePath))
        {
            result = new();

            return false;
        }

        string json = File.ReadAllText(filePath);
        result = JsonUtility.FromJson<T>(json);

        Debug.Log(json);

        return true;
    }
}
