using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerBuffManager : MonoBehaviour {

	public GameObject fetchedBuff;
	
	public void FindUnoccupiedBuff () {
		for ( int i = 0; i <  this.transform.childCount; i++){
			GameObject buff = this.transform.GetChild (i).gameObject;
			if (buff != null && !buff.GetComponent<PlayerBuff> ().occupied) {
				fetchedBuff = buff;
				break;
			}
		}
	}

	public void FindOccupiedBuff (string stringId){
		for ( int i = 0; i <  this.transform.childCount; i++) {
			GameObject buff = this.transform.GetChild (i).gameObject;
			if (buff != null && buff.GetComponent<PlayerBuff> ().occupied && buff.GetComponent<PlayerBuff> ().occupant == stringId) {
				fetchedBuff = buff;
				break;
			}
		}
	}
}
