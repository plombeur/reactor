using UnityEngine;
using System.Collections;

public class KeyBoardController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        float x;
        float y;
        Settings.controls.moveAxis(out x, out y);
        Debug.Log(x + ":" + y );
        GetComponent<Rigidbody>().velocity = new Vector3(y*3, x*3, 0);
	}
}
