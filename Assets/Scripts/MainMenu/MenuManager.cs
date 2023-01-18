using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private GameObject pnl_mainMenu;
    private GameObject pnl_settings;
    private GameObject pnl_credits;

    private void Awake()
    {
        GetReferences();
    }

    // Start is called before the first frame update
    private void Start()
    {
        pnl_settings.SetActive(false);
        pnl_credits.SetActive(false);

        SoundManager.Instance.PlayBackground(BackGroundClipName.MUSIC_1);
    }

    // Update is called once per frame
    /*private void Update()
    {
        
    }*/

    private void GetReferences() {
        GameObject tempGO = GameObject.Find("pnl_MainMenu");
        if (tempGO != null) {
            pnl_mainMenu = tempGO;
        }

        tempGO = GameObject.Find("pnl_Settings");
        if (tempGO != null)
        {
            pnl_settings = tempGO;
        }

        tempGO = GameObject.Find("pnl_Credits");
        if (tempGO != null)
        {
            pnl_credits = tempGO;
        }
    }

    public void OpenMainMenu() {
        pnl_credits.SetActive(false);
        pnl_settings.SetActive(false);
        pnl_mainMenu.SetActive(true);
    }

    public void OpenCredits()
    {
        pnl_credits.SetActive(true);
        pnl_settings.SetActive(false);
        pnl_mainMenu.SetActive(false);
    }

    public void OpenSettings()
    {
        pnl_credits.SetActive(false);
        pnl_settings.SetActive(true);
        pnl_mainMenu.SetActive(false);
    }

    public void QuitGame() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void StartGame() {
        //Enable Player Input
        SceneManager.LoadScene("GameScene");
    }
}
