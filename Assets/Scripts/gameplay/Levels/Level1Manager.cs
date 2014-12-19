using UnityEngine;
using System.Collections;

public class Level1Manager : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Application.LoadLevel(2);
    }
}
