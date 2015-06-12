using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {
	
	public Transform target;
	public float RotationSpeed;
	public float OrbitDegrees = 1f;

	// Use this for initialization
	void Start () {

		RotationSpeed = Random.Range(-100f, 100f);
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
		transform.RotateAround(target.position, Vector3.up, OrbitDegrees);
	}
}
