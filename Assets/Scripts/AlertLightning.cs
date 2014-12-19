using UnityEngine;
using System.Collections;

public class AlertLightning : MonoBehaviour {

    public float timeBetweenColors = 1;
    private float time = 0;
    private bool red = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if(time >= timeBetweenColors)
        {
            time -= timeBetweenColors;
            if(red)
            {
                GetComponent<Light>().color = new Color(1, 0, 0);
                red = false;
            }
            else if (!red)
            {
                GetComponent<Light>().color = new Color(1, 1, 1);
                red = true;
            }
        }
	}
}
