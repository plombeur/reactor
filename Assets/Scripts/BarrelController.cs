using UnityEngine;
using System.Collections;

public class BarrelController : MonoBehaviour {

    private bool blocked = false;
    private bool willReload = false;
    public TextMesh time;
    private float timeRemaining = 18;

	// Use this for initialization
	void Start () {
        time.text = timeRemaining + "s";
	}
	
	// Update is called once per frame
	void Update () {

        if (blocked)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            return;
        }

        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            time.text = "Lost!";
            blocked = true;
            GameManager.getInstance().setGameLost("Le temps est écoulé!");
            Application.LoadLevel(5);
        }
        else
            time.text = timeRemaining + "s";

        Vector3 translationNav = SpaceNavigator.Translation;
        Vector3 newPosition = new Vector3();
        newPosition.x = -translationNav.z;
        newPosition.y = translationNav.x;
        GetComponent<Rigidbody>().velocity = newPosition;
	}

    void OnCollisionEnter(Collision collider)
    {
        GameManager.getInstance().setGameLost("Ne touchez aucun obstacle avec le produit!!");
        Application.LoadLevel(5);
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
