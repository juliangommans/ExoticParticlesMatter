using UnityEngine;
using System.Collections;

public class Bomb : PowerupBase {

	void Awake () {
		value = -2;
		powerupName = "BOMB";
	}

	public override void PowerupAction(GameObject player){
		player.GetComponent<PlayerEnergy> ().ChangeEnergy(value, "Damage");
	}
}
