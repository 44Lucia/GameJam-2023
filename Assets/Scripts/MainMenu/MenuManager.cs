using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Game
{
    public class MenuManager : Singleton<MenuManager>
    {
        private GameObject pnl_mainMenu;
        private GameObject pnl_settings;
        private GameObject pnl_credits;

        Scene m_currentScene = null;

        private void Awake()
        {
            base.Awake();
            GetReferences();
        }

        // Start is called before the first frame update
        private void Start()
        {
            if (pnl_settings != null)
            {
                pnl_settings.SetActive(false);
            }
            if (pnl_credits != null)
            {
                pnl_credits.SetActive(false);
            }
        }

        // Update is called once per frame
        /*private void Update()
        {

        }*/

        private void GetReferences()
        {
            GameObject tempGO = GameObject.Find("pnl_MainMenu");
            if (tempGO != null)
            {
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

        public void OpenMainMenu()
        {
            pnl_credits.SetActive(false);
            pnl_settings.SetActive(false);
            pnl_mainMenu.SetActive(true);
            SoundManager.Instance.PlayOnce(AudioClipName.CLICK_MENU);
        }

        public void OpenCredits()
        {
            pnl_credits.SetActive(true);
            pnl_settings.SetActive(false);
            pnl_mainMenu.SetActive(false);
            SoundManager.Instance.PlayOnce(AudioClipName.CLICK_MENU);
        }

        public void OpenSettings()
        {
            pnl_credits.SetActive(false);
            pnl_settings.SetActive(true);
            pnl_mainMenu.SetActive(false);
            SoundManager.Instance.PlayOnce(AudioClipName.CLICK_MENU);
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            SoundManager.Instance.PlayOnce(AudioClipName.CLICK_MENU);
#else
        Application.Quit();
#endif
        }

        public void StartGame()
        {
            //Enable Player Input
            SoundManager.Instance.PlayOnce(AudioClipName.CLICK_MENU);
            SceneManager.LoadScene("GameScene");
        }

        public void SetCurrentScene(Scene p_scene)
        {
            m_currentScene = p_scene;
            SoundManager.Instance.PlayBackground(m_currentScene.BackgroundMusic);
        }

        public BackGroundClipName GetCurrentBackgroudClipName() { return m_currentScene.GetCurrentBackgroudClipName(); }
    }
}
