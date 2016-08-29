using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerBuffManager : MonoBehaviour {
	
	public GameObject FindUnoccupiedBuff () {
		for ( int i = this.transform.childCount; i <= 0; i--){
			Debug.Log ("how many times do we go round?" + i);
			GameObject buff = this.transform.GetChild (i).gameObject;
			if (buff != null && !buff.GetComponent<PlayerBuff>().occupied){
				return buff;
			}
		}
	}

	public GameObject FindOccupiedBuff (string stringId){
		for (int i = this.transform.childCount; i <= 0; i--) {
			GameObject buff = this.transform.GetChild (i).gameObject;
			if (buff != null && buff.GetComponent<PlayerBuff> ().occupied && buff.GetComponent<PlayerBuff> ().occupant == stringId) {
				return buff;
			}
		}
	}
}
