using UnityEngine;
using System.Collections;

public class SlowPlayer : FloorTriggers {

	void Awake(){
		ColorTheFloor (Color.yellow);
	}

	public override void EnableEffect (Collider2D other){
		other.GetComponent<Rigidbody2D> ().drag = 2f;
	}

	public override void DisableEffect (Collider2D other){
		other.GetComponent<Rigidbody2D> ().drag = other.GetComponent<PlayerMovement>().defaultDrag;
	}
}
