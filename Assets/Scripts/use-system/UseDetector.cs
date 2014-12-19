using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UseDetector : MonoBehaviour
{
    private UseSystem useSystem;
    private Usable usableTarget;
    public List<Usable> visibles;

    void Start()
    {
        visibles = new List<Usable>();
    }

    void Update()
    {
        if (!useSystem)
            return;
        Usable usableToTarget = null;
        float usableToTargetAngle = 0;
        foreach (Usable u in visibles)
        {
            if (u == null)
                continue;
            float angle = Vector3.Angle(transform.forward, u.transform.position - transform.position);
            if (Mathf.Abs(angle) <= useSystem.angleForUse)
            {
                if (usableToTarget == null || angle < usableToTargetAngle)
                {
                    usableToTarget = u;
                    usableToTargetAngle = angle;
                }
            }
        }
        usableTarget = usableToTarget;
    }
    public Usable getUsableTarget()
    {
        return usableTarget;
    }
    public void setParentUseSystem(UseSystem system)
    {
        this.useSystem = system;
    }
    void OnTriggerEnter(Collider other)
    {
        Usable usable = other.GetComponent<Usable>();
        if (usable != null)
            visibles.Add(usable);
    }
    void OnTriggerExit(Collider other)
    {
        Usable usable = other.GetComponent<Usable>();

        if (usable != null)
            visibles.Remove(usable);
    }
}