using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class mainMusicSlider : MonoBehaviour {

    public AudioMixer AudioController;

    public void setmaster(float Volume)
    {
        AudioController.SetFloat("AudioMix", Volume);
    }
}
