using UnityEngine;
using System.Collections;

public class GravityWell : MonoBehaviour {

	private float pullRadius;
	private float pullForce;

	void Start (){
		pullRadius = 4f;
		pullForce = 3f;
	}

	public void FixedUpdate() {
		foreach (Collider2D collider in Physics2D.OverlapCircleAll(transform.position, pullRadius)) {

			if (collider != null && collider.name == "Player"){
				// calculate direction from target to me
				Vector2 forceDirection = new Vector2(transform.position.x - collider.transform.position.x, transform.position.y - collider.transform.position.y) ;
				// calculate the distance from target to me
				float distance = Vector2.Distance (transform.position, collider.transform.position);
				// apply force on target towards me
				collider.GetComponent<Rigidbody2D>().AddForce(forceDirection.normalized * (100/distance) * pullForce * Time.fixedDeltaTime);
			}
		}
	}
}
