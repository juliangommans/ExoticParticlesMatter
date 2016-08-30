using UnityEngine;
using System.Collections;

public class BlueAuxillaryParticle : AuxillaryBase {

	void Awake (){
		value = 1;
		stringId = "shield";
//		color = Color.blue;
		powerupName = "Blue Auxillary Particle";
	}
		
	public override void PowerupAction(GameObject player){
		player.GetComponent<PlayerAuxillaryParticles> ().AddParticle(value, this);
	}
}
