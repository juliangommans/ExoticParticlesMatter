using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerEnergy : MonoBehaviour {

	public int energy;
	public int maxEnergy;
	public Slider energySlider;

	public bool isAlive;

	public GameObject[] subAtomicParticles;

	void Start(){
		if (maxEnergy <= 0) {
			maxEnergy = 10;
		}
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

	public void ChangeEnergy(int amount){
		energy += amount;
		if (energy >= maxEnergy) {
			energy = maxEnergy;
		}
	}
}
