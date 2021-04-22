using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// I need to add whatever is essential manually here...I guess I can expand upon it later for sure. 
/// </summary>
public class EssentialsLoader : MonoBehaviour
{
    [SerializeField] private GameObject gameMaster;
    [SerializeField] private GameObject soundManager;

    void Awake()
    {
        if (GameMaster.instance == null) //need to write this manually cus I need to check singletons..
        {
            Instantiate(gameMaster);
        }
        if (SoundManager.instance == null) {
            Instantiate(soundManager);
        }
    }

}
