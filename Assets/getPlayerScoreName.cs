using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class getPlayerScoreName : MonoBehaviour {

	public Text score;
	public Text player;

	// Use this for initialization
	void Start () {
		if (score == null) {
			score = GameObject.Find ("score").GetComponent<Text> ();
		}
		if (player == null) {
			player = GameObject.Find ("playername").GetComponent<Text> ();
		}

		score.text = "Score: " + PlayerPrefsHelper.getPlayerScore ().ToString();
		player.text = "Player: " + PlayerPrefsHelper.getPlayerName ();


	}
}
