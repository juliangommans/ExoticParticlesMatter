using UnityEngine;
using System.Collections;

public class BlueAuxillaryParticle : AuxillaryBase {

	void Awake (){
		amount = 1.5f;
		value = 1;
		stringId = "shield";
		powerupName = "Blue Auxillary Particle";
	}
		
	public override void PowerupAction(GameObject player){
		player.GetComponent<PlayerAuxillaryParticles> ().AddParticle(value, this);
	}
}
