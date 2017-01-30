using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioWhenPressed : MonoBehaviour {

    public AudioSource audioSource;
    public Slider slider;

    public void playSound()
    {
        if(audioSource != null)
        {
            audioSource.PlayOneShot(audioSource.clip, slider.value);
        }
    }
}
