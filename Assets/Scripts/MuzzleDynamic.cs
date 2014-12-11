using UnityEngine;
using System.Collections;

public class MuzzleDynamic : MonoBehaviour 
{
    public float scaleMin= 0.2f;
    public float scaleMax = 0.7f;
  
    void Update()
    {
        transform.localScale = Vector3.one * Random.Range(scaleMin, scaleMax);
        transform.localEulerAngles  = new Vector3(transform.localEulerAngles.x,transform.localEulerAngles.y, Random.Range(0, 90.0f));
    }
}
