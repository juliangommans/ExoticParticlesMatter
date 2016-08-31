using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private InputManager inputManager;
	private PlayerEnergy playerEnergy;
	private Rigidbody2D playerRb;

	private float forceOutput;
	public float forceFactor;
	public float speedBuffs;

	private int cost;

	void Start () {
		inputManager = FindObjectOfType<InputManager> ();
		playerEnergy = this.GetComponent<PlayerEnergy>();
		playerRb = this.GetComponent<Rigidbody2D>();
		forceFactor = 2f;
		speedBuffs = 1f;
	}

	void Update () {
		// Test Script atm (speed boost)
		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("CurrentDirection: " + playerRb.velocity.normalized);
			playerRb.AddForce (playerRb.velocity * 50f);
		}
			
	}

	void LateUpdate () {
		if (inputManager.draggingFinished && playerEnergy.isAlive && inputManager.dragSize != InputManager.DragSize.Cancel){
			forceOutput = inputManager.distance * forceFactor * speedBuffs;
			CalculateCost ();
			if (cost > playerEnergy.energy) {
				CalculateNewMotion ();
				Debug.Log ("shit costs yo " + cost);
				Debug.Log ("energy? " + playerEnergy.energy);
			}
			MovePlayer (inputManager.direction, forceOutput);
			playerEnergy.ChangeEnergy (-cost, "PlayerAction");
		}
	}

	private void CalculateNewMotion (){
		switch (playerEnergy.energy) {
			case 1:
				forceOutput = 225f;
				break;
			case 2:
				forceOutput = 450f;
				break;
		}
	}

	public void MovePlayer (Vector2 direction, float speed){
		playerRb.AddForce (direction * speed);
	}

	public void SpeedBoost (Vector2 direction, float speed){
		if (direction == Vector2.zero){
			direction = inputManager.direction;
		}
		playerRb.velocity = direction * speed;
	}

	public void ChangeSpeedBuff (float amount) {
		speedBuffs += amount; 
	}

	private void CalculateCost () {
		switch (inputManager.dragSize) {
			case InputManager.DragSize.Cancel:
				cost = 0;
				break;
			case InputManager.DragSize.Short:
				cost = 1;
				break;
			case InputManager.DragSize.Medium:
				cost = 2;
				break;
			case InputManager.DragSize.Long:
				cost = 3;
				break;
		}
	}
}
