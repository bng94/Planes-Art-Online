using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class preGameSetUp : MonoBehaviour {

	public Text text;
	private string temp;

	// Use this for initialization
	void Start () {
		text = GameObject.Find ("playerText").GetComponent <Text> ();
		PlayerPrefs.SetString ("playerName", "Doctor Who?");
		PlayerPrefs.SetInt ("Score", 0);
		PlayerPrefs.Save ();
	}

	//set name when user pressed enter
	public void setEnteredName(){
		temp = text.text.ToString ();
		PlayerPrefs.SetString ("playerName", temp);
		PlayerPrefs.Save ();
	}
}
