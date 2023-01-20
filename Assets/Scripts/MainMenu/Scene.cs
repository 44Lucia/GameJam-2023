using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Scene : MonoBehaviour
    {
        [SerializeField] BackGroundClipName m_backgroundMusic;
        BackGroundClipName m_currentBackgroundClip;

        private void Start()
        {
            SetUpScene();
        }

        public void SetUpScene()
        {
            MenuManager.Instance.SetCurrentScene(this);
            m_currentBackgroundClip = m_backgroundMusic;
        }

        public BackGroundClipName BackgroundMusic { get { return m_backgroundMusic; } }
        public BackGroundClipName GetCurrentBackgroudClipName() { return m_currentBackgroundClip; }
    }
}
