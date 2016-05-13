using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformSpawner : MonoBehaviour {

	LevelManager levelManager;
	Dictionary <int, Transform[]> platformLevels;
	public Transform[] platforms01;
	public Transform[] platforms02;
	public Transform[] platforms03;
	ArrayList platformsList;
	public Vector3 spawnPosition;
	public Transform[] currentPlatforms;

	void Awake () {
		//level manager
		levelManager = GameObject.FindObjectOfType<LevelManager> ();

		//dictionario contendo todos as plataformas de acordo com os levels
		platformLevels = new Dictionary<int, Transform[] > ();
		platformLevels.Add (0, platforms01);
		platformLevels.Add (1, platforms02);
		platformLevels.Add (2, platforms03);

		//lista para criar o  primeiro spawn sem repetiçao
		platformsList = new ArrayList ();
		currentPlatforms = GetCurrentPlatforms();
		for (int i = 0; i < currentPlatforms.Length ; i ++) {
			platformsList.Add(currentPlatforms[i]);
		}
		while (platformsList.Count > 0) {
			Spawn ();
		}

	}
	//retorna as plataformas de acordo com o level do jogo
	public Transform[] GetCurrentPlatforms () {
		return platformLevels [levelManager.level];
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
