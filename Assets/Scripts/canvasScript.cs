using UnityEngine;
using System.Collections;

public class canvasScript : MonoBehaviour {

	public Canvas theCanvas;

	// Use this for initialization
	void Start () {
		theCanvas.enabled = false;
	}
	// Update is called once per frame
	//void Update () {}

	//opens canvas
	public void openCanvas(){
		theCanvas.enabled = true;
	}
	//closes canvas
	public void closeCanvas(){
		theCanvas.enabled = false;
	}
}
