using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerEnergy : MonoBehaviour {

	public int energy;
	public int maxEnergy;
	private Slider energySlider;

	private PlayerAuxillaryParticles playerBuffs;

	public bool isAlive;
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
		regenTimer = 10f;
		invulnerable = false;
		shielded = false;
		isAlive = true;
		energySlider = GameObject.Find("HealthBar").GetComponent<Slider> ();
		energy = maxEnergy;
		energySlider.maxValue = maxEnergy;
	}

	void Update(){
		if (energy <= 0) {
			energy = 0;
			Debug.Log ("you dead sorry :(");
			isAlive = false;
		}
		if (energy > 0 && !isAlive) {
			isAlive = true;
		}
		energySlider.value = energy;
		if (energy < maxEnergy && ableToRegen && !regenerating) {
			StartCoroutine (Regeneration());
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
		while (energy <= maxEnergy && ableToRegen) {
			ChangeEnergy (1, "regen");
			yield return new WaitForSeconds (regenTimer);
		}
	}

	public void ChangeRegenTimer (float amount) {
		regenTimer += amount;
	}

	public void ChangeEnergy(int amount, string source){
		if (shielded && source == "Damage") {
			playerBuffs.RemoveParticle ("shield");
		} else {
			if (invulnerable && source == "Damage") {
				//do nothing
			}else{
				energy += amount;
				if (energy >= maxEnergy) {
					energy = maxEnergy;
				}
			}
		}
	}
}
