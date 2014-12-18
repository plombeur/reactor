using UnityEngine;
using System.Collections;

public class CameraController3Pers : MonoBehaviour
{
    public Transform target;
    public Transform targetModelBody;
    public Transform bodyPivot;
    public float optimalRange = 10;
    public float localAngleY;
    public float speedRotateX = 50;
    public float speedRotateY = 50;
    public Vector3 offset;

    public bool blockMouse = false;


    void Start()
    {
        
    }
    void Update()
    {
        Vector2 joystickRight = new Vector2(Input.GetAxis("JoyRightHorizontal"), Input.GetAxis("JoyRightVertical"));
        Vector2 mouseXY = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        Vector2 result = (joystickRight + mouseXY).normalized;

        if (!blockMouse)
        {
            Screen.lockCursor = true;
            localAngleY += result.y * Time.deltaTime * speedRotateY;
       localAngleY = Mathf.Clamp(localAngleY, -60, 50);
        target.Rotate(Vector3.up, result.x * Time.deltaTime * speedRotateX, Space.Self);
        }
        else
        {
        
        }
    }
    void LateUpdate()
    {
        targetModelBody.Rotate(Vector3.forward, localAngleY, Space.Self);

        Vector3 direction = target.forward;

        transform.LookAt(transform.position + direction);
        bodyPivot.LookAt(bodyPivot.position + direction);
        bodyPivot.Rotate(Vector3.right, -localAngleY, Space.Self);

        transform.LookAt(transform.position + bodyPivot.forward);
        Ray ray = new Ray(bodyPivot.position + (bodyPivot.TransformPoint(offset) - bodyPivot.position), -direction);
        RaycastHit[] hits = Physics.RaycastAll(ray, optimalRange);
        bool hitSomething = false;
        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.gameObject.tag != "Player" && !hit.collider.isTrigger && (!hitSomething || (transform.position - ray.origin).magnitude > (hit.point - ray.origin).magnitude) )
                {
                    Debug.Log(hit.collider.isTrigger);
                    transform.position = hit.point;
                    transform.Translate(hit.normal * 0.1f);
                    hitSomething = true;

                }
            }
        }
        if (!hitSomething)
            transform.position = ray.GetPoint(optimalRange);
    }
    //Vector3.SmoothDamp(transform.position, cameraTargetPosition, ref velocity, cameraSmoothing);
}
