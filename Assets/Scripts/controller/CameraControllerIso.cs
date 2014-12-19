using UnityEngine;
using System.Collections;

public class CameraControllerIso : MonoBehaviour
{
    public GameObject target;
    public float distance = 8;
    public float minDistance = 2;
    public float maxDistance = 10;
    public float cameraSmoothing = 0.01f;
    public float cameraPreview = 2.0f;
    private Vector3 velocity;
    private float distanceComputed;
    private float targetRotationY;
    private Vector3 previousMousePosition = Vector3.zero;
    private bool lockMouse = false;

    void Start()
    {
        camera.transform.rotation = Quaternion.Euler(60, 45, 0);
    }

    void Update()
    {
        distance = Mathf.Clamp(distance - (Settings.controls.scrollAxis() * 10), minDistance, maxDistance);
        distanceComputed = Mathf.Lerp(distanceComputed, distance, Time.deltaTime * 5);
        if (Settings.controls.getKey(Controls.CAMERA_ROTATE_LEFT))
            targetRotationY -= Time.deltaTime * 100;
        if (Settings.controls.getKey(Controls.CAMERA_ROTATE_RIGHT))
            targetRotationY += Time.deltaTime * 100;
        float deltaRotate = Mathf.Lerp(targetRotationY, 0, Time.deltaTime * 10);
        camera.transform.Rotate(Vector3.up, targetRotationY - deltaRotate, Space.World);
        targetRotationY = deltaRotate;
    }

    void LateUpdate()
    {
        Vector2 JoystickAxis = new Vector2(Input.GetAxis("JoyRightHorizontal"), -Input.GetAxis("JoyRightVertical"));
        if (JoystickAxis.magnitude > 0 || (lockMouse && previousMousePosition == Input.mousePosition))
        {
            lockMouse = true;
            previousMousePosition = Input.mousePosition;
            Quaternion screenMovementSpace = Quaternion.Euler(0, transform.eulerAngles.y, 0);
            Vector3 screenMovementForward = screenMovementSpace * Vector3.forward;
            Vector3 screenMovementRight = screenMovementSpace * Vector3.right;

            Vector3 cameraAdjustmentVector = JoystickAxis.x * screenMovementRight + JoystickAxis.y * screenMovementForward;
            Vector3 cameraTargetPosition = target.transform.position + cameraAdjustmentVector * cameraPreview - transform.forward * distanceComputed;

            transform.position = Vector3.SmoothDamp(transform.position, cameraTargetPosition, ref velocity, cameraSmoothing);
            target.GetComponent<CharacterControllerIsometricPlayer>().noMouse = true;
        }
        else
        {
            target.GetComponent<CharacterControllerIsometricPlayer>().noMouse = false;

            lockMouse = false;
            float halfWidth = Screen.width / 2.0f;
            float halfHeight = Screen.height / 2.0f;
            float maxHalf = Mathf.Max(halfWidth, halfHeight);

            Vector3 posRel = Input.mousePosition - new Vector3(halfWidth, halfHeight, Input.mousePosition.z);
            posRel.x = Mathf.Clamp(posRel.x / maxHalf, -1, 1);
            posRel.y = Mathf.Clamp(posRel.y / maxHalf, -1, 1);

            Quaternion screenMovementSpace = Quaternion.Euler(0, transform.eulerAngles.y, 0);
            Vector3 screenMovementForward = screenMovementSpace * Vector3.forward;
            Vector3 screenMovementRight = screenMovementSpace * Vector3.right;

            Vector3 cameraAdjustmentVector = posRel.x * screenMovementRight + posRel.y * screenMovementForward;
            cameraAdjustmentVector.y = 0;
            Vector3 cameraTargetPosition = target.transform.position + cameraAdjustmentVector * cameraPreview - transform.forward * distanceComputed;

            transform.position = Vector3.SmoothDamp(transform.position, cameraTargetPosition, ref velocity, cameraSmoothing);
        }
    }
}
