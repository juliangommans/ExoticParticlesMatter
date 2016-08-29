using UnityEngine;
using System.Collections;

public class PlayerBuff : MonoBehaviour {

	public bool occupied;
	public string occupant;
	private SpriteRenderer image;

	void Awake (){
		occupied = false;
		image = GetComponent<SpriteRenderer> ();
		if (image.enabled) {
			image.enabled = false;
		}
	}

	public void OccupyBuffSlot (AuxillaryBase buff){
		occupant = buff.stringId;
		image.enabled = true;
		image.color = buff.color;
		occupied = true;
	}

	public void EmptyBuffSlot (){

	}
}
