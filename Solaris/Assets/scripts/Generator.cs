using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {
	
	public GameObject[] enemies = new GameObject[10];
	public GameObject sun;
	public GameObject meteor;
	public GameObject heart;
	// Use this for initialization
	void Start () {
		foreach (GameObject e in enemies) {
			Instantiate (e, new Vector3 (Random.Range (-80f, 80f), 1f, Random.Range (-80f, 80f)), Quaternion.identity);
			Instantiate (sun, new Vector3 (Random.Range (-80f, 80f), 1f, Random.Range (-80f, 80f)), Quaternion.identity);
		}

		for (int i = 0; i <= 100; i++) {

			Instantiate (meteor, new Vector3 (Random.Range (-200f, 200f), 1f, Random.Range (-200f, 200f)), Quaternion.identity);
		}

		for (int i = 0; i <= 2; i++) {
			
			Instantiate (heart, new Vector3 (Random.Range (-80f, 80f), 1f, Random.Range (-80f, 80f)), Quaternion.identity);
		}


	}
		
	// Update is called once per frame
	void Update () {



	}
}
