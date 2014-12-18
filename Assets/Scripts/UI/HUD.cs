using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public ProgressBar lifeBar;

    public GameObject WinPanel;
    public Text titleWin, descriptionWin;

    private InfoWindow infoWindow;
    private ObjectifWindow objectifWindow;
    private static HUD instance;

    void Start()
    {
        if (instance != null)
        {
            Destroy(transform.parent);
            return;
        }
        instance = this;
        infoWindow = GetComponentInChildren<InfoWindow>();
        objectifWindow = GetComponentInChildren<ObjectifWindow>();
        WinPanel.SetActive(false);
        DontDestroyOnLoad(transform.parent);
    }

    public void setLifeProgressBar(float percent)
    {
        lifeBar.progress = percent;
    }
    public void setGameOver(string title,string description)
    {
        titleWin.text = title;
        descriptionWin.text = description;
        WinPanel.SetActive(true);
    }

    public InfoWindow getInformationWindow()
    {
        return infoWindow;
    }
    public ObjectifWindow getObjectifWindow()
    {
        return objectifWindow;
    }
}
