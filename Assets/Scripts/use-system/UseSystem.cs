using UnityEngine;
using System.Collections;

public class UseSystem : MonoBehaviour
{
    public float radius = 1;
    public float angleForUse = 60;
    private UseDetector usableDetector;


    void Start()
    {
        GameObject usableDetectorObject = new GameObject("UsableDetector");
        usableDetectorObject.transform.parent = transform;
        usableDetector = usableDetectorObject.AddComponent<UseDetector>();
        usableDetectorObject.transform.localPosition = Vector3.zero;
        SphereCollider collider = usableDetectorObject.AddComponent<SphereCollider>();
        usableDetectorObject.AddComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        usableDetector.setParentUseSystem(this);
        collider.radius = radius;
        collider.isTrigger = true;
    }

    void Update()
    {

    }

    public bool isUsableTarget()
    {
        return usableDetector.getUsableTarget() != null;
    }

    public Usable getUsable()
    {
        return usableDetector.getUsableTarget();
    }

   
}
