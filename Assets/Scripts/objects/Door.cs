using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour 
{
    public bool locked = false;
    public Animation door;

	void Start ()
    {
	
	}
	
	void Update () 
    {
	
	}
    void OnTriggerEnter(Collider other)
    {
        if (!locked && other.tag == "Player")
            door.Play("open");
    }
    void OnTriggerExit(Collider other)
    {
        if (!locked && other.tag == "Player")
            door.Play("close");
    }
}
