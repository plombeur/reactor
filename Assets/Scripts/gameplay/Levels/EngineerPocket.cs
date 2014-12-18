using UnityEngine;
using System.Collections;

public class EngineerPocket : Action
{
    public Level2Manager level2Manager;

    protected override void onExecute()
    {
        level2Manager.onTouchEngineer();
    }
}
