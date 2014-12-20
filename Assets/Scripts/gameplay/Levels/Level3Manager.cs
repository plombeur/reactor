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

    private string obectif1Title = "Alimentation énergétique";
    private string objectif1Task = "* Récupère des batteries";
    private string objectif1Description = "Le téléporteur pour la salle de contrôle n'est pas alimenté en énergie. Le système étant autonome et contrôlé a distance, seul des machines s'y trouvent, tu vas donc devoir trouver de quoi l'alimenter. Les soldats utilisent tout comme toi une batterie pour alimenter leur armure, tues-en suffisamment pour les récupérer";

    private string obectif2Title = "Etage -2 : La salle de contrôle ";
    private string objectif2Task = "* Alimente et utilise le téléporteur";
    private string objectif2Description = "Tu as suffisamment de batteries pour alimenter le téléporteur, branche-les sur le téléporteur et utilise le !";

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
