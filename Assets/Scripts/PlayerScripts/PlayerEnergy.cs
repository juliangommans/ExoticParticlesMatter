using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerEnergy : MonoBehaviour {

	public int energy;
	public int maxEnergy;
	private Slider energySlider;

	private PlayerAuxillaryParticles playerBuffs;

	public bool isAlive;
	public bool finished;
	public bool shielded;
	public bool invulnerable;
	public bool regenerating;
	public bool ableToRegen;

	private float regenTimer;

	void Awake(){
		playerBuffs = this.GetComponent<PlayerAuxillaryParticles> ();
		if (maxEnergy <= 0) {
			maxEnergy = 10;
		}
		ableToRegen = true;
		regenTimer = 6f;
		invulnerable = false;
		shielded = false;
		isAlive = true;
		finished = false;
		energySlider = GameObject.Find("HealthBar").GetComponent<Slider> ();
		energy = maxEnergy;
		energySlider.maxValue = maxEnergy;
	}

	void Update(){
		// If you take damage that reduces you below total energy remaining = you dead;
		if (energy < 0) {
			Dead ();
		}
		// If you're unable to regen and have no energy... you dead;
		if (energy == 0 && !ableToRegen) {
			Dead ();
		}
		// probably unnessecary, but a cover for if you end up not alive with energy to spare
		if (energy > 0 && !isAlive) {
			isAlive = true;
		}
		// HealthBar
		energySlider.value = energy;
		// Regeneration logic
		if (energy < maxEnergy && ableToRegen && !regenerating) {
			StartCoroutine ("Regeneration");
		}
		if (!ableToRegen && regenerating) {
			StopCoroutine ("Regeneration");
			regenerating = false;
		}
	}

	public IEnumerator Invulnerability (float count){
		invulnerable = true;
		yield return new WaitForSeconds (count);
		invulnerable = false;
	}

	private IEnumerator Regeneration () {
		regenerating = true;
		energy -= 1; // I am adding this because it immediately adds one.
		while (energy <= maxEnergy && ableToRegen && regenerating) {
			ChangeEnergy (1, "regen");
			yield return new WaitForSeconds (regenTimer);
		}
	}

	public void ChangeRegenTimer (float amount) {
		regenTimer += amount;
	}

	public void ChangeEnergy(int amount, string source){
		if (isAlive) {
			if (shielded && source == "Damage") {
				playerBuffs.RemoveParticle ("shield");
			} else {
				if (invulnerable && source == "Damage") {
					//do nothing
				} else {
					energy += amount;
					if (energy >= maxEnergy) {
						energy = maxEnergy;
					}
				}
			}
		}
	}

	private void Dead(){
		energy = 0;
		Debug.Log ("you dead sorry :(");
		isAlive = false;
		ableToRegen = false;
		regenerating = false;
	}
}
