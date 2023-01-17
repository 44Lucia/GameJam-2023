using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioClipName
{
    CLICK_MENU, HOVER_MENU, LAST_NO_USE
}

public enum SCENE { MAIN_MENU, PAUSE_MENU, LEVEL, VICTORY, LAST_NO_USE }

public enum BackGroundClipName
{
    MUSIC_1, MUSIC_2, MUSIC_3, MUSIC_4, LAST_NO_USE
}

public class SoundManager : MonoBehaviour
{
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_clickMenu = 1;
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_backgroundSound = 1;
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_backgroundSound2 = 1;
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_backgroundSound3 = 1;
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_backgroundSound4 = 1;
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_hoverMenu = 1;

    static SoundManager m_instance;
    [SerializeField] AudioSource m_effects;
    [SerializeField] AudioSource m_background;
    AudioClip[] m_audioClips;
    float[] m_volumeEffects;
    float m_generalVolumeEffects = 1;

    AudioClip[] m_backgroundMusic;
    float[] m_volumeBackground;
    float m_generalVolumeBackground = 1;

    // Start is called before the first frame update
    private void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
            Initiate();
            DontDestroyOnLoad(this.gameObject);
        }
        else { Destroy(this); }
    }

    private void Start()
    {
        m_background.loop = true;
        m_effects.loop = false;
    }

    public static SoundManager Instance { get { return m_instance; } private set { } }

    void Initiate()
    {
        m_background.loop = true;
        m_background.volume = 1f;
        m_effects.loop = false;
        m_effects.volume = 1;

        m_audioClips = new AudioClip[(int)AudioClipName.LAST_NO_USE];
        m_audioClips[(int)AudioClipName.CLICK_MENU] = Resources.Load<AudioClip>("Sound/ClickMenuSFX");
        m_audioClips[(int)AudioClipName.HOVER_MENU] = Resources.Load<AudioClip>("Sound/HoverSFX");

        // SAVE ALL THE VOLUMES SET IN THE INSPECTOR TO AN ARRAY
        m_volumeEffects = new float[(int)AudioClipName.LAST_NO_USE];
        m_volumeEffects[(int)AudioClipName.CLICK_MENU] = m_clickMenu;
        m_volumeEffects[(int)AudioClipName.HOVER_MENU] = m_hoverMenu;

        // LOAD ALL THE MUSIC CLIPS
        m_backgroundMusic = new AudioClip[(int)BackGroundClipName.LAST_NO_USE];
        m_backgroundMusic[(int)BackGroundClipName.MUSIC_1] = Resources.Load<AudioClip>("Sound/BackgroundSound2");
        m_backgroundMusic[(int)BackGroundClipName.MUSIC_2] = Resources.Load<AudioClip>("Sound/BackgroundSound2");
        m_backgroundMusic[(int)BackGroundClipName.MUSIC_3] = Resources.Load<AudioClip>("Sound/victoria");
        m_backgroundMusic[(int)BackGroundClipName.MUSIC_4] = Resources.Load<AudioClip>("Sound/derrota");

        // SAVE ALL THE VOLUMES SET IN THE INSPECTOR TO AN ARRAY
        m_volumeBackground = new float[(int)SCENE.LAST_NO_USE];
        m_volumeBackground[(int)BackGroundClipName.MUSIC_1] = m_backgroundSound;
        m_volumeBackground[(int)BackGroundClipName.MUSIC_2] = m_backgroundSound2;
        m_volumeBackground[(int)BackGroundClipName.MUSIC_3] = m_backgroundSound3;
        m_volumeBackground[(int)BackGroundClipName.MUSIC_4] = m_backgroundSound4;
    }

    public void PlayOnce(AudioClipName p_name)
    {
        if (m_audioClips[(int)p_name] == null) { return; }
        m_effects.volume = m_generalVolumeEffects * m_volumeEffects[(int)p_name];
        m_effects.PlayOneShot(m_audioClips[(int)p_name]);
    }

    public void PlayBackground(BackGroundClipName p_name)
    {
        if (m_backgroundMusic[(int)p_name] == null) { return; }
        m_background.volume = m_generalVolumeBackground * m_volumeBackground[(int)p_name];
        m_background.clip = m_backgroundMusic[(int)p_name];
        m_background.Play();
    }

    public float GetAudioClipDuration(AudioClipName p_name)
    {
        return m_audioClips[(int)p_name].length;
    }

    public void SetBackgroundVolume(float p_value)
    {
        float volumeValue;
        if (p_value < 0) { volumeValue = 0; }
        else if (p_value > 1) { volumeValue = 1; }
        else { volumeValue = p_value; }
        m_generalVolumeBackground = volumeValue;
        m_background.volume = m_generalVolumeBackground;
    }
    public void SetEffectsVolume(float p_value)
    {
        float volumeValue;
        if (p_value < 0) { volumeValue = 0; }
        else if (p_value > 1) { volumeValue = 1; }
        else { volumeValue = p_value; }
        m_generalVolumeEffects = volumeValue;
    }

    public float EffectVolume { get { return m_generalVolumeEffects; } }
    public float BackgroundVolume { get { return m_generalVolumeBackground; } }

    public AudioClip[] GetBackgroundMusic() { return m_backgroundMusic; }
    public AudioClip GetBackgroundMusicByIndex(int index) { return m_backgroundMusic[index]; }
}