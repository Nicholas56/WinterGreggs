using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    List<AudioSource> sfx;
    AudioSource music;

    private void Awake()
    {
        sfx = new List<AudioSource>();
        if (transform.childCount != 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                sfx.Add(transform.GetChild(i).GetComponent<AudioSource>());
            }
        }
        music = GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey("MusicValue"))
        {
            SetMusicVolume(PlayerPrefs.GetFloat("MusicValue"));
        }
        else { PlayerPrefs.SetFloat("MusicValue", 1f); }

        if (PlayerPrefs.HasKey("SFXValue"))
        {
            SetSFXVolume(PlayerPrefs.GetFloat("SFXValue"));
        }
        else { PlayerPrefs.SetFloat("SFXValue", 1f); }
    }

    public void PlaySoundEffect(int effectNum)
    {
        sfx[effectNum].Play();
    }

    public void ChangeMusicVolume(GameObject musicSlider)
    {
        Slider musicVolume = musicSlider.GetComponent<Slider>();
        music.volume = musicVolume.value;

        PlayerPrefs.SetFloat("MusicValue", musicVolume.value);
    }

    public void SetMusicVolume(float newValue)
    {
        music.volume = newValue;
    }

    public void ChangeSFXVolume(GameObject sfxSlider)
    {
        Slider sfxVolume = sfxSlider.GetComponent<Slider>();
        for (int i = 0; i < sfx.Count; i++)
        {
            sfx[i].volume = sfxVolume.value;
        }

        PlayerPrefs.SetFloat("SFXValue", sfxVolume.value);
    }

    public void SetSFXVolume(float newValue)
    {
        for (int i = 0; i < sfx.Count; i++)
        {
            sfx[i].volume = newValue;
        }
    }
}
