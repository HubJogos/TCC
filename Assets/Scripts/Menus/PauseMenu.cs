﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    /*
    //Requer implementação do sistema de save/load, a qual foi interrompida dada a data de entrega do projeto na época em que estava em implementação
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(script);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        script.playerLevel = data.level;
        script.currentHealth = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        script.transform.position = position;

    }
    */
    public void Reload()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);//controle de cenas foi movido para o script "UIManager"
        FindObjectOfType<MapGenAutomata>().RespawnPlayer();
        Resume();
    }
    public void QuitGame()
    {
        Debug.Log("quitting game");
        Application.Quit();
    }

}
