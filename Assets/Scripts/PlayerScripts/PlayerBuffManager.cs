using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerBuffManager : MonoBehaviour {

	public GameObject fetchedBuff;
	public bool full;

	void Awake () {
		full = false; // might need to add checks for starting the game with buffs etc.
	}

// MAYBE we want to make these functions always return a GameObject 
// Then we can ask the object if it has what we want... but atm just null works

	public GameObject FindUnoccupiedBuff () {
	// This will always return either the desired object or null
		for ( int i = 0; i <  this.transform.childCount; i++){
			GameObject buff = this.transform.GetChild (i).gameObject;
			if (buff != null && !buff.GetComponent<PlayerBuff> ().occupied) {
				fetchedBuff = buff;
				break;
			} else {
				fetchedBuff = null;
			}
		}
		return fetchedBuff;
	}

	public GameObject FindOccupiedBuff (string stringId){
	// This will always return either the desired object or null
		for ( int i = 0; i <  this.transform.childCount; i++) {
			GameObject buff = this.transform.GetChild (i).gameObject;
			if (buff != null && buff.GetComponent<PlayerBuff> ().occupied && buff.GetComponent<PlayerBuff> ().occupant == stringId) {
				fetchedBuff = buff;
				break;
			} else {
				fetchedBuff = null;
			}
				
		}
		return fetchedBuff;
	}

	public GameObject GetBuffByInt (int i){
		return this.transform.GetChild (i).gameObject;
	}
}
