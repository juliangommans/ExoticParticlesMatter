using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAuxillaryParticles : MonoBehaviour {

	private int maxParticles;
	private int particles;

	private PlayerMovement pMovement;
	private PlayerEnergy pEnergy;
	private PlayerBuffManager pBuffs;

	private List<GameObject> currentParticles;

	void Awake () {
		
		currentParticles = new List<GameObject> ();
		pEnergy = this.GetComponent<PlayerEnergy> ();
		pMovement = this.GetComponent<PlayerMovement> ();
		pBuffs = this.GetComponent<PlayerBuffManager> ();
		particles = 0;
		maxParticles = 3;
	}
		
	public void AddParticle(int value, AuxillaryBase particle){
		Debug.Log (particle);
		if (particle != null && particles < maxParticles) {
			particles += value;
			GameObject p = pBuffs.FindUnoccupiedBuff ();
			p.GetComponent<PlayerBuff> ().OccupyBuffSlot (particle);
			currentParticles.Add(p);
		}
		if (particle.stringId == "shield") {
			pEnergy.shielded = true;
		}
	}

	public void RemoveShield (){
		RemoveParticle (FindParticle("shield"));
		AuxillaryBase p = FindParticle("shield");
		if (p == null) {
			pEnergy.shielded = false;
		}
	}

	public void RemoveParticle (AuxillaryBase p){
		Debug.Log ("what have we here (buffs): " + p);
		if (p != null){
			currentParticles.Remove (p);
		}
	}

	private AuxillaryBase FindParticle (string id){
		Debug.Log ("currentParticles: " + currentParticles.Count);
		foreach (AuxillaryBase x in currentParticles) {
			Debug.Log ("what is this? " + x);
			Debug.Log (x.stringId);
		}
		AuxillaryBase p = GameObject.Find(obj => string.Equals(obj.stringId, "shield"));
		Debug.Log ("string", p);
		return p;
	}

}
