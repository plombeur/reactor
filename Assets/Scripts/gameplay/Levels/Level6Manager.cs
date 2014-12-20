using UnityEngine;
using System.Collections;

public class Level6Manager : MonoBehaviour 
{
    private string obectif1Title = "Un arrêt en douceur (suite)";
    private string objectif1Task = "* Utilise l'ordinateur principal du réacteur";
    private string objectif1Description = "Pour stabiliser le réacteur tu vas devoir apporter ce baril de refroidissement d'urgence jusqu'à son noyau de refroidissement. Attention, ce baril est très fragile dangereux donc au moindre contact brusque il sera détruit.";

	void Start () 
    {
        GameManager.getInstance().getHUD().hide();
        GameManager.getInstance().getHUD().getObjectifWindow().setObjectif(obectif1Title, objectif1Description, objectif1Task);
	}
	
}
