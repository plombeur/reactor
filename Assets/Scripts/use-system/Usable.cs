using UnityEngine;
using System.Collections;

public class Usable : MonoBehaviour 
{
    public Action[] actions;
    public bool destroyAfterUsed = false;

	void Start () 
    {
	
	}
	
	void Update () 
    {
	
	}

    public void use()
    {
        foreach (Action a in actions)
            a.execute();

        if (destroyAfterUsed)
            Destroy(gameObject);
    }
}
