using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedTriggerSet : MonoBehaviour
{
    public HashSet<string> finishedTriggers { get; private set; } = new HashSet<string>();
    private string key = "finishedTriggers";

    private void Awake()
    {
        Load();
    }

    void Save()
    {
        SaveLoad.Save(finishedTriggers, key);
    }

    void Load()
    {
        if (SaveLoad.SaveExists(key))
        {
            finishedTriggers = SaveLoad.Load<HashSet<string>>(key);
        }
    }

    public void AddTrigger(string triggerId) 
    {
        finishedTriggers.Add(triggerId);
        Save(); //save whenever a new trigger is added.
    }




}
