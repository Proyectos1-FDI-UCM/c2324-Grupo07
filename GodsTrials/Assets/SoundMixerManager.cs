using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    #region references
    [SerializeField] 
    private AudioMixer audioMixer;
    #endregion

    public void SetMasterVolume (float level)
    {
        audioMixer.SetFloat("masterVolume", Mathf.Log10(level)*20f);
    }

    public void SetSoundFXVolume(float level)
    {
        audioMixer.SetFloat("soundFXVolume", Mathf.Log10(level)*20f);
    }
    
    public void SetMusicVolume (float level)
    {
        audioMixer.SetFloat("musicVolume", Mathf.Log10(level)*20f);
        print("Level: " + level);
        print("MusicVol: " + Mathf.Log10(level)*20f);
    }
}
