using UnityEngine;
using System.Collections;

public class moveTowardsPlayer : MonoBehaviour {


	Vector3 PlayerPOS;
	float randomSpeed;

	void Start()
	{
		randomSpeed = Random.Range (0.004f, 0.007f);
	}
	
	
	// Update is called once per frame
	void FixedUpdate () {

		PlayerPOS = GameObject.FindGameObjectWithTag("player").transform.transform.position;
		transform.position = Vector3.Lerp (transform.position, PlayerPOS,randomSpeed );

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
