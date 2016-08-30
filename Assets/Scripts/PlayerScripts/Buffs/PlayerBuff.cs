using UnityEngine;
using System.Collections;

public class PlayerBuff : MonoBehaviour {

	public bool occupied;
	public string occupant;
	public float amount;
	private SpriteRenderer image;

	void Awake (){
		EmptyBuffSlot ();
	}

	public void OccupyBuffSlot (AuxillaryBase buff){
		occupant = buff.stringId;
		image.enabled = true;
		image.color = buff.color;
		occupied = true;
		amount = buff.amount;
	}

	public void EmptyBuffSlot (){
		occupied = false;
		image = GetComponent<SpriteRenderer> ();
		image.color = Color.white;
		if (image.enabled) {
			image.enabled = false;
		}
		amount = 0f;
		occupant = null;
	}
}
