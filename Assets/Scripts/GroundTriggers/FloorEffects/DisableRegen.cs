using UnityEngine;
using System.Collections;

public class DisableRegen : FloorTriggers {

	void Awake(){
		ColorTheFloor (Color.red);
	}

	public override void EnableEffect (Collider2D other){
		other.GetComponent<PlayerEnergy> ().ableToRegen = false;
	}

	public override void DisableEffect (Collider2D other){
		other.GetComponent<PlayerEnergy> ().ableToRegen = true;
	}
}
