using UnityEngine;
using System.Collections;

public class EnergyTrap : FreezeOnEnter {

	public override void ObjectSpecificAction (Collider2D other){
		other.GetComponent<PlayerEnergy> ().energy = 0;
		other.GetComponent<PlayerEnergy> ().ableToRegen = false;
	}
}
