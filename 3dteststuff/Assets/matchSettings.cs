using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class matchSettings : NetworkBehaviour {
	//this script will load the match settings
	//and apply them to other objects
	[SyncVar]
	public int scoreToWin;

	[SyncVar]
	public string sceneToLoad;


	void Start () {
		Load ();
	}

	[Server]
	public void Load()
	{
		if (File.Exists (Application.dataPath + "/matchData.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.dataPath + "/matchData.dat", FileMode.Open);
			Infoo info = (Infoo)bf.Deserialize (file);
			file.Close ();
			scoreToWin = info.scoreToWin;
			sceneToLoad = info.levelToLoad;
			Debug.Log ("Loaded");
		}
	}


	void Update()
	{
		if (isServer && Input.GetKey (KeyCode.Return)) {
			Save ();
		}

		if (SceneManager.GetSceneByName ("LoadData").isLoaded) {
			loadScene ();
		}
	}



	public void loadScene()
	{
		SceneManager.LoadScene (sceneToLoad);
	}

	[Server]
	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.dataPath + "/Data.dat");
		Infoo inf = new Infoo ();
		bf.Serialize (file, inf);
		Debug.Log ("Saved");
		file.Close ();
	}


}

[Serializable]
public class Infoo
{
	//the score needed to end the match
	public int scoreToWin;

	//the level name to load
	public string levelToLoad;
}



