using UnityEngine;
using System.Collections;

public class Living : MonoBehaviour 
{
    public float maxHP = 1000;
    public float hp = 1000;
    public bool dead = false;
    public AudioClip[] destroySound;
    public bool showWorldLifeBar;

    private WorldLifeBar worldLifeBar;

    public void damage(float damage)
    {
        hp = Mathf.Clamp(hp - damage, 0, maxHP);
    }
    public void heal(float heal)
    {
        hp = Mathf.Clamp(hp + heal, 0, maxHP);
    }

    void Update()
    {
        if (showWorldLifeBar && worldLifeBar == null)
            worldLifeBar = UIWorld.getInstance().registerWorldLifeBar(this);
        if (!showWorldLifeBar && worldLifeBar != null)
        {
            GameObject.Destroy(worldLifeBar.gameObject);
            worldLifeBar = null;
        }

        if (hp <= 0)
        {
            if (destroySound != null || destroySound.Length > 0)
                AudioSource.PlayClipAtPoint(destroySound[Random.Range(0, destroySound.Length - 1)],transform.position);
            dead = true;
        }
    }

    public bool isDead()
    {
        return dead;
    }
}
