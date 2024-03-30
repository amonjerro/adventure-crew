using Backend;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenBehavior : UIMenu
{
    public GameObject mainMenuHolder;
    public GameObject optionsHolder;
    public GameObject cursor;

    private void Start()
    {
        CurrencySystem.Activate();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToggleOptions()
    {
        mainMenuHolder.SetActive(!mainMenuHolder.activeInHierarchy);
        optionsHolder.SetActive(!optionsHolder.activeInHierarchy);
    }

    public override void CursorOrder(int i)
    {
        // Handle the cursor in the main intro screen
        if (mainMenuHolder.activeInHierarchy)
        {
            switch (i)
            {
                case 0:
                    StartGame();
                    break;
                case 1:
                    ToggleOptions();
                    break;
                default:
                    QuitGame();
                    break;
            }
        }
        // Handle the cursor in the options menu
        else if (optionsHolder.activeInHierarchy)
        {
            switch (i)
            {
                default:
                    ToggleOptions();
                    break;
            }
        }
    }
}
