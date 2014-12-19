using UnityEngine;
using System.Collections;

public class BatteryPoint : Action
{
    public Level3Manager levelManager3;
    public bool allCollected = false;

    protected override void onExecute()
    {
        if (allCollected)
        {
            levelManager3.exitTeleporter.enabled = true;
            levelManager3.exitTeleporterLight.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
