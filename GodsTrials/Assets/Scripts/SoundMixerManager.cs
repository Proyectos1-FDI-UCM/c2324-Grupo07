using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundMixerManager : MonoBehaviour
{
    #region references
    [SerializeField] 
    private AudioMixer audioMixer;

    public Slider musicSlider;
    public Slider fxSlider;
    public Slider masterSlider;
    #endregion

    #region methods
    public void SetMasterVolume(){
        audioMixer.SetFloat("masterVolume", Mathf.Log10(masterSlider.value)*20f);
    }

    public void SetSoundFXVolume(){
        audioMixer.SetFloat("soundFXVolume", Mathf.Log10(fxSlider.value)*20f);
    }
    
    public void SetMusicVolume(){
        audioMixer.SetFloat("musicVolume", Mathf.Log10(musicSlider.value)*20f);
    }

    public void OffMusic(){
        audioMixer.SetFloat("musicVolume", 0);
    }
    #endregion
}
