using UnityEngine;
using System.Collections;

public class SpeedBoostPanel : MonoBehaviour {

	public float speed;
	public Vector2 direction;

	void Awake(){
		speed = 10f;
	}

	private void OnTriggerEnter2D(Collider2D other){
		if (other != null && other.name == "Player") { // might allow other objects to get wizzed away later
			other.GetComponent<PlayerMovement> ().SpeedBoost (direction.normalized, speed);
		}
		
	}

}
