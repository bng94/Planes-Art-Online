using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public AudioSource efxSource;
	public static SoundManager instance = null;
	public float lowPitchRange = .95f;
	public float highPitchRange = 1.05f;

	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		efxSource.Play ();
		efxSource.volume = PlayerPrefs.GetFloat("volume");
	}

	public void RandomizeSfx (params AudioClip [] clips)
	{
		int randomIndex = Random.Range (0, clips.Length);
		float randomPitch = Random.Range (lowPitchRange, highPitchRange);

		efxSource.pitch = randomPitch;
		efxSource.clip = clips [randomIndex];
		efxSource.Play ();
	}

	public void PlaySingle (AudioClip clip)
	{
		efxSource.clip = clip;
		efxSource.Play ();
	}
		
	// Update is called once per frame
	void Update () {
		efxSource.volume = PlayerPrefs.GetFloat("volume");
	}
}
