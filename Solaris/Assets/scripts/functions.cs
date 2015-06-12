using UnityEngine;
using System.Collections;

public class functions : MonoBehaviour {
	
	AudioSource sound;
	public AudioClip click;

	void Start () {
		sound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void returnToMenu() 
	{
		sound.Play ();
		Application.LoadLevel (0);
	}
	public void playGame() 
	{
		sound.Play ();
		Application.LoadLevel (1);
	}
	public void exitGame() 
	{
		sound.Play ();
		Application.Quit ();
	}
}
