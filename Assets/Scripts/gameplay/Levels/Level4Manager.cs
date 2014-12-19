using UnityEngine;
using System.Collections;

public class Level4Manager : MonoBehaviour 
{
    public int nbTerminals;
    private int count;

    public Door doorToNextLevel;
    public GameObject finalObjectifMinimap;

    private string obectif1Title = "Le controle des machines";
    private string objectif1Task = "* Désactive les terminaux de controle";
    private string objectif1Description = "Le réacteur est controlé via 4 terminaux de controle automatisés et il en suffit d'un pour fonctionner, tu vas donc devoir tous les couper";

    private string obectif2Title = "Etage -5 : Le réacteur de torture";
    private string objectif2Task = "* Accède au réacteur";
    private string objectif2Description = "Le réacteur devient instable, ta mission n'est pas de détruire le complexe mais d'arreter le réacteur, rend toi au réacteur et trouve une solution pour terminer le travail et éviter l'éxplosion";

    void Start()
    {
        Screen.lockCursor = false;
        doorToNextLevel.locked = true;
        finalObjectifMinimap.SetActive(false);
        GameManager.getInstance().getPlayer().GetComponent<CharacterControllerIsometricPlayer>().canFire = true;
        GameManager.getInstance().getPlayer().GetComponent<CharacterControllerIsometricPlayer>().canFlashlight = true;
        GameManager.getInstance().getHUD().getObjectifWindow().setObjectif(obectif1Title, objectif1Description, objectif1Task);
    }

    void Update()
    {
        if (count >= nbTerminals)
        {
            count = 0;
            doorToNextLevel.locked = false;
            finalObjectifMinimap.SetActive(true);

            GameManager.getInstance().getHUD().getObjectifWindow().setObjectif(obectif2Title, objectif2Description, objectif2Task);
        }

    }

    public void onDisabledTerminal()
    {
        count++;
        GameManager.getInstance().getHUD().getObjectifWindow().miniWindowResumeField.text = objectif1Task + " (" + count + "/" + nbTerminals + " desactivés)";
        GameManager.getInstance().getHUD().showEvent(count + "/" + nbTerminals + " desactivés");

    }
}
