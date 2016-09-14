using UnityEngine;
using System.Collections;

public class EndZone : FreezeOnEnter {

	public override void ObjectSpecificAction (Collider2D other){
		other.GetComponent<PlayerEnergy> ().finished = true;
	}
}
