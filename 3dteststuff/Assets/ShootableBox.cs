using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ShootableBox : NetworkBehaviour {

	//The box's current health point total
	[SyncVar]
	public int currentHealth = 3;
	public GameObject[] particles;
	public bool barrel;
	public bool player;

	[SyncVar]
	public bool hit;







	private NetworkStartPosition[] spawnPoints;

	void Start ()
	{
		//RpcRespawn ();
		if (isLocalPlayer)
		{
			spawnPoints = FindObjectsOfType<NetworkStartPosition>();
		}
	}


	public void Update()	
	{
		if (hit) {
			RpcRespawn ();
		}
	}


	[ClientRpc]
	public void RpcDamage(int damageAmount)
	{
		//subtract damage amount when Damage function is called
		currentHealth -= damageAmount;

		//Check if health has fallen below zero
		if (currentHealth <= 0 || hit) 
		{
			if (barrel) {
				Destroy (gameObject, 1f);
				for (int i = 0; i < particles.Length; i++) {
					particles [i].SetActive (true);
					particles [i].GetComponent<ParticleSystem> ().Stop ();
					particles [i].GetComponent<ParticleSystem> ().Play ();
				}

			} else if (player) {
				RpcRespawn ();
			}

			else {
				//if health has fallen below zero, deactivate it 
				gameObject.SetActive (false);
			}
		}
	}


	[ClientRpc]
	void RpcRespawn()
	{
		//if (isLocalPlayer)
	//	{
			// Set the spawn point to origin as a default value
			Vector3 spawnPoint = Vector3.zero;

			// If there is a spawn point array and the array is not empty, pick one at random
			if (spawnPoints != null && spawnPoints.Length > 0)
			{
				spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
			}

			// Set the player’s position to the chosen spawn point
			transform.position = spawnPoint;
			hit = false;
	//	}
	}
}
