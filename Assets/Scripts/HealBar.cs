using UnityEngine;

public class HealBar : MonoBehaviour
{
    public float health;
    public GameObject healthMaterial;

    private float healthBlink = 1.0f;
    private float oneOverMaxHealth = 0.5f;

    void Start()
    {
        oneOverMaxHealth = 1.0f / 100;
    }

    void Update() 
{
    float relativeHealth = health * oneOverMaxHealth;
	healthMaterial.renderer.material.SetFloat ("_SelfIllumination", relativeHealth * 2.0f * healthBlink);
	
	if (relativeHealth < 0.45f) 
		healthBlink = Mathf.PingPong (Time.time * 6.0f, 2.0f);
	else 
		healthBlink = 1.0f;
}
}