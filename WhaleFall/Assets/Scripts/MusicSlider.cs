using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    public Slider musicSlider;
    public AudioSource[] musicSources;

    void Start()
    {
        musicSlider.value = 0.5f;
        foreach (AudioSource musicSource in musicSources)
        {
            musicSource.volume = musicSlider.value;
        }
    }

    void Update()
    {
        foreach (AudioSource musicSource in musicSources)
        {
            musicSource.volume = musicSlider.value;
        }
    }
}
