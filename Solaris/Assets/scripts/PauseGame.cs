using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void pauseGame() {
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
		}
		else {
			Time.timeScale = 1;		
		}
	}
}
