using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class menuButtons : MonoBehaviour {

	//loads menu scene
	public void Menu(){
		SceneManager.LoadScene ("MenuScene");
	}
	public void preGame(){
		SceneManager.LoadScene ("Pre-Game");
	}
	//loads level 1 scene
	public void startGame()
	{
		SceneManager.LoadScene ("Level 1");
	}
		//quits the game 
	public void QuitGame()
	{
		Application.Quit ();
	}
	public void highScores(){
		SceneManager.LoadScene ("highScore");
	}
}
