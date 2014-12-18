using UnityEngine;
using System.Collections;

public class Level2Manager : MonoBehaviour 
{
    public int nbEngineer;
    private int count;

    public RoomDoor doorToNextLevel;
    public GameObject finalObjectifMinimap;

	void Start () 
    {
        doorToNextLevel.lockDoor();
        finalObjectifMinimap.SetActive(false);
        GameManager.getInstance().getHUD().getObjectifWindow().setObjectif("test level 2", "bla", "objectif");
	}
	
	void Update () 
    {
	    if (count >= nbEngineer)
        {
            doorToNextLevel.unlockDoor();
            finalObjectifMinimap.SetActive(true);
        }
	}

    public void onTouchEngineer()
    {
        count++;
    }
}
