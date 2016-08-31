using UnityEngine;
using System.Collections;

public class PinkAuxillaryParticle : AuxillaryBase {

	void Awake (){
		amount = 1.5f;
		value = 1;
		stringId = "regen";
		powerupName = "Pink Auxillary Particle";
	}
		
	public override void PowerupAction(GameObject player){
		player.GetComponent<PlayerAuxillaryParticles> ().AddParticle(value, this);
	}
}
