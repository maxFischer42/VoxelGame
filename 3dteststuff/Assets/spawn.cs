using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;

public class spawn :NetworkBehaviour {

	public Vector3 Spawn;
	public FirstPersonController gam;

	// Use this for initialization
	public void Act () {
		
		if (isLocalPlayer) {
			//transform.position = Spawn;
			return;
		}
		gam.enabled = false;

	}

}
