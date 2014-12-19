using UnityEngine;
using System.Collections;

public class AutoFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public AudioSource fireAudioSource;
    public Transform spawnPoint;
    public float frequency = 10;
    public float coneAngle = 1.5f;
    public bool firing = false;
    public float damagePerSecond = 20.0f;
    public float forcePerSecond = 20.0f;
    public float hitSoundVolume = 0.5f;

    public GameObject muzzleFlashFront;

    private float lastFireTime = -1;
    private bool lastFireStat = false;

    void Awake()
    {
        muzzleFlashFront.SetActive(false);

        if (spawnPoint == null)
            spawnPoint = transform;
    }

    void Update()
    {
        if (firing)
        {
            if (!lastFireStat)
            {
                lastFireStat = true;
                OnStartFire();
            }
            if (Time.time > lastFireTime + 1 / frequency)
            {
                // Spawn visual bullet
                Quaternion coneRandomRotation = Quaternion.Euler(Random.Range(-coneAngle, coneAngle), Random.Range(-coneAngle, coneAngle), 0);
                GameObject go = Spawner.Spawn(bulletPrefab, spawnPoint.position, spawnPoint.rotation * coneRandomRotation) as GameObject;
                SimpleBullet bullet = go.GetComponent<SimpleBullet>();

                lastFireTime = Time.time;

                // Find the object hit by the raycast
                RaycastHit[] hits = Physics.RaycastAll(new Ray(transform.position + Vector3.up, transform.forward), 10);

                RaycastHit best = new RaycastHit();

                if (hits.Length > 0)
                {
                    foreach (RaycastHit hit in hits)
                    {
                        if (hit.transform && !hit.collider.isTrigger)
                        {
                            if (!best.transform || (best.transform.position - transform.position).magnitude > (hit.transform.position - transform.position).magnitude)
                                best = hit;
                        }
                    }
                }
               // Physics.Raycast(new Ray(transform.position+Vector3.up, transform.forward), out hitInfo);

                if (best.transform)
                {
                    // Get the health component of the target if any
                    Living targetHealth = best.transform.GetComponent<Living>();
                    if (targetHealth)
                    {
                        // Apply damage
                        targetHealth.damage(damagePerSecond / frequency);
                    }

                    // Get the rigidbody if any
                   /* if (hitInfo.rigidbody)
                    {
                        // Apply force to the target object at the position of the hit point
                        Vector3 force = transform.forward * (forcePerSecond / frequency);
                        hitInfo.rigidbody.AddForceAtPosition(force, hitInfo.point, ForceMode.Impulse);
                    }*/

                    // Ricochet sound
                    //AudioClip sound = MaterialImpactManager.GetBulletHitSound(hitInfo.collider.sharedMaterial);
                   // AudioSource.PlayClipAtPoint(sound, hitInfo.point, hitSoundVolume);

                    bullet.dist = best.distance;
                }
                else
                {
                    bullet.dist = 1000;
                }
            }
        }
        else if (lastFireStat)
        {
            lastFireStat = false;
            OnStopFire();
        }
    }

    void OnStartFire()
    {
        if (Time.timeScale == 0)
            return;

        firing = true;

        muzzleFlashFront.SetActive(true);

        if (fireAudioSource)
            fireAudioSource.Play();
    }

    void OnStopFire()
    {
        firing = false;

        muzzleFlashFront.SetActive(false);

        if (fireAudioSource)
            fireAudioSource.Stop();
    }
}