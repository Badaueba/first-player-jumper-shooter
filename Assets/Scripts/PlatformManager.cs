using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour {
	
	public Transform reference;
	public Transform[] plataforms;
	Transform t;
	void Start() {
		reference = Transform.FindObjectOfType<PlayerControl> ().transform;
		t = this.GetComponent<Transform> ();

		StartCoroutine (Change ());
	}

	IEnumerator Change() {
		while (true) {
			float zPosition = t.position.z + t.localScale.z/2;
			if ( zPosition < reference.position.z)  {
				transform.position = new Vector3 (0, 0, t.position.z + (4 *t.localScale.z));
			}
			yield return new WaitForEndOfFrame();
		}
	}

}
