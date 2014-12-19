using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{

	public void play()
    {
        Application.LoadLevel(1);
    }
    public void exit()
    {
        Application.Quit();
    }
}
