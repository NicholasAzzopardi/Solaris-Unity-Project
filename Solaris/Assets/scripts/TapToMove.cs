using UnityEngine;
using System.Collections;

public class TapToMove : MonoBehaviour {

	//flag to check if the user has tapped / clicked. 
	//Set to true on click. Reset to false on reaching destination
	private bool flag = false;
	//destination point
	private Vector3 endPoint;
	//alter this to change the speed of the movement of player / gameobject
	public float duration = 50.0f;
	//vertical position of the gameobject
	private float yAxis;
	public AudioClip meteorss;
	public AudioClip suncrunchh;
	public AudioClip crunchh;
	AudioSource[] sounds;
	AudioSource meteors;
	AudioSource crunch;
	AudioSource bigcrunch;

	void Start(){
		//save the y axis value of gameobject
		yAxis = gameObject.transform.position.y;
		sounds = GetComponents<AudioSource>();
		crunch = sounds[0];
		meteors = sounds[1];
		bigcrunch = sounds[2];
	}

	void Update() {
		transform.Rotate(Vector3.one * 10 * Time.deltaTime);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		//check if the screen is touched / clicked   
		if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown(0)))
		{
			//declare a variable of RaycastHit struct
			RaycastHit hit;
			//Create a Ray on the tapped / clicked position
			Ray ray;
			//for unity editor


			//#if UNITY_EDITOR
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//for touch device
			//#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
			//ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			//#endif
			if(Physics.Raycast(ray,out hit))
			{
				//set a flag to indicate to move the gameobject
				flag = true;
				//save the click / tap position
				endPoint = hit.point;
				//as we do not want to change the y axis value based on touch position, reset it to original y axis value
				endPoint.y = yAxis;
				Debug.Log(endPoint);
			}
			
		}
		//check if the flag for movement is true and the current gameobject position is not same as the clicked / tapped position
		if(flag && !Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude)){ //&& !(V3Equal(transform.position, endPoint))){
			//move the gameobject to the desired position
			gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPoint, 1/(duration));
		}
		//set the movement indicator flag to false if the endPoint and current gameobject position are equal
		else if(flag && Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude)) {
			flag = false;
			Debug.Log("I am here");
		}
		
	}


	void OnCollisionEnter(Collision hit)
	{
		if (hit.collider.gameObject.tag == "otherCube") {

			hit.collider.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*100000f,ForceMode.Force);
		}
		if (hit.gameObject.tag == "meteor") {
			mechanics.health = mechanics.health - 20;
			meteors.Play ();
		}
		else if (hit.gameObject.tag == "othercube") {
			mechanics.score = mechanics.score + 30;	
			Destroy(hit.gameObject);
			transform.localScale += new Vector3(1F, 1F, 1F);
			crunch.Play ();
		}
		else if (hit.gameObject.tag == "star") {

			if (gameObject.activeSelf) {
				// Disable the other gameObject we've collided with, then flag to destroy it
				hit.gameObject.SetActive(false);
				Destroy(hit.gameObject);
				mechanics.score = mechanics.score + 50;
				transform.localScale += new Vector3(2F, 2F, 2F);
				bigcrunch.Play ();
			}
		}
		else if (hit.gameObject.tag == "heart") {
			
			if (gameObject.activeSelf) {
				// Disable the other gameObject we've collided with, then flag to destroy it
				hit.gameObject.SetActive(false);
				Destroy(hit.gameObject);
				crunch.Play ();
				if(mechanics.health <= 80)
				{
					mechanics.health = mechanics.health + 20;
				}
				else if(mechanics.health == 90)
				{
					mechanics.health = mechanics.health + 10;
				}
				else 
				{
					mechanics.health = mechanics.health + 0;
				}
			}
		}
	}


}
