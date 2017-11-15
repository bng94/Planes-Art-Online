using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class sliderSettings : MonoBehaviour {

	public Slider volumeSlider;

	// Use this for initialization
	void Start () {
		if (volumeSlider == null) {
			volumeSlider = GameObject.Find ("volumeSlider").GetComponent<Slider> ();
		}

		volumeSlider.value = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		PlayerPrefs.SetFloat ("volume", volumeSlider.value);
	}
}
