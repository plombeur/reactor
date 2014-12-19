using UnityEngine;
using System.Collections;

public class Level5Manager : Action 
{
    private string obectif1Title = "Un arret en douceur";
    private string objectif1Task = "* Utilise l'ordinateur principal du réacteur";
    private string objectif1Description = "Derriere le réacteur se trouve l'ordinateur principal, c'est a partir de celui-ci qu'on arrete normalement le réacteur, termine le travail !";

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
