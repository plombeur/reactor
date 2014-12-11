using UnityEngine;
using System.Collections;

public class Speech : MonoBehaviour
{
    public AudioClip[] speechs;
    public AudioSource audioSource;

    public float percentPlaySound = 0.01f;
    public float refreshTime = 5;
    private float counter = 0;



    void Update()
    {
        if (speechs == null || speechs.Length == 0 || audioSource == null)
        {
            enabled = false;
            return;
        }
        counter -= Time.deltaTime;
        if (counter <= 0)
        {
            if (!audioSource.isPlaying)
            {
                float random = Random.Range(0.0f, 1.0f);
                if (random <= percentPlaySound)
                {
                    audioSource.clip = speechs[Random.Range(0, speechs.Length - 1)];
                    audioSource.Play();
                }

            }
            counter = refreshTime;
        }
    }
}
