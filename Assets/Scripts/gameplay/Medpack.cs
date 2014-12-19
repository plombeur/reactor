using UnityEngine;
using System.Collections;

public class Medpack : Action 
{
    public Living player;
    public Transform indicator;

    void Update()
    {
        indicator.transform.position = transform.position + Vector3.up * 26;
    }

    protected override void onExecute()
    {
        player.heal(250);
    }
}
