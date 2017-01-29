using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Options : MonoBehaviour {
	
	public float musicVolume;
	public Slider musicVolumeSlider;
	public AudioSource MusicSrc;

	void Start()
	{
		musicVolumeSlider.onValueChanged.AddListener (delegate {OnMusicVolumeSlider();});
	}
	public void OnMusicVolumeSlider()
	{
		MusicSrc.volume = musicVolume = musicVolumeSlider.value;
	}

}
