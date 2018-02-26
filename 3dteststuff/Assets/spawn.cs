using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Types;
using UnityEngine.Networking.Match;
using UnityEngine.Networking.PlayerConnection;
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
		if (!isLocalPlayer) {
			GetComponentInChildren<Camera> ().enabled = false;
			return;
		}
		if (local) {

			GetComponentInChildren<RayViewerComplete> ().enabled = true;
			GetComponentInChildren<RayCastShootComplete> ().enabled = true;
	GetComponentInChildren<Camera> ().enabled = true;
			GetComponent<FirstPersonController> ().enabled = true;
		GetComponent<CharacterController> ().enabled = true;
			GetComponent<MouseLook> ().enabled = true;

		}
	}








	public override void OnStartLocalPlayer()
	{
		
		//gameObject.name = PlayerPrefs.GetString ("Name");
		Debug.Log ("it worked?");
		local = true;
		//GameObject.Find ("LoadCamera").SetActive (false);


	}

}
