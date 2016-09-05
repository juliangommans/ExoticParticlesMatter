using UnityEngine;
using System.Collections;

public class FloorTriggers : MonoBehaviour {



	public void ColorTheFloor(Color floorColor){
		foreach (Transform child in transform) {
			child.GetComponent<SpriteRenderer> ().color = floorColor;
		}
	}

	private void OnTriggerEnter2D(Collider2D other){
		if (other != null && other.name == "Player") {
			EnableEffect (other);
		}
	}

	public virtual void EnableEffect (Collider2D other){
		Debug.Log ("You have not ENabled an effect for a player entering this (" + this.gameObject.name + ") zone");
	}

	private void OnTriggerExit2D(Collider2D other){
		if (other != null && other.name == "Player") {
			DisableEffect (other);
		}
	}

	public virtual void DisableEffect (Collider2D other){
		Debug.Log ("You have not DISabled an effect for a player entering this (" + this.gameObject.name + ") zone");
	}
}
