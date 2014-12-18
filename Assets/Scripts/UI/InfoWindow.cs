using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class InfoWindow : MonoBehaviour 
{
    public GameObject infoWindowPanel;
    public Text titleField;
    public Text textField;

	void Start ()
    {
        hideInfoPanel();
	}
	
	void Update () 
    {
        
	}

    public void showInfo(string title, string textContent)
    {
        titleField.text = title;
        textField.text = textContent;
        showInfoPanel();
    }

    public void hideInfoPanel()
    {
        infoWindowPanel.SetActive(false);
    }
    public void showInfoPanel()
    {
        infoWindowPanel.SetActive(true);
    }
}
