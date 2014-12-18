using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomDoor : MonoBehaviour
{
    private bool doorLocked = false;
    private bool doorOpened = false;
    public SignalSender enterSignals;
    public SignalSender exitSignals;

    private List<GameObject> objects;

    void Awake()
    {
        objects = new List<GameObject>();
    }
    public bool isOpen()
    {
        return doorOpened;
    }
    public bool isLocked()
    {
        return doorLocked;
    }
    public void lockDoor()
    {
        doorLocked = true;
        if (isOpen())
            close();
    }
    public void unlockDoor()
    {
        if (!isLocked())
            return;

        doorLocked = false;

        if (objects.Count > 0)
            open();

    }
    private void close()
    {
        doorOpened = false;
        exitSignals.sendSignals(this);
    }
    private void open()
    {
        if (isLocked())
            return;
        doorOpened = true;
        enterSignals.sendSignals(this);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger || (other.tag != "Player" && other.tag != "Enemy"))
            return;

        bool wasEmpty = (objects.Count == 0);

        objects.Add(other.gameObject);

        if (wasEmpty)
            open();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.isTrigger || (other.tag != "Player" && other.tag != "Enemy"))
            return;

        if (objects.Contains(other.gameObject))
            objects.Remove(other.gameObject);

        if (objects.Count == 0)
            close();
    }
}