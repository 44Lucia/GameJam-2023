using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);

        InputManager._INPUT_MANAGER.AddListennerToPressScape(MenuPause);
    }

    public void MenuPause()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            InputManager._INPUT_MANAGER.RemoveListennerToPressScape(MenuPause);
        }
    }

    public void ToGameAgain()
    {
        InputManager._INPUT_MANAGER.AddListennerToPressScape(MenuPause);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

}
