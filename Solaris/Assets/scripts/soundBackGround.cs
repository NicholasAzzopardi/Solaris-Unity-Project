using UnityEngine;
using System.Collections;

public class soundBackGround : MonoBehaviour {

	// Use this for initialization
	AudioSource sound; // Emitir sons
	public AudioClip backMusic; // Som de fundo

	void Start () {
		sound = GetComponent<AudioSource> ();
		sound.Play ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
