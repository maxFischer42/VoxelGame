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
	public CharacterController Char;
	public Camera Cam;
	public string nama;
	public bool local;




	void Update()
	{
		//if (!isLocalPlayer)
	//	{
	//		return;
	//	}


	}

	public override void OnStartLocalPlayer()
	{
		Debug.Log ("it worked?");
		local = true;
		gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
		GetComponentInChildren<RayViewerComplete> ().enabled = true;
		GetComponentInChildren<RayCastShootComplete> ().enabled = true;
		GetComponentInChildren<Camera> ().enabled = true;
		gameObject.GetComponent<FirstPersonController> ().enabled = true;
		gameObject.GetComponent<CharacterController> ().enabled = true;
		gameObject.GetComponent<MouseLook> ().enabled = true;
	}

}
