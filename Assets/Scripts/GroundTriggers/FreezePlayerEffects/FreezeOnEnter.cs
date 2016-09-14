using UnityEngine;
using System.Collections;

public class FreezeOnEnter : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll){
		if (coll != null && coll.name == "Player") {
			StartCoroutine (FreezePlayer(coll));
		}
	}

	private IEnumerator FreezePlayer(Collider2D other){
		yield return new WaitForSeconds(0.03f);
		other.attachedRigidbody.velocity = Vector3.zero;
		other.attachedRigidbody.angularVelocity = 0f;
		ObjectSpecificAction (other);
	}

	public virtual void ObjectSpecificAction (Collider2D other){
		Debug.Log ("You haven't entered a specific action for this (" + this.gameObject.name + ") to perform");
	}
}
