using UnityEngine;
using System.Collections;

public class Level3Manager : MonoBehaviour 
{
    public int nbBatteries;
    private int count;

    public Teleporter exitTeleporter;
    public Light exitTeleporterLight;
    public GameObject finalObjectifMinimap;
    public BatteryPoint batteryPoint;

    private string obectif1Title = "Alimentation energetique";
    private string objectif1Task = "* Recupere des batteries";
    private string objectif1Description = "Le téléporteur pour la salle de controle n'est pas alimenté en energie. Le systeme étant autonomie, seul des machines s'y trouve, tu vas donc devoir trouver de quoi l'alimenter. Les soldats utilise tout comme toi une batterie pour alimenter leur armure, tue en suffisament pour recuperer les recuperer";

    private string obectif2Title = "Etage -2 : La salle de controle";
    private string objectif2Task = "* Alimente et utilse le téléporteur";
    private string objectif2Description = "Tu as suffisament de batteries pour alimenter le téléporteur, branche-les sur le téléporteur et utilise le !";

    void Start () 
    {
        exitTeleporter.enabled = false;
        finalObjectifMinimap.SetActive(false);
        exitTeleporterLight.gameObject.SetActive(false);
        GameManager.getInstance().getPlayer().GetComponent<CharacterControllerIsometricPlayer>().canFire = true;
        GameManager.getInstance().getPlayer().GetComponent<CharacterControllerIsometricPlayer>().canFlashlight = true;
        GameManager.getInstance().getHUD().getObjectifWindow().setObjectif(obectif1Title, objectif1Description, objectif1Task);
	}
	
	void Update () 
    {
	    if (count >= nbBatteries)
        {
            count = 0;
            batteryPoint.allCollected = true;
            GameManager.getInstance().getHUD().getObjectifWindow().setObjectif(obectif2Title, objectif2Description, objectif2Task);
            finalObjectifMinimap.SetActive(true);

          
        }
        if (batteryPoint.allCollected)
            foreach (Battery battery in GameObject.FindObjectsOfType<Battery>())
            {
                battery.indicatorMinimap.gameObject.SetActive(false);
            }

	}

    public void onPickBattery()
    {
        if (batteryPoint.allCollected)
            return;
        count++;
        GameManager.getInstance().getHUD().getObjectifWindow().miniWindowResumeField.text = objectif1Task + " (" + count + "/" + nbBatteries + " batteries recuperées)";
        GameManager.getInstance().getHUD().showEvent(count + "/" + nbBatteries + " batteries recuperées");

    }
}
