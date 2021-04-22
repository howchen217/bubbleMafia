using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoad : MonoBehaviour
{
    public static void Save<T>(T objectToSave, string key)
    {
        string path = Application.persistentDataPath + "/saves/"; //persistent data path is a directory where we can save stuff on all devices
        Directory.CreateDirectory(path);

        //Serializing, (to binary so it's more secure)
        BinaryFormatter formatter = new BinaryFormatter();

        using (FileStream fileStream = new FileStream(path + key + ".txt", FileMode.Create)) //using automatically disposes when you go outside of scope
        {
            formatter.Serialize(fileStream, objectToSave);
        }
    }

    public static T Load<T>(string key)
    {
        string path = Application.persistentDataPath + "/saves/"; 
        BinaryFormatter formatter = new BinaryFormatter();

        T returnValue = default(T); //if we find nothing, just give em the default for that type
        using (FileStream fileStream = new FileStream(path + key + ".txt", FileMode.Open)) { 
            returnValue = (T)formatter.Deserialize(fileStream);
        }

        return returnValue;    

    }

    public static bool SaveExists(string key) 
    {
        string path = Application.persistentDataPath + "/saves/" + key + ".txt";
        return File.Exists(path); //load it if exists
    }

    public static void DeleteAllSaves() 
    {
        string path = Application.persistentDataPath + "/saves/";
        DirectoryInfo directory = new DirectoryInfo(path); //just delete the directory...damn. We might have different directories later
        directory.Delete(true);
        Directory.CreateDirectory(path);
    }
}
