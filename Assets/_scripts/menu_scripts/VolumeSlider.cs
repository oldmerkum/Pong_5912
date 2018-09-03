using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour {
	public AudioSource paddleHit;
	public AudioSource wallHit;
	public AudioSource goalHit;
	public void VolumeController(Slider volumeSlider)
	{
		paddleHit.volume = volumeSlider.value;
		wallHit.volume = volumeSlider.value;
		goalHit.volume = volumeSlider.value;
	}
}