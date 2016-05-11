using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour {
	
	public Transform reference;
	private Transform[] plataforms;
	Transform t;
	void Start() {
		plataforms = GameObject.FindObjectOfType<PlatformSpawner> ().platforms;
		reference = Transform.FindObjectOfType<PlayerControl> ().transform;
		t = this.GetComponent<Transform> ();
		StartCoroutine (Change ());
	}

	IEnumerator Change() {
		while (true) {
			float zPosition = t.position.z + t.localScale.z/2;
			if ( zPosition < reference.position.z)  {
				Vector3 pos = new Vector3 (0, 0, t.position.z + (plataforms.Length * t.localScale.z));
				int rand = Random.Range(0, plataforms.Length);
				Instantiate(plataforms[rand], pos, Quaternion.identity);
				Destroy(this.gameObject);
			}
			yield return new WaitForEndOfFrame();
		}
	}

}
