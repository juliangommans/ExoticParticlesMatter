using UnityEngine;
using System.Collections;

public class PlayerAuxillaryParticles : MonoBehaviour {

	private int maxParticles;
	private int particles;

	private PlayerMovement pMovement;
	private PlayerEnergy pEnergy;
	private PlayerBuffManager pBuffs;

	private GameObject p; // just incase its necesary

	private int shieldCount;
	private int hasteCount;
	private int regenCount;

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
			// Now we actually apply the buff effects to the player
			ApplyBuffsToPlayer (particle);
		}
		if (particles == maxParticles) {
			pBuffs.full = true;
		}
	}

	private void ApplyBuffsToPlayer (AuxillaryBase particle){
		switch (particle.stringId) {
		case "shield":
			pEnergy.shielded = true;
			shieldCount += 1;
			break;
		case "haste":
			pMovement.ChangeSpeedBuff (particle.amount);
			hasteCount += 1;
			break;
		case "regen":
			pEnergy.ChangeRegenTimer (-particle.amount);
			regenCount += 1;
			break;
		}
	}

	public void RemoveShield (){
	// This checks if there are any other shields hanging around, if not - disable shielding for player
		if (shieldCount <= 0) {
			pEnergy.shielded = false;
		}
	}

	public void RemoveHaste (GameObject p){
		pMovement.ChangeSpeedBuff(-p.GetComponent<PlayerBuff> ().amount);
	}

	public void RemoveRegen(GameObject p){
		pEnergy.ChangeRegenTimer (p.GetComponent<PlayerBuff> ().amount);
	}

	public void RemoveParticle (string id){
		if (id != null){
			particles -= 1;
			GameObject p = pBuffs.FindOccupiedBuff (id);
			// Yields to particle switch to handle individual particles differently
			ParticleSpecificCleanup (p, id);
			p.GetComponent<PlayerBuff> ().EmptyBuffSlot ();
			pBuffs.full = false;
		}
	}

	private void ParticleSpecificCleanup (GameObject p, string id){
		if (id != null && p!= null) {
			switch (id) {
			case "shield":
				shieldCount -= 1;
				RemoveShield();
				break;
			case "haste":
				hasteCount -= 1;
				RemoveHaste(p);
				break;
			case "regen":
				regenCount -= 1;
				RemoveRegen(p);
				break;
			}
		}
	}

	// When a player double taps, uses all current buffs for a certain effect.
	public void UseBuffs () {
		if (shieldCount > 0) {
			GameObject p = pBuffs.FindOccupiedBuff ("shield");
			StartCoroutine (pEnergy.Invulnerability (shieldCount * p.GetComponent<PlayerBuff> ().amount));
			int counter = shieldCount;
			for (int i = 0; i < counter; i++) {
				RemoveParticle ("shield");
			}
		}
		if (hasteCount > 0) {
			GameObject p = pBuffs.FindOccupiedBuff ("haste");
			float speed = hasteCount * p.GetComponent<PlayerBuff> ().amount * 15f;
			pMovement.SpeedBoost (Vector2.zero, speed);
			int counter = hasteCount;
			for (int i = 0; i < counter; i++) {
				RemoveParticle ("haste");
			}
		}
		if (regenCount > 0) {
			GameObject p = pBuffs.FindOccupiedBuff ("regen");
			pEnergy.ChangeEnergy (regenCount * 2, "buff");
			int counter = regenCount;
			for (int i = 0; i < counter; i++) {
				RemoveParticle ("regen");
			}
		}

	}
}
