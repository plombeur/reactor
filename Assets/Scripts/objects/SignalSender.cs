using UnityEngine;
using System.Collections;

[System.Serializable]
public class SignalSender
{
    public bool onlyOnce;
    public ReceiverItem[] receivers;

    private bool hasFired = false;

    public void sendSignals(MonoBehaviour sender)
    {
        if (hasFired == false || onlyOnce == false)
        {
            for (var i = 0; i < receivers.Length; i++)
                receivers[i].send(sender);
            hasFired = true;
        }
    }
}

[System.Serializable]
public class ReceiverItem
{
    public GameObject receiver;
    public string action;
    public float delay;

    public void send(MonoBehaviour sender)
    {
        sender.StartCoroutine(tempo(sender,delay));
	}
    IEnumerator tempo(MonoBehaviour sender, float time)
    {
        yield return new WaitForSeconds(time);
        if (receiver)
			receiver.SendMessage (action);
		else
			Debug.LogError ("No receiver of signal", sender);
    }
}