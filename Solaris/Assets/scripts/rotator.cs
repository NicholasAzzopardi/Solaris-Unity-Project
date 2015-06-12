using UnityEngine;
using System.Collections;

public class rotator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.one * 10 * Time.deltaTime);	
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
