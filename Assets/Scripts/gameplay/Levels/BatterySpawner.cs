using UnityEngine;
using System.Collections;

public class BatterySpawner : MonoBehaviour 
{
    public GameObject batteryPrefab;

	void Start ()
    {
	
	}
	
	void Update ()
    {
       if (GetComponent<Living>().isDead())
       {
           Instantiate(batteryPrefab, transform.position+ Vector3.up*1.2f, Quaternion.identity);
           Destroy(gameObject);
       }
	}
}
