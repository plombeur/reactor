using UnityEngine;
using System.Collections;

public class BarrelController : MonoBehaviour {

    private bool blocked = false;
    private bool willReload = false;
    float timeBeforeReloading = 4;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if(willReload)
        {
            timeBeforeReloading -= Time.deltaTime;
            if (timeBeforeReloading <= 0)
            {
                Application.LoadLevel(4);
                willReload = false;
            }
        }

        if (blocked)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            return;
        }

        GetComponent<Rigidbody>().velocity = SpaceNavigatorNoDevice.SubInstance.GetTranslation();
	}

    void OnCollisionEnter(Collision collider)
    {
        GameManager.getInstance().setGameLost("Ne touchez aucun obstacle avec le produit!!");
        willReload = true;
        blocked = true;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Generator")
        {
            GameManager.getInstance().setGameWin();
            blocked = true;
        }
    }
}
