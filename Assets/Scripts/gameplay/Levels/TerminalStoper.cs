using UnityEngine;
using System.Collections;

public class TerminalStoper : Action
{
    public Level4Manager levelManager;

    protected override void onExecute()
    {
        levelManager.onDisabledTerminal();
    }
}
