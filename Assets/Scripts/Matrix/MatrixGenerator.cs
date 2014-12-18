using UnityEngine;
using System.Collections;

public class MatrixGenerator : MonoBehaviour {

    public float sizeX = 1;
    public float sizeY = 1;
    public float timeMinBeforeGeneration = 0;
    public float timeMaxBeforeGeneration = 1;
    public float nbNewCharacterPerTick = 3;
    public int minRepetitionMatrixCharacter = 3;
    public int maxRepetitionMatrixCharacter = 15;
    public GameObject prefabMatrixCharacter;
    private float espacement;

    private float time = 0;

	void Start () {

        if (prefabMatrixCharacter == null)
            Debug.LogError("Aucun prefab de colonne de matrice linké");

        espacement = prefabMatrixCharacter.GetComponent<MatrixCharacter>().espacement;
        time = Random.Range(timeMinBeforeGeneration, timeMaxBeforeGeneration);
	}
	
	// Update is called once per frame
	void Update () {

        if (prefabMatrixCharacter == null)
            return;

        time -= Time.deltaTime;

        if(time <= 0)
        {
            for (int i = 0; i < nbNewCharacterPerTick;++i )
            {
                time = -time + Random.Range(timeMinBeforeGeneration * 100, timeMaxBeforeGeneration * 100) / 100f;
                float futureX = Random.Range(0, sizeX) - sizeX / 2;
                futureX -= futureX % espacement;
                float futureY = Random.Range(0, sizeY) - sizeY / 2;
                futureY -= futureY % espacement;
                GameObject newMatrixCharacter = (GameObject)GameObject.Instantiate(prefabMatrixCharacter);
                newMatrixCharacter.transform.parent = transform;
                newMatrixCharacter.transform.position = new Vector2(futureX, futureY) + (Vector2)transform.position;
                newMatrixCharacter.GetComponent<MatrixCharacter>().nbFils = Random.Range(minRepetitionMatrixCharacter, maxRepetitionMatrixCharacter);
            }
        }
	}
}
