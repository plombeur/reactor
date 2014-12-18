using UnityEngine;
using System.Collections;

public class Level2Manager : MonoBehaviour 
{
    public int nbEngineer;
    private int count;

    public RoomDoor doorToNextLevel;
    public GameObject finalObjectifMinimap;

    private string obectif1Title = "La carte d'access";
    private string objectif1Task = "* Recupere la carte d'acces";
    private string objectif1Description = "L'acess à l'étage inférieur est verouillé, seul le chef technicien dispose d'une carte d'access, son identité n'est pas connu alors tu vas devoir les fouiller un par un.";

    private string obectif2Title = "Etage -1";
    private string objectif2Task = "* Utilse le téléporteur";
    private string objectif2Description = "Avec la carte d'acces, tu peut maintenant ouvrir la porte et utiliser un de leurs fameux téléporteur pour atteindre l'étage inférieur";

    void Start () 
    {
        doorToNextLevel.lockDoor();
        finalObjectifMinimap.SetActive(false);
        GameManager.getInstance().getPlayer().GetComponent<CharacterControllerIsometricPlayer>().canFire = false;
        GameManager.getInstance().getPlayer().GetComponent<CharacterControllerIsometricPlayer>().canFlashlight = false;
        GameManager.getInstance().getHUD().getObjectifWindow().setObjectif(obectif1Title, objectif1Description, objectif1Task);
	}
	
	void Update () 
    {
	    if (count >= nbEngineer)
        {
            count = 0;
            doorToNextLevel.unlockDoor();
            finalObjectifMinimap.SetActive(true);

            GameManager.getInstance().getHUD().getObjectifWindow().setObjectif(obectif2Title, objectif2Description, objectif2Task);
        }

	}

    public void onTouchEngineer()
    {
        count++;
        GameManager.getInstance().getHUD().getObjectifWindow().miniWindowResumeField.text = objectif1Task + " (" + count + "/"+nbEngineer+" fouillés)";
        GameManager.getInstance().getHUD().showEvent(count+"/"+nbEngineer+" fouillés");

    }
}
