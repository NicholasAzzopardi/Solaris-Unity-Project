using UnityEngine;
using System.Collections;

public class follower : MonoBehaviour {

	// Use this for initialization
	public float interpVelocity;
	public float minDistance;
	public float followDistance;
	public GameObject target;
	public Vector3 offset;
	Vector3 targetPos;
	// Use this for initialization
	void Start () {
		//targetPos = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (target)
		{
			Vector3 posNoY = transform.position;
			posNoY.y = target.transform.position.y;

		//	Debug.Log (posNoY);

			Vector3 targetDirection = (target.transform.position - posNoY);
			
			interpVelocity = targetDirection.magnitude * 5f;
			
			targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime); 

			Debug.Log (targetPos+offset);

			transform.position = Vector3.Lerp( transform.position, new Vector3(targetPos.x,offset.y,targetPos.z), 0.25f);
			
		}
	}

}
