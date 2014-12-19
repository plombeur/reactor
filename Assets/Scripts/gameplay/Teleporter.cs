using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour
{
    public string nextSceneName;

	void Start () 
    {
	
	}
	
	void Update () 
    {
	   
	}

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player" && enabled)
        {
            Application.LoadLevel(nextSceneName);
        }
    }
}
