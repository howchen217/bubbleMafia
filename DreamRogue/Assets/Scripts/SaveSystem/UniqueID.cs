﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UniqueID : MonoBehaviour
{
    public string ID { get; private set; }

    private void Awake()
    {   
        ID = SceneManager.GetActiveScene().name + "-" + transform.position.sqrMagnitude + "-" + name + "-" + transform.GetSiblingIndex();
        //Debug.Log("ID for " + name + " is " + ID);
    }
}
