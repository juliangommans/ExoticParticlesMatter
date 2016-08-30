using UnityEngine;
using System.Collections;

public class YellowAuxillaryParticle : AuxillaryBase {

	void Awake (){
		amount = 0.3f;
		value = 1;
		stringId = "speed";
//		color = Color.yellow;
		powerupName = "Blue Auxillary Particle";
	}
		
	public override void PowerupAction(GameObject player){
		player.GetComponent<PlayerAuxillaryParticles> ().AddParticle(value, this);
	}
}
