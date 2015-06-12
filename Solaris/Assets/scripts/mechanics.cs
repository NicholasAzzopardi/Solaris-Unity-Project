using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mechanics : MonoBehaviour {
	
	public static int score;
	public static int health;
	public GameObject scoregm;
	public GameObject timer;
	public Slider slider;
	float minutes = 0;
	float seconds = 60;
	float miliseconds = 0;
	public AudioClip backMusic;
	public AudioClip tick;
	AudioSource[] sounds;
	AudioSource fxSound;
	AudioSource clock;
	bool play = true;

	void Start () {
		score = 0;
		health = 100; 
		sounds = GetComponents<AudioSource>();
		fxSound = sounds[0];
		clock = sounds[1];
		fxSound.Play ();
		play = true;
	}
	
	// Update is called once per frame
	void Update () {
		Text text = scoregm.GetComponent<Text>();
		text.text = "Score: " + score;
		slider.value = health;

		if (health == 0)
		{
			Application.LoadLevel(2);
		}

		if (miliseconds <= 0) {
			if (seconds <= 0) {
				minutes--;
				seconds = 59;
			} 
			else if (seconds >= 0) {
				seconds--;
			}
			miliseconds = 100;
		} 
		else if (seconds == 10) {
			if(play = true)
			{
				clock.Play ();
			}
			else if(play = false)
			{
				clock.Pause();
			}
		} 
		else if (seconds == 0) {
			clock.Stop ();
			StartCoroutine (loadLevel (0.5f));
		} 
		
		miliseconds -= Time.deltaTime * 100;
		
		//Debug.Log(string.Format("{0}:{1}:{2}", minutes, seconds, (int)miliseconds));


		Text time2 = timer.GetComponent<Text>();
		time2.text = string.Format("Time: {0}:{1}:{2}", minutes, seconds, (int)miliseconds);
		//time2.text = "Time: " + timeLeft + "s";
		//timestring.Format("Time: {0}:{1}:{2}", minutes, seconds, (int)miliseconds);
	}

	IEnumerator loadLevel(float delay)
	{
		yield return new WaitForSeconds(delay);
		Application.LoadLevel(2);
	}

	public void pauseGame() {
		if (Time.timeScale == 1 ) {
			Time.timeScale = 0;
			play = false;
		}
		else if (Time.timeScale == 0) {
			Time.timeScale = 1;	
			play = true;
		}
	}

}
