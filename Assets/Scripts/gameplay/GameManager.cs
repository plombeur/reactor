using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    void Start()
    {
        if (instance != null)
        {
            Debug.Log("GameManager already instancied, destroy the new one");
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            loadSettings();
        }

    }

    void Update()
    {
    }
    private void loadSettings()
    {
        Settings.controls = new Controls("controls.cfg");
        if (!Settings.controls.load())
            Settings.controls.loadDefault();
        Settings.controls.save();

    }
  
    public static GameManager getInstance()
    {
        return instance;
    }
}