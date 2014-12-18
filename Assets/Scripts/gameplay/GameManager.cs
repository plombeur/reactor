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
            Debug.Log(player);
            instance = this;
            DontDestroyOnLoad(gameObject);

            loadSettings();
        }

    }

    void Update()
    {
        if (player.GetComponentInChildren<UseSystem>().isUsableTarget())
        {
            getHUD().usePan.SetActive(true);
            if (Settings.controls.getKey(Controls.USE))
                player.GetComponentInChildren<UseSystem>().getUsable().use();
        }
        else
            getHUD().usePan.SetActive(false);

        Living livingPlayer = player.GetComponent<Living>();

        hud.setLifeProgressBar(Math.Max(0, (float)livingPlayer.hp / (float)livingPlayer.maxHP) * 100.0f);
    }

    void OnLevelWasLoaded(int level)
    {
        player = GameObject.FindGameObjectWithTag("Player");
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

        hud.setGameOver("Tu as gagné !", "Bravo, tu as réussi a ....");
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