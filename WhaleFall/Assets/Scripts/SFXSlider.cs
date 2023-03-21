using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXSlider : MonoBehaviour
{
    public Slider sfxSlider;
    public AudioSource[] sfxSources;

    void Start()
    {
        sfxSlider.value = 0.5f;
        foreach (AudioSource sfxSource in sfxSources)
        {
            sfxSource.volume = sfxSlider.value;
        }
    }

    void Update()
    {
        foreach (AudioSource sfxSource in sfxSources)
        {
            sfxSource.volume = sfxSlider.value;
        }
    }
}
