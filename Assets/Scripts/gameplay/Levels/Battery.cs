using UnityEngine;
using System.Collections;

public class Battery : Action
{
    public Transform indicatorMinimap;

    protected override void onExecute()
    {
        GameObject.FindObjectOfType<Level3Manager>().onPickBattery();
    }

    void Update()
    {
        indicatorMinimap.transform.position = transform.position + Vector3.up * 26;
    }
}
