using UnityEngine;
using System.Collections;

public class PlayerAuxillaryParticles : MonoBehaviour {

	private int maxParticles;
	private int particles;

	private PlayerMovement pMovement;
	private PlayerEnergy pEnergy;
	private PlayerBuffManager pBuffs;

	private GameObject p; // just incase its necesary

	void Awake () {
		pEnergy = this.GetComponent<PlayerEnergy> ();
		pMovement = this.GetComponent<PlayerMovement> ();
		pBuffs = this.GetComponent<PlayerBuffManager> ();
		particles = 0;
		maxParticles = 3;
	}
		
	public void AddParticle(int value, AuxillaryBase particle){
		// When a player hit's an Auxillary Particle object this triggers
		if (particle != null && particles < maxParticles) {
			particles += value;
			// Uses PlayerBuffManager to find a free buff slot
			pBuffs.FindUnoccupiedBuff ();
			GameObject p = pBuffs.fetchedBuff;
			// After PlayerBuffManager has found and retreived a free slot, we occupy it with this particles data
			p.GetComponent<PlayerBuff> ().OccupyBuffSlot (particle);
		}
		ApplyBuffsToPlayer (particle);
		if (particles == maxParticles) {
			pBuffs.full = true;
		}
	}

	private void ApplyBuffsToPlayer (AuxillaryBase particle){
		switch (particle.stringId) {
		case "shield":
			pEnergy.shielded = true;
			break;
		case "speed":
			pMovement.speedBuffs += particle.amount;
			break;
		}
	}

	public void RemoveShield (){
		RemoveParticle ("shield");
		// This checks if there are any other shields hanging around, if not - disable shielding for player
		GameObject p = pBuffs.FindOccupiedBuff ("shield");
		if (p == null) {
			pEnergy.shielded = false;
		}
	}

	public void RemoveParticle (string id){
		if (id != null){
			particles -= 1;
			GameObject p = pBuffs.FindOccupiedBuff (id);
			p.GetComponent<PlayerBuff> ().EmptyBuffSlot ();
			pBuffs.full = false;
		}
	}

	// Should get this working asap
//	public void UseBuffs () {
//		for (int i = 0; i < particles; i++ ){
//			GameObject p = pBuffs.GetBuffByInt (i);
//			switch (p) {
//			case "shield":
//				pEnergy = ;
//				break;
//			case "speed":
//				pMovement.speedBuffs += particle.amount;
//				break;
//			}
//		}
//	}
}
