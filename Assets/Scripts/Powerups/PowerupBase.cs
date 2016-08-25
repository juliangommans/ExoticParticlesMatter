using UnityEngine;
using System.Collections;

public class PowerupBase : MonoBehaviour {

	public bool powerupTriggered; // maybe not necesarry
	public string powerupName;
	public int value;

	private void OnTriggerEnter2D(Collider2D other){
		if (other != null && other.name == "Player") {
			powerupTriggered = true;
			PowerupAction(other.gameObject);
			Destroy(this.gameObject);
			// maybe play a 'pop' animation e.g. PlayAnimation();
		}
	}

	public virtual void PowerupAction (GameObject player){
		// use this method from inherrited classes
		Debug.Log("You haven't created an action for this powerup: " + powerupName);
	}
}
