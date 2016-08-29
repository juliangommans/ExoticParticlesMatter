using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerEnergy : MonoBehaviour {

	public int energy;
	public int maxEnergy;
	public Slider energySlider;

	private PlayerAuxillaryParticles playerBuffs;

	public bool isAlive;
	public bool shielded;

	void Awake(){
		playerBuffs = this.GetComponent<PlayerAuxillaryParticles> ();
		if (maxEnergy <= 0) {
			maxEnergy = 10;
		}
		shielded = false;
		isAlive = true;
		energy = maxEnergy;
		energySlider.maxValue = maxEnergy;
	}

	void Update(){
		if (energy <= 0) {
			energy = 0;
			Debug.Log ("you dead sorry :(");
			isAlive = false;
		}
		energySlider.value = energy;
	}

	public void ChangeEnergy(int amount, string source){
		if (shielded && source == "Damage") {
			playerBuffs.RemoveShield ();
		} else {
			energy += amount;
			if (energy >= maxEnergy) {
				energy = maxEnergy;
			}
		}
	}
}
