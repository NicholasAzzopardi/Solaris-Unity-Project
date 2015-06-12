using UnityEngine;
using System.Collections;

public class CameraFollowup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void Update() {
		
		int DistanceAway = 10;
		Vector3 PlayerPOS = GameObject.FindGameObjectWithTag("player").transform.transform.position;
		GameObject.FindGameObjectWithTag("MainCamera").transform.position = new Vector3(PlayerPOS.x, PlayerPOS.y + DistanceAway, PlayerPOS.z);
		
	}
}
