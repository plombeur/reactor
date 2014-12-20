using UnityEngine;
using System.Collections;

public class Level1Manager : MonoBehaviour 
{

    void Start()
    {
        GameManager.getInstance().getHUD().getInformationWindow().showInfo("La mission : Arret du réacteur à humain !", "L’entreprise UTECH créer des machines à utilisation civil ou militaire à la pointe de la technologie. Cependant, le complexe situé proche de vous à besoin de beaucoup d’énergie pour sa production et les bénéfices serait inexistants s’ils utilisaient le raccordement standard, c’est pourquoi ils utilisent leur propre réacteur, le problème c’est que ce réacteur génère son énergie d’une manière très spéciale mais surtout illégale, UTECH a trouvé un moyen de générer une grande quantité d’électricité à partir d’être humain qui sont donc détenus et exploités. L’armée ne peut pas intervenir car la défense militaire extérieure est trop importante. Votre mission est donc de vous infiltrer dans le complexe afin de mettre le réacteur hors service ce qui désactivera toutes les défenses du complexe et permettrait à l’armée d’intervenir. Bonne chance soldat");
    }

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Application.LoadLevel(2);
    }
}
