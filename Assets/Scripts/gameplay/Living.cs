using UnityEngine;
using System.Collections;

public class Living : MonoBehaviour 
{
    public float maxHP = 1000;
    public float hp = 1000;
    public bool dead = false;
    public AudioClip[] destroySounds;
    public bool showWorldLifeBar;

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
        if (hp <= 0)
        {
            if (destroySounds != null && destroySounds.Length > 0)
                AudioSource.PlayClipAtPoint(destroySounds[Random.Range(0, destroySounds.Length - 1)],transform.position);
            dead = true;
        }
    }

    public bool isDead()
    {
        return dead;
    }
}
