using UnityEngine;
using System.Collections;

public class PhysicsMove : MonoBehaviour {
	public Vector3 direction;
	public float force;
	private Rigidbody rigidBody;
	void Awake () {
		this.rigidBody = GetComponent<Rigidbody> ();
	}
	void Start () {
		rigidBody.velocity = transform.TransformDirection(direction);	
		rigidBody.AddForce( direction * force * Time.fixedDeltaTime);

	}
	

}
