using UnityEngine;
using System.Collections;

public class EnergyTrap : MonoBehaviour {

	private Collider2D other;

	void OnTriggerEnter2D(Collider2D coll){
		if (coll != null && coll.name == "Player") {
			other = coll;
			StartCoroutine ("StopTheBall");
		}
	}

	private IEnumerator StopTheBall(){
		other.attachedRigidbody.velocity = Vector3.zero;
		other.attachedRigidbody.angularVelocity = 0f;
		other.GetComponent<PlayerEnergy> ().energy = 0;
		yield return new WaitForSeconds(.1f);
	}
}
