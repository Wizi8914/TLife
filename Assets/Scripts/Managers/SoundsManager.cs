using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundsManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource.Play();
    }

    public void SetLevelMaster(float sliderValue)
    {
        audioMixer.SetFloat("Master_Volume", Mathf.Log10(sliderValue)* 20);
    }
    public void SetLevelMusic(float sliderValue)
    {
        audioMixer.SetFloat("Music_Volume", Mathf.Log10(sliderValue)* 20);
    }
    public void SetLevelSFX(float sliderValue)
    {
        audioMixer.SetFloat("SFX_Volume", Mathf.Log10(sliderValue)* 20);
    }
}
