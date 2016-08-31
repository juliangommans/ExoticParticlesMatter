using UnityEngine;
using System.Collections;

public class YellowAuxillaryParticle : AuxillaryBase {

	void Awake (){
		amount = 0.3f;
		value = 1;
		stringId = "haste";
		powerupName = "Yellow Auxillary Particle";
	}
		
	public override void PowerupAction(GameObject player){
		player.GetComponent<PlayerAuxillaryParticles> ().AddParticle(value, this);
	}
}
