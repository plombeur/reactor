using UnityEngine;
using System.Collections;

public class Level1Manager : MonoBehaviour 
{

    void Start()
    {
        GameManager.getInstance().getHUD().getInformationWindow().showInfo("La mission", "Vous devez penetrer dans le complexe de l'UTECH, une entreprise qui creer des solutions méchanisées avec un grand randement de production. Il se trouve que ce rendement est du à l'utilisation de moyens illégals, en effet ils utilisent des humains comme source d'energie. Apres s'être infiltré dans le complexe, il vous faudrat trouver un moyen d'acceder aux étages inferieurs jusqu'a atteindre le réacteur et enfin le mettre hors service. Bonne chance");
    }

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Application.LoadLevel(2);
    }
}
