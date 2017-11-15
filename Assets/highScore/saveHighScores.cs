using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class saveHighScores : MonoBehaviour {

	float timeLeft = 11.0f;
	int time;
	public Text text;

	public void Start (){
		if (text == null) {
			text = GameObject.Find ("savingText").GetComponent<Text> ();
		}
		if (PlayerPrefs.GetInt ("S1") == 0 && PlayerPrefs.GetInt ("S2") == 0 && PlayerPrefs.GetInt ("S3") == 0 && PlayerPrefs.GetInt ("S4") == 0 && PlayerPrefs.GetInt ("S5") == 0) {
			PlayerPrefs.SetInt ("S1", PlayerPrefs.GetInt("Score"));
			PlayerPrefs.SetString ("P1", PlayerPrefs.GetString ("playerName"));
		} else if (PlayerPrefs.GetInt ("S1") != 0 && PlayerPrefs.GetInt ("S2") == 0 && PlayerPrefs.GetInt ("S3") == 0 && PlayerPrefs.GetInt ("S4") == 0 && PlayerPrefs.GetInt ("S5") == 0) {
			if (PlayerPrefs.GetInt ("S1") >= PlayerPrefs.GetInt ("Score")) {
				PlayerPrefs.SetInt ("S2", PlayerPrefs.GetInt ("Score"));
				PlayerPrefs.SetString ("P2", PlayerPrefs.GetString ("playerName"));
			} else if(PlayerPrefs.GetInt ("S1") < PlayerPrefs.GetInt ("Score")){
				PlayerPrefs.SetInt ("S2", PlayerPrefs.GetInt ("S1"));
				PlayerPrefs.SetString ("P2", PlayerPrefs.GetString ("P1"));			
				PlayerPrefs.SetInt ("S1", PlayerPrefs.GetInt ("Score"));
				PlayerPrefs.SetString ("P1", PlayerPrefs.GetString ("playerName"));
			}
		} else if (PlayerPrefs.GetInt ("S1") != 0 && PlayerPrefs.GetInt ("S2") != 0 && PlayerPrefs.GetInt ("S3") == 0 && PlayerPrefs.GetInt ("S4") == 0 && PlayerPrefs.GetInt ("S5") == 0) {
			if (PlayerPrefs.GetInt ("S2") >= PlayerPrefs.GetInt ("Score")) {
				PlayerPrefs.SetInt ("S3", PlayerPrefs.GetInt ("Score"));
				PlayerPrefs.SetString ("P3", PlayerPrefs.GetString ("playerName"));
			} else if (PlayerPrefs.GetInt ("S1") >= PlayerPrefs.GetInt ("Score") && PlayerPrefs.GetInt ("S2") < PlayerPrefs.GetInt ("Score")) {
				PlayerPrefs.SetInt ("S3", PlayerPrefs.GetInt ("S2"));
				PlayerPrefs.SetString ("P3", PlayerPrefs.GetString ("P2"));		
				PlayerPrefs.SetInt ("S2", PlayerPrefs.GetInt ("Score"));
				PlayerPrefs.SetString ("P2", PlayerPrefs.GetString ("playerName"));	
			} else if (PlayerPrefs.GetInt ("S1") < PlayerPrefs.GetInt ("Score")) {
				PlayerPrefs.SetInt ("S3", PlayerPrefs.GetInt ("S2"));
				PlayerPrefs.SetString ("P3", PlayerPrefs.GetString ("P2"));		
				PlayerPrefs.SetInt ("S2", PlayerPrefs.GetInt ("S1"));
				PlayerPrefs.SetString ("P2", PlayerPrefs.GetString ("P1"));	
				PlayerPrefs.SetInt ("S1", PlayerPrefs.GetInt ("Score"));
				PlayerPrefs.SetString ("P1", PlayerPrefs.GetString ("playerName"));
			}
		} else if (PlayerPrefs.GetInt ("S1") != 0 && PlayerPrefs.GetInt ("S2") != 0 && PlayerPrefs.GetInt ("S3") != 0 && PlayerPrefs.GetInt ("S4") == 0 && PlayerPrefs.GetInt ("S5") == 0) {
			if (PlayerPrefs.GetInt ("S3") >= PlayerPrefs.GetInt ("Score")) {
				PlayerPrefs.SetInt ("S4", PlayerPrefs.GetInt ("Score"));
				PlayerPrefs.SetString ("P4", PlayerPrefs.GetString ("playerName"));
			} else if (PlayerPrefs.GetInt ("S2") >= PlayerPrefs.GetInt ("Score") && PlayerPrefs.GetInt ("S3") < PlayerPrefs.GetInt ("Score")) {
				PlayerPrefs.SetInt ("S4", PlayerPrefs.GetInt ("S3"));
				PlayerPrefs.SetString ("P4", PlayerPrefs.GetString ("P3"));		
				PlayerPrefs.SetInt ("S3", PlayerPrefs.GetInt ("Score"));
				PlayerPrefs.SetString ("P3", PlayerPrefs.GetString ("playerName"));
			} else if (PlayerPrefs.GetInt ("S1") >= PlayerPrefs.GetInt ("Score") && PlayerPrefs.GetInt ("S2") < PlayerPrefs.GetInt ("Score")) {
				PlayerPrefs.SetInt ("S4", PlayerPrefs.GetInt ("S3"));
				PlayerPrefs.SetString ("P4", PlayerPrefs.GetString ("P3"));	
				PlayerPrefs.SetInt ("S3", PlayerPrefs.GetInt ("S2"));
				PlayerPrefs.SetString ("P3", PlayerPrefs.GetString ("P2"));		
				PlayerPrefs.SetInt ("S2", PlayerPrefs.GetInt ("Score"));
				PlayerPrefs.SetString ("P2", PlayerPrefs.GetString ("playerName"));
			} else if (PlayerPrefs.GetInt ("S1") < PlayerPrefs.GetInt ("Score")) {
				PlayerPrefs.SetInt ("S4", PlayerPrefs.GetInt ("S3"));
				PlayerPrefs.SetString ("P4", PlayerPrefs.GetString ("P3"));
				PlayerPrefs.SetInt ("S3", PlayerPrefs.GetInt ("S2"));
				PlayerPrefs.SetString ("P3", PlayerPrefs.GetString ("P2"));
				PlayerPrefs.SetInt ("S2", PlayerPrefs.GetInt ("S1"));
				PlayerPrefs.SetString ("P2", PlayerPrefs.GetString ("P1"));			
				PlayerPrefs.SetInt ("S1", PlayerPrefs.GetInt ("Score"));
				PlayerPrefs.SetString ("P1", PlayerPrefs.GetString ("playerName"));
			}
		} else if (PlayerPrefs.GetInt ("S1") != 0 && PlayerPrefs.GetInt ("S2") != 0 && PlayerPrefs.GetInt ("S3") != 0 && PlayerPrefs.GetInt ("S4") != 0 && PlayerPrefs.GetInt ("S5") == 0) {
			if (PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("S1")) {
				PlayerPrefs.SetInt ("S5", PlayerPrefs.GetInt ("S4"));
				PlayerPrefs.SetString ("P5", PlayerPrefs.GetString ("P4"));
				PlayerPrefs.SetInt ("S4", PlayerPrefs.GetInt ("S3"));
				PlayerPrefs.SetString ("P4", PlayerPrefs.GetString ("P3"));
				PlayerPrefs.SetInt ("S3", PlayerPrefs.GetInt ("S2"));
				PlayerPrefs.SetString ("P3", PlayerPrefs.GetString ("P2"));
				PlayerPrefs.SetInt ("S2", PlayerPrefs.GetInt ("S1"));
				PlayerPrefs.SetString ("P2", PlayerPrefs.GetString ("P1"));			
				PlayerPrefs.SetInt ("S1", PlayerPrefs.GetInt ("Score"));
				PlayerPrefs.SetString ("P1", PlayerPrefs.GetString ("playerName"));
			} else if (PlayerPrefs.GetInt ("Score") <= PlayerPrefs.GetInt ("S1") && PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("S2")) {
				PlayerPrefs.SetInt ("S5", PlayerPrefs.GetInt ("S4"));
				PlayerPrefs.SetString ("P5", PlayerPrefs.GetString ("P4"));
				PlayerPrefs.SetInt ("S4", PlayerPrefs.GetInt ("S3"));
				PlayerPrefs.SetString ("P4", PlayerPrefs.GetString ("P3"));
				PlayerPrefs.SetInt ("S3", PlayerPrefs.GetInt ("S2"));
				PlayerPrefs.SetString ("P3", PlayerPrefs.GetString ("P2"));
				PlayerPrefs.SetInt ("S2", PlayerPrefs.GetInt ("Score"));
				PlayerPrefs.SetString ("P2", PlayerPrefs.GetString ("playerName"));
			} else if (PlayerPrefs.GetInt ("Score") <= PlayerPrefs.GetInt ("S2") && PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("S3")) {
				PlayerPrefs.SetInt ("S5", PlayerPrefs.GetInt ("S4"));
				PlayerPrefs.SetString ("P5", PlayerPrefs.GetString ("P4"));
				PlayerPrefs.SetInt ("S4", PlayerPrefs.GetInt ("S3"));
				PlayerPrefs.SetString ("P4", PlayerPrefs.GetString ("P3"));
				PlayerPrefs.SetInt ("S3", PlayerPrefs.GetInt ("Score"));
				PlayerPrefs.SetString ("P3", PlayerPrefs.GetString ("playerName"));
			} else if (PlayerPrefs.GetInt ("Score") <= PlayerPrefs.GetInt ("S3") && PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("S4")) {
				PlayerPrefs.SetInt ("S5", PlayerPrefs.GetInt ("S4"));
				PlayerPrefs.SetString ("P5", PlayerPrefs.GetString ("P4"));
				PlayerPrefs.SetInt ("S4", PlayerPrefs.GetInt ("Score"));
				PlayerPrefs.SetString ("P4", PlayerPrefs.GetString ("playerName"));
			} else if (PlayerPrefs.GetInt ("Score") <= PlayerPrefs.GetInt ("S4") && PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("S5")) {
				PlayerPrefs.SetInt ("S5", PlayerPrefs.GetInt ("Score"));
				PlayerPrefs.SetString ("P5", PlayerPrefs.GetString ("playerName"));
			}
		} else if (PlayerPrefs.GetInt ("S1") != 0 && PlayerPrefs.GetInt ("S2") != 0 && PlayerPrefs.GetInt ("S3") != 0 && PlayerPrefs.GetInt ("S4") != 0 &&PlayerPrefs.GetInt ("S5") != 0 ) {
			if (PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("S1")) {
				PlayerPrefs.SetInt ("S5", PlayerPrefs.GetInt ("S4"));
				PlayerPrefs.SetString ("P5", PlayerPrefs.GetString ("P4"));
				PlayerPrefs.SetInt ("S4", PlayerPrefs.GetInt ("S3"));
				PlayerPrefs.SetString ("P4", PlayerPrefs.GetString ("P3"));
				PlayerPrefs.SetInt ("S3", PlayerPrefs.GetInt ("S2"));
				PlayerPrefs.SetString ("P3", PlayerPrefs.GetString ("P2"));
				PlayerPrefs.SetInt ("S2", PlayerPrefs.GetInt ("S1"));
				PlayerPrefs.SetString ("P2", PlayerPrefs.GetString ("P1"));			
				PlayerPrefs.SetInt ("S1", PlayerPrefs.GetInt ("Score"));
				PlayerPrefs.SetString ("P1", PlayerPrefs.GetString ("playerName"));
			} else if (PlayerPrefs.GetInt ("Score") <= PlayerPrefs.GetInt ("S1") && PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("S2")) {
				PlayerPrefs.SetInt ("S5", PlayerPrefs.GetInt ("S4"));
				PlayerPrefs.SetString ("P5", PlayerPrefs.GetString ("P4"));
				PlayerPrefs.SetInt ("S4", PlayerPrefs.GetInt ("S3"));
				PlayerPrefs.SetString ("P4", PlayerPrefs.GetString ("P3"));
				PlayerPrefs.SetInt ("S3", PlayerPrefs.GetInt ("S2"));
				PlayerPrefs.SetString ("P3", PlayerPrefs.GetString ("P2"));
				PlayerPrefs.SetInt ("S2", PlayerPrefs.GetInt ("Score"));
				PlayerPrefs.SetString ("P2", PlayerPrefs.GetString ("playerName"));
			} else if (PlayerPrefs.GetInt ("Score") <= PlayerPrefs.GetInt ("S2") && PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("S3")) {
				PlayerPrefs.SetInt ("S5", PlayerPrefs.GetInt ("S4"));
				PlayerPrefs.SetString ("P5", PlayerPrefs.GetString ("P4"));
				PlayerPrefs.SetInt ("S4", PlayerPrefs.GetInt ("S3"));
				PlayerPrefs.SetString ("P4", PlayerPrefs.GetString ("P3"));
				PlayerPrefs.SetInt ("S3", PlayerPrefs.GetInt ("Score"));
				PlayerPrefs.SetString ("P3", PlayerPrefs.GetString ("playerName"));
			} else if (PlayerPrefs.GetInt ("Score") <= PlayerPrefs.GetInt ("S3") && PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("S4")) {
				PlayerPrefs.SetInt ("S5", PlayerPrefs.GetInt ("S4"));
				PlayerPrefs.SetString ("P5", PlayerPrefs.GetString ("P4"));
				PlayerPrefs.SetInt ("S4", PlayerPrefs.GetInt ("Score"));
				PlayerPrefs.SetString ("P4", PlayerPrefs.GetString ("playerName"));
			} else if (PlayerPrefs.GetInt ("Score") <= PlayerPrefs.GetInt ("S4") && PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("S5")) {
				PlayerPrefs.SetInt ("S5", PlayerPrefs.GetInt ("Score"));
				PlayerPrefs.SetString ("P5", PlayerPrefs.GetString ("playerName"));
			}
		} 
	}

	void Update () {
		if (timeLeft >= 1) {
			timeLeft -= Time.deltaTime;
			time = Mathf.FloorToInt (timeLeft);
			text.text = "Saving..." + time;
		}else{
			SceneManager.LoadScene ("menu");
		}
	}
}
