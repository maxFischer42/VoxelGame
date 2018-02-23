using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityStandardAssets.Characters.FirstPerson;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class spawn :NetworkBehaviour {

	public Vector3 Spawn;
	public FirstPersonController gam;
	public Camera Cam;
	public string nama;
	public bool local;

	// Use this for initialization
	public void Act()
	{
		//if (isLocalPlayer) {
		//	
	//		gam.enabled = true;
	//		Cam.enabled = true;
	//		return;
	//	}
	//	gam.enabled = false;
	//	Cam.enabled = false;

	}

	void Update()
	{
		if (!isLocalPlayer)
		{
			return;
		}

	//	var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
	//	var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

//		transform.Rotate(0, x, 0);
	//	transform.Translate(0, 0, z);
	}

	public override void OnStartLocalPlayer()
	{
		Debug.Log ("it worked?");
		local = true;
		gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
	}
		//if (isLocalPlayer) {
			//transform.position = Spawn;

	/*	public override void OnStartClient()
		//{
	//	Debug.Log ("something");
	//	ClientScene.RegisterPrefab (Cam);
//	}

	 /*	[Server]
		public void ServerSpawnPlant(Vector3 pos, Quaternion rot)
		{
		var plant = (GameObject)Instantiate(Cam, pos, rot);
		plant.name = name;
		NetworkServer.Spawn(plant);
		plant.GetComponent<CharacterController> ().enabled = true;
			
		}


	/*public void Load()
	{
		if (File.Exists (Application.dataPath + "/Info.txt")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.dataPath + "/Info.txt", FileMode.Open);
			Info info = (Info)bf.Deserialize (file);
			name = info.name;
			file.Close ();
			Debug.Log ("Loaded");
		}
	}*/

}

[Serializable]
public class Info
{
	public string name;

}