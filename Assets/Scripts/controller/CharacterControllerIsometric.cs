using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]

public class CharacterControllerIsometric : MonoBehaviour
{
    public float turningSmoothing = 10f;
    public Animation animator;
    private Vector3 targetVelocity;
    public float speed = 6;
    public float acceleration = 50;
    public GameObject flashLight;

    void Start()
    {
        targetVelocity = Vector3.zero;
    }
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        targetVelocity.y = 0;
        float smoother = Time.deltaTime * 10;
        Vector3 deltaVelocity = Vector3.Lerp(rigidbody.velocity, targetVelocity, smoother) - rigidbody.velocity;
        deltaVelocity.y = 0;
        rigidbody.AddForce(deltaVelocity * acceleration, ForceMode.Acceleration);
        updateAnimation();
    }
    public void move(Vector3 direction)
    {
        this.targetVelocity = direction * speed;
    }
    public void lookAt(Vector3 position)
    {
        position.y = transform.position.y;
        Vector3 targetDir = position - transform.position;

        float rotationAngle = Vector3.Angle(targetDir, transform.forward);
        float ratioAngle = Mathf.InverseLerp(0, 180, rotationAngle);
        rotationAngle *= (Vector3.Dot (Vector3.up, Vector3.Cross (transform.forward, targetDir)) < 0 ? -1 : 1);
        rigidbody.angularVelocity = (Vector3.up * rotationAngle * ratioAngle*turningSmoothing );
    }
    private void updateAnimation()
    {
        /*
       if (rigidbody.velocity.magnitude <= 0.1f)
       {
           animator.CrossFade("idle");
           stat = ANIMATION_STAT.IDLE;
       }
       else if (rigidbody.velocity.magnitude > 0.1f)
       {
           animator["run_forward"].speed = rigidbody.velocity.magnitude / 2;
           animator.CrossFade("run_forward");
           stat = ANIMATION_STAT.WALKING;
       }*/

    }
    public bool isFlashLight()
    {
        return flashLight.activeInHierarchy;
    }
    public void setFlashLight (bool enabled)
    {
        if (flashLight != null)
        {
            if (flashLight.activeInHierarchy && !enabled) // desactivation
            {
                flashLight.SetActive(false);
            }
            else if (!flashLight.activeInHierarchy && enabled) // activation
            {
                flashLight.SetActive(true);
            }
        }
    }
}
