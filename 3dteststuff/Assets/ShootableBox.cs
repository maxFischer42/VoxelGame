using UnityEngine;
using System.Collections;

public class ShootableBox : MonoBehaviour {

	//The box's current health point total
	public int currentHealth = 3;
	public GameObject[] particles;
	public bool barrel;

	public void Damage(int damageAmount)
	{
		//subtract damage amount when Damage function is called
		currentHealth -= damageAmount;

		//Check if health has fallen below zero
		if (currentHealth <= 0) 
		{
			if (barrel) {
				Destroy (gameObject, 1f);
				for (int i = 0; i < particles.Length; i++) {
					particles [i].SetActive (true);
					particles [i].GetComponent<ParticleSystem> ().Stop ();
					particles [i].GetComponent<ParticleSystem> ().Play ();
				}
			} else {
				//if health has fallen below zero, deactivate it 
				gameObject.SetActive (false);
			}
		}
	}
}
