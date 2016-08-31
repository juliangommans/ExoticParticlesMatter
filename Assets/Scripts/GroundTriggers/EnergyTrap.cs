using UnityEngine;
using System.Collections;

public class EnergyTrap : MonoBehaviour {

	private Collider2D other;

	void OnTriggerEnter2D(Collider2D coll){
		if (coll != null && coll.name == "Player") {
			StartCoroutine (StopTheBall(coll));
		}
	}

	private IEnumerator StopTheBall(Collider2D other){
		yield return new WaitForSeconds(0.03f);
		other.attachedRigidbody.velocity = Vector3.zero;
		other.attachedRigidbody.angularVelocity = 0f;
		other.GetComponent<PlayerEnergy> ().energy = 0;
		other.GetComponent<PlayerEnergy> ().ableToRegen = false;
	}
}
