using UnityEngine;
using System.Collections;

public class PlayerBuff : MonoBehaviour {

	public bool occupied;
	public string occupant;
	private SpriteRenderer image;

	void Awake (){
		EmptyBuffSlot ();
	}

	public void OccupyBuffSlot (AuxillaryBase buff){
		occupant = buff.stringId;
		image.enabled = true;
		image.color = buff.color;
		occupied = true;
	}

	public void EmptyBuffSlot (){
		occupied = false;
		image = GetComponent<SpriteRenderer> ();
		image.color = Color.white;
		if (image.enabled) {
			image.enabled = false;
		}
		occupant = null;
	}
}
