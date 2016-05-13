using UnityEngine;
using System.Collections;


public class Shoot : MonoBehaviour {
	public Rigidbody projectile;
	public Vector3 direction;
	public float force;

	void FixedUpdate () {
		if (Input.GetButtonDown ("Fire1"))
			InstantiateProjectile ();			
	}

	void InstantiateProjectile() {
		Vector3 pos = new Vector3 
			(this.transform.position.x, this.transform.position.y, this.transform.position.z + 5);
		Rigidbody newProjectile = (Rigidbody) 
			Instantiate(projectile, pos, projectile.transform.rotation);
		newProjectile.AddForce( direction * force * Time.fixedDeltaTime);
		Physics.IgnoreCollision (newProjectile.GetComponent<Collider>(), this.GetComponent<Collider> (), true);
	}
}
