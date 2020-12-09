using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    List<AudioSource> sfx;

    private void Awake()
    {
        sfx = new List<AudioSource>();
        for (int i = 0; i < transform.childCount; i++)
        {
            sfx.Add(transform.GetChild(i).GetComponent<AudioSource>());
        }
    }

    public void PlaySoundEffect(int effectNum)
    {
        sfx[effectNum].Play();
    }
}
