using UnityEngine;
using System.Collections;

public class MatrixCharacter : MonoBehaviour {

    private int nbCharacters = 8;
    private static char[] characters = { '嫃', '媽', '唷', '啤', '啥', '営', '唸', '嗇' };

    public float lifeTime = 3;
    public float vitesseAffichage = .5f;
    private bool nextCreated = false;
    private float time = 0;

    public float espacement = 1;
    public GameObject prefabMatrixCharacter;

    private float timeForSwitching;
    private float switchingTime = 0;

    public int nbFils = 3;

	void Start () {
        if (vitesseAffichage > lifeTime)
            Debug.LogError("Le MatrixCharacter ne vit pas assez longtemps pour créer son suivant.");
        GetComponent<TextMesh>().text = "" + characters[Random.Range(0, nbCharacters)];
        timeForSwitching = Random.Range(.5f, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {

        time += Time.deltaTime;
        switchingTime += Time.deltaTime;

        if(switchingTime >= timeForSwitching )
        {
            switchingTime -= timeForSwitching;
            GetComponent<TextMesh>().text = "" + characters[Random.Range(0, nbCharacters)];
        }

        if (time >= lifeTime)
            GameObject.Destroy(gameObject);

        if (nbFils > 0 && !nextCreated && time >= vitesseAffichage)
        {
            GameObject newObj = (GameObject)GameObject.Instantiate(prefabMatrixCharacter);
            //newObj.transform.parent = transform.parent;
            newObj.GetComponent<MatrixCharacter>().nbFils = nbFils - 1;
            Vector3 position = transform.position;
            position.y -= espacement;
            newObj.transform.position = position;
            nextCreated = true;
        }

        if (time <= vitesseAffichage)
        {
            GetComponent<TextMesh>().color = new Color(1, 1, 1);
        }
        else
        {
            GetComponent<TextMesh>().color = new Color(28f / 255, 236f / 255, 21f / 255, 1 - (time - vitesseAffichage) / (lifeTime - vitesseAffichage));
        }
	}
}
