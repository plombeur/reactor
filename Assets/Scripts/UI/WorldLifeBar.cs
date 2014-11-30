using UnityEngine;
using System.Collections;

public class WorldLifeBar : MonoBehaviour 
{
    public Living target;
    public ProgressBar progressBar;

	void Start () 
    {
	
	}
	
	void Update () 
    {
	    if (target != null)
        {
            progressBar.progress = target.hp / target.maxHP * 100;
        }
	}
}
