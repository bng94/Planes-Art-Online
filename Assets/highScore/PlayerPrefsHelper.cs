using UnityEngine;
using System.Collections;

public static class PlayerPrefsHelper {

	public static void incrementScore(int pts){
		PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") + pts);
		PlayerPrefs.Save ();
	}

	public static void decreaseScore(int pts){
		PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") - pts);
		PlayerPrefs.Save ();
	}

	public static string getPlayerName(){
		return PlayerPrefs.GetString ("playerName");
	}
		
	public static int getPlayerScore(){
		return PlayerPrefs.GetInt ("Score");
	}
}
