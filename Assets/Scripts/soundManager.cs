using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class soundManager : MonoBehaviour {

	public static AudioSource musicSource;
	public Slider volumeSlider;
	public float volume = 0.5f;

	// Use this for initialization
	void Start () {
		if (volumeSlider == null) {
			volumeSlider = GetComponent<Slider> ();
		}
		if (musicSource == null) {
			musicSource = GetComponent<AudioSource> ();
		}
		volumeSlider.value = volume;
		musicSource.volume = volume;
		musicSource.Play ();
	}
	// Update is called once per frame
	void Update () {
		musicSource.volume = volumeSlider.value;
	}

	public void soundControl(float volume){
		musicSource.volume = volume;
	}

}
