using UnityEngine;
using System.Collections;

public class CameraController3Pers : MonoBehaviour
{
    public Transform target;
    public float optimalRange = 10;
    public float localAngleX;
    public float localAngleY;
    public float speedRotateX = 50;
    public float speedRotateY = 50;
    public Vector3 offset;

    public bool blockMouse = false;

    void Start()
    {
    }

    void LateUpdate()
    {
        Vector2 joystickRight = new Vector2(Input.GetAxis("JoyRightHorizontal"),Input.GetAxis("JoyRightVertical"));
        Vector2 mouseXY = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        Vector2 result = (joystickRight + mouseXY).normalized;

        localAngleY -= result.y * Time.deltaTime * speedRotateY;
        localAngleX += result.x * Time.deltaTime * speedRotateX;

        target.transform.Rotate(Vector3.up, result.y * Time.deltaTime * speedRotateY,Space.Self);
        target.transform.Rotate(Vector3.right, result.x * Time.deltaTime * speedRotateX, Space.Self);

       // Vector3 charDirection = Quaternion.AngleAxis(localAngleY, Vector3.right) * target.transform.forward;
        //charDirection = Quaternion.AngleAxis(localAngleX, Vector3.up) * charDirection;

        Vector3 direction = target.transform.forward;
       
        transform.LookAt(transform.position + direction);
        Ray ray = new Ray(target.transform.position + offset, -direction);
        RaycastHit[] hits = Physics.RaycastAll(ray, optimalRange);
        bool hitSomething = false;
        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                if (!hitSomething || (transform.position - ray.origin).magnitude > (hit.point - ray.origin).magnitude)
                {
                    transform.position = hit.point;
                    transform.Translate( hit.normal * 0.1f);
                }
                hitSomething = true;
            }
        }
        if (!hitSomething)
            transform.position = ray.GetPoint(optimalRange);
    }
    //Vector3.SmoothDamp(transform.position, cameraTargetPosition, ref velocity, cameraSmoothing);
}
