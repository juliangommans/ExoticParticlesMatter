using UnityEngine;
using System.Collections;

public class SpeedBoostPanel : MonoBehaviour {

	public float speed = 150f;
	public Vector2 direction;

	private void OnTriggerEnter2D(Collider2D other){
		if (other != null && other.name == "Player") { // might allow other objects to get wizzed away later
			other.GetComponent<PlayerMovement> ().MovePlayer (direction.normalized, speed);
		}
		
	}

}
