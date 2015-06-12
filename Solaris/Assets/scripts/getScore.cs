using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class getScore : MonoBehaviour {

	// Use this for initialization
	AudioSource sound; // Emitir sons
	public AudioClip backMusic; // Som de fundo
	public GameObject scoregm;

	void Start () {
		Text text = scoregm.GetComponent<Text>();
		text.text = "Score: " + mechanics.score;
		sound = GetComponent<AudioSource> ();
		sound.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
