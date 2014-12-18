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

    public Text eventText;
    public GameObject usePan;

    private static HUD instance;
    public float eventDuration = 1;
    private float eventTimer = 0;

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
    void Update()
    {
        eventTimer -= Time.deltaTime;
        if (eventTimer <= 0)
            eventText.gameObject.SetActive(false);
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
    public void showEvent(string eventText)
    {
        this.eventText.gameObject.SetActive(true);
        eventTimer = eventDuration;
        this.eventText.text = eventText;
    }
}
