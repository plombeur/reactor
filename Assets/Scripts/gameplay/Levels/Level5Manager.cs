using UnityEngine;
using System.Collections;

public class Level5Manager : Action 
{
    private string obectif1Title = "Un arrêt en douceur";
    private string objectif1Task = "* Utilise l'ordinateur principal du réacteur";
    private string objectif1Description = "Derrière le réacteur se trouve l'ordinateur principal, c'est à partir de celui-ci que tu vas pouvoir stabiliser le réacteur, c’est la dernière étape de ta mission.";

    void Start()
    {
        GameManager.getInstance().getPlayer().GetComponent<CharacterControllerIsometricPlayer>().canFire = false;
        GameManager.getInstance().getPlayer().GetComponent<CharacterControllerIsometricPlayer>().canFlashlight = true;
        GameManager.getInstance().getHUD().getObjectifWindow().setObjectif(obectif1Title, objectif1Description, objectif1Task);
    }

    protected override void onExecute()
    {
        Application.LoadLevel(6);
    }
}
