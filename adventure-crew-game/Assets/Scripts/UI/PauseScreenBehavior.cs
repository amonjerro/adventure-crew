using Backend;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseScreenBehavior : UIMenu
{
    public GameObject pauseScreenUI;
    private bool _isPaused = false;
    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        _isPaused = !_isPaused;
        if (_isPaused)
        {
            // Open Pause Menu
            Time.timeScale = 0.0f;
            pauseScreenUI.SetActive(true);
        } else
        {
            // Close Pause Menu
            Time.timeScale = 1.0f;
            pauseScreenUI.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        //To do: Reset whatever is in DontDestroyOnLoad objects
        CombatData.Reset();
        AdventurerList.Reset();
        CurrencySystem.Instance.Reset();

        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public override void CursorOrder(int i)
    {
        switch(i){
            case 0:
                PauseGame();
                break;
            case 1:
                BackToMainMenu();
                break;
            default:
                QuitGame();
                break;
        }
    }
}
