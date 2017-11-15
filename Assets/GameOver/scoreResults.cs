using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreResults : MonoBehaviour {

	public Text playerName;
	public Text scores;
	private int score;

	// Use this for initialization
	void Start () {
		playerName = GameObject.Find ("nameText").GetComponent<Text> ();
		scores = GameObject.Find ("numberText").GetComponent<Text> ();

		playerName.text = PlayerPrefs.GetString ("playerName");
		score = PlayerPrefs.GetInt ("Score");
		scores.text = score.ToString ();

	}
	
	// Update is called once per frame
	void Update () {}
}
