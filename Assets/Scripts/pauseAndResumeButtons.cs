using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class pauseAndResumeButtons : MonoBehaviour {

	public Canvas pauseCanvas;

	//pause game 
	public void PauseGame()
	{
		Time.timeScale = 0.0f;
		pauseCanvas.enabled = true;
		soundManager.musicSource.Pause ();
	}
	//resumes games 
	public void ResumeGame()
	{
		pauseCanvas.enabled = false;
		Time.timeScale = 1.0f;
		soundManager.musicSource.UnPause ();
	}
}
