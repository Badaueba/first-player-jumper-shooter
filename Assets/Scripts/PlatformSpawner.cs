using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformSpawner : MonoBehaviour {

	public Transform[] platforms;
	ArrayList platformsList;
	public Vector3 spawnPosition;


	void Awake () {
		platformsList = new ArrayList ();
		for (int i = 0; i < platforms.Length; i ++) {
			platformsList.Add(platforms[i]);
		}
		while (platformsList.Count > 0) {
			Spawn ();
		}

	}
	//Spawn randomico sem repetiçoes
	void Spawn() {
		int rand = Random.Range(0, platformsList.Count);
		Transform t = (Transform) platformsList[rand];
		platformsList.RemoveAt(rand);
		Instantiate (t, spawnPosition, Quaternion.identity);
		spawnPosition = new Vector3 (0, 0, spawnPosition.z + t.localScale.z);

	}

}
