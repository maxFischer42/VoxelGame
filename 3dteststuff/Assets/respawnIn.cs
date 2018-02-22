using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class respawnIn : MonoBehaviour {

	public float timeUntil;
	float timer = 0;
	public spawn spn;
	public FirstPersonController Gam;

	// Use this for initialization
	void Start () {
		Gam.enabled =  false;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timeUntil)
		{
			Gam.enabled = true;
			spn.Act ();
		}
	}
}
