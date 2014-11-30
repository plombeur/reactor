using UnityEngine;
using System.Collections;

public class UIWorld : MonoBehaviour 
{
    private static UIWorld instance;
    public WorldLifeBar prefabLifeBar;

    void Start()
    {
        instance = this;
    }

    public static UIWorld getInstance()
    {
        return instance;
    }

    public WorldLifeBar registerWorldLifeBar(Living target)
    {
        GameObject worldLifeBarObject = GameObject.Instantiate(prefabLifeBar) as GameObject;
        WorldLifeBar worldLifeBarScript = worldLifeBarObject.GetComponent<WorldLifeBar>();
        worldLifeBarScript.target = target;
        return worldLifeBarScript;
    }
}
