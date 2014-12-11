using UnityEngine;
using System.Collections;

public class AIEngineer : MonoBehaviour
{
    public float speed = 1;
    public CheckPoint[] checkpoints;

    private int index = 0;
    private int sens = 1;
    private float waitingTime = 0;
    private bool isWaiting = false;

    void Start()
    {

    }

    void Update()
    {
        if (!isWaiting && (int)transform.position.x == (int)checkpoints[index].transform.position.x && (int)transform.position.z == (int)checkpoints[index].transform.position.z)
        {
            waitingTime = checkpoints[index].waitTime;
            isWaiting = true;
        }

        if (isWaiting)
        {
            waitingTime -= Time.deltaTime;
            if (waitingTime <= 0)
            {
                index += sens;
                isWaiting = false;
            }

        }

        if (index >= checkpoints.Length)
        {
            index = Mathf.Max(checkpoints.Length - 2, 0);
            sens = -1;
        }
        else if (index < 0)
        {
            index = Mathf.Min(1, checkpoints.Length - 1);
            sens = 1;
        }

        if (!isWaiting)
        {

            
            Vector3 dir = (checkpoints[index].transform.position - transform.position);
            dir.y = 0;
            rigidbody.velocity = dir.normalized * Time.deltaTime * speed;
            //rigidbody.AddForce(dir.normalized * Time.deltaTime * speed,ForceMode.VelocityChange);
            transform.LookAt(transform.position + dir);
        }

    }
}
[System.Serializable]
public struct CheckPoint
{
    public Transform transform;
    public float waitTime;
}
