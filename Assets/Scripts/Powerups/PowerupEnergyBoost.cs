using UnityEngine;
using System.Collections;

public class PowerupEnergyBoost : PowerupBase {
	
	// Use this for initialization
	void Awake () {
		value = 1;
		powerupName = "Energy Boost";
	}
	
	public override void PowerupAction(GameObject player){
		player.GetComponent<PlayerEnergy> ().ChangeEnergy(value);
	}
}
