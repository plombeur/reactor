using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public GameObject helpPan;

    void Start()
    {
        helpPan.SetActive(false);
    }

	public void play()
    {
        Application.LoadLevel(1);
    }
    public void exit()
    {
        Application.Quit();
    }

    public void toggleHelp()
    {
        helpPan.SetActive(!helpPan.activeSelf);
    }

}
