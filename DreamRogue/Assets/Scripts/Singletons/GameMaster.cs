
using UnityEngine;
using System;

public class GameMaster : MonoBehaviour
{

    public static GameMaster instance { get; private set; }

    private void Awake()
    {
        CheckInstance();//avoid duplicates

        //DontDestroyOnLoad(gameObject);

    }

    void CheckInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    //----------------Events----------------
    public event Action<String> onExitEnter;
    public static Action SaveInitiated;


    public void exitEnter(String areaToLoad) //method to trigger the event
    {
        if (onExitEnter != null) 
        {
            onExitEnter(areaToLoad); //trigger the actual event
        }
    }

    //this is more the idea of a general save
    public void OnSaveInitiated()
    {
        SaveInitiated?.Invoke(); //the .? is a shorthand null check
    }

    //--------------Debug-----------------
    public void DeleteAllProgress()
    {
        SaveLoad.DeleteAllSaves();
    }


}
