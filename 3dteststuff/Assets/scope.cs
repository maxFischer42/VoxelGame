using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scope : MonoBehaviour {

	public Camera MainCamera;
	public GameObject Scope;
	public 
	float defsize;
	float defsens;
	public float camSize = 10;

	// Use this for initialization
	void Start () {
		defsize = MainCamera.fieldOfView;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (1)) {
			Scope.SetActive (true);
			MainCamera.fieldOfView = camSize;
		} else {
			Scope.SetActive (false);
			MainCamera.fieldOfView = defsize;
		}
	}
}
