using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameManager : MonoBehaviour
{
    public HUD hud;

    private static GameManager instance;
    private GameObject player;

    private bool gameOver = false;
    private bool gameWin = false;

    private float savePlayerHP;

    void Start()
    {
        if (instance != null)
        {
            Debug.Log("GameManager already instancied, destroy the new one");
            Destroy(gameObject);
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Player");
            instance = this;
            DontDestroyOnLoad(gameObject);

            loadSettings();
        }

    }

    void Update()
    {
        if (isGameOver())
        {
            Time.timeScale = 0;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            if (Input.GetButtonDown("Submit"))
            {
                savePlayerHP = player.GetComponent<Living>().maxHP;
                player.GetComponent<Living>().dead = false;
                gameOver = false;
                Application.LoadLevel(Application.loadedLevel);
            }

        }
        if (player.GetComponent<Living>().isDead())
        {
            if (!isGameOver())
                setGameLost("Vous avez été éliminé");

            return;
        }

        if (player.GetComponentInChildren<UseSystem>().isUsableTarget())
        {
            getHUD().usePan.SetActive(true);
            if (Settings.controls.getKey(Controls.USE) || Input.GetButton("Use"))
                player.GetComponentInChildren<UseSystem>().getUsable().use();
        }
        else
            getHUD().usePan.SetActive(false);

        if (getHUD().getInformationWindow().infoWindowPanel.gameObject.activeSelf && Input.GetButtonDown("Submit"))
            getHUD().getInformationWindow().hideInfoPanel();
        else if (getHUD().getObjectifWindow().objectifWindowPanel.gameObject.activeSelf && Input.GetButtonDown("Submit"))
            getHUD().getObjectifWindow().hideObjectifWindow();

        if (Input.GetButtonDown("Info"))
            getHUD().getInformationWindow().showInfoPanel();

        if (Input.GetButtonDown("Cancel"))
            getHUD().getObjectifWindow().showObjectifWindow();

        Living livingPlayer = player.GetComponent<Living>();

        hud.setLifeProgressBar(Math.Max(0, (float)livingPlayer.hp / (float)livingPlayer.maxHP) * 100.0f);
        savePlayerHP = livingPlayer.hp;
    }

    void OnLevelWasLoaded(int level)
    {
        if (instance != this)
            return;
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        hud = GameObject.FindObjectOfType<HUD>();
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Living>().hp = savePlayerHP;
    }
    public GameObject getPlayer()
    {
        return player;
    }
    private void loadSettings()
    {
        Settings.controls = new Controls("controls.cfg");
        if (!Settings.controls.load())
            Settings.controls.loadDefault();
        Settings.controls.save();

    }
  
    public static GameManager getInstance()
    {
        return instance;
    }

    public void changeLevel(string level)
    {
        
    }

    public void setGameLost(string reasonText)
    {
        gameOver = true;
        gameWin = false;

        hud.getObjectifWindow().hideObjectifMiniWindow();
        hud.getObjectifWindow().hideObjectifWindow();
        hud.getInformationWindow().hideInfoPanel();

        hud.setGameOver("Echec de la mission !", reasonText);
    }

    public void setGameWin()
    {
        gameOver = true;
        gameWin = true;

        hud.getObjectifWindow().hideObjectifMiniWindow();
        hud.getObjectifWindow().hideObjectifWindow();
        hud.getInformationWindow().hideInfoPanel();

        hud.setGameOver("Mission accomplie !", "Félicitation, la mission est un succes");
    }

    public bool isGameOver()
    {
        return gameOver;
    }
    public bool isGameWon()
    {
        return gameWin;
    }
    public HUD getHUD()
    {
        return hud;
    }
}