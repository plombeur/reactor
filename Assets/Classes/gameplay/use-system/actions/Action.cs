﻿using UnityEngine;
using System.Collections;

public abstract class Action : MonoBehaviour 
{
    private bool alreadyUsed;

	void Start () 
    {
	
	}
	
	void Update () 
    {
	
	}

    public void execute()
    {
        if (!alreadyUsed)
        {
            alreadyUsed = true;
            onExecute();
        }
    }

    protected abstract void onExecute();
}
