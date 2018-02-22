using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class spawn :NetworkBehaviour {

	public Vector3 Spawn;
	public GameObject gam;

	// Use this for initialization
	void Start () {
		
		if (isLocalPlayer) {
			//transform.position = Spawn;
			return;
		}
		gam.SetActive (false);

	}

}
