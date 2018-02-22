﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class save : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Load ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw ("Jump") > 0) {
			Save ();
		}
	}


	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/Data.dat");
		Info inf = new Info ();
		inf.x = transform.position.x;
		inf.y = transform.position.y;
		inf.z = transform.position.z;
		bf.Serialize (file, inf);
		Debug.Log ("Saved");
		file.Close ();
	}

	public void Load()
	{
		if (File.Exists (Application.persistentDataPath + "/Data.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/Data.dat", FileMode.Open);
			Info info = (Info)bf.Deserialize (file);
			file.Close ();
			Debug.Log ("Loaded");
			transform.position = new Vector3 (info.x, info.y, info.z);
		}
	}
}

[Serializable]
public class Info
{
	public float x;
	public float y;
	public float z;

}