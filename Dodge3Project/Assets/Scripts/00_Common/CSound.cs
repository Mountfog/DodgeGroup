using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Sound 클래스
 *   
 *   SFX (= Sound Effects 의 약어 )
 */
public class CSound : MonoBehaviour
{
    public bool m_isBGM = false;
    [HideInInspector] public AudioSource m_AudioSource = null;

    public bool IsUseSFX { get; set; }
    public bool IsUseBgm { get; set; }

    void Awake()
    {
        Load();
    }

    private void OnEnable()
    {
        if (m_AudioSource == null)
            m_AudioSource = GetComponent<AudioSource>();

        Initialize_Bgm();
        Initialize_SFX();
    }

    private void Initialize_Bgm()
    {
        if (m_isBGM)
        {
            if (IsUseBgm && (m_AudioSource.loop || m_AudioSource.playOnAwake))
                m_AudioSource.Play();
            else
                m_AudioSource.Stop();
        }
    }
    private void Initialize_SFX()
    {
        if (!m_isBGM)
        {
            if (IsUseSFX && (m_AudioSource.loop || m_AudioSource.playOnAwake))
                m_AudioSource.PlayOneShot(m_AudioSource.clip);
            else
                m_AudioSource.Stop();
        }
    }

    public void Play()
    {
        if (m_isBGM && IsUseBgm)
            m_AudioSource.Play();

        if (!m_isBGM && IsUseSFX)
            m_AudioSource.PlayOneShot(m_AudioSource.clip);
    }

    public void Stop()
    {
        m_AudioSource.Stop();
    }


    public void Load()
    {
        int value = PlayerPrefs.GetInt("SFX", 1);
        IsUseSFX = value == 1 ? true : false;

        value = PlayerPrefs.GetInt("BGM", 1);
        IsUseBgm = value == 1 ? true : false;

    }


    public void Save()
    {
        int value = IsUseSFX ? 1 : 0;
        PlayerPrefs.SetInt("SFX", value);

        value = IsUseBgm ? 1 : 0;
        PlayerPrefs.SetInt("BGM", value);
    }

}

