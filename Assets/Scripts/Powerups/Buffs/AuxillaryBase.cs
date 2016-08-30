using UnityEngine;
using System.Collections;

public class AuxillaryBase : PowerupBase {

	public string stringId;
	public Color color;
	public float amount;

	void Start(){
		color = this.GetComponent<SpriteRenderer>().color;
	}

	// This makes sure you don't pick up auxillary particles if you're full..
	void Update () {
		if (GameObject.Find("Player").GetComponent<PlayerBuffManager>().full) {
			destructable = false;
		} else {
			destructable = true;
		}
	}
	
}
