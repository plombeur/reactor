using UnityEngine;
using System.Collections;

public class TriggerLvl4 : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Application.LoadLevel(5);
    }
}
