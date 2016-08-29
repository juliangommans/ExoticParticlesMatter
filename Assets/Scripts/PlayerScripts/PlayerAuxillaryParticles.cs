﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAuxillaryParticles : MonoBehaviour {

	private int maxParticles;
	private int particles;

	private PlayerMovement pMovement;
	private PlayerEnergy pEnergy;
	private PlayerBuffManager pBuffs;

	private GameObject p; // just incase its necesary

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
			pBuffs.FindUnoccupiedBuff ();
			GameObject p = pBuffs.fetchedBuff;
			p.GetComponent<PlayerBuff> ().OccupyBuffSlot (particle);
			currentParticles.Add(p);
		}
		if (particle.stringId == "shield") {
			pEnergy.shielded = true;
		}
	}

	public void RemoveShield (){
		RemoveParticle (FindParticle("shield"));
		GameObject p = FindParticle("shield");
		if (p == null) {
			pEnergy.shielded = false;
		}
	}

	public void RemoveParticle (GameObject pb){
		Debug.Log ("what have we here (buffs): " + pb);
		if (pb != null){
			particles -= 1;
			pBuffs.FindOccupiedBuff (pb.GetComponent<PlayerBuff>().occupant);
			GameObject p = pBuffs.fetchedBuff;
			p.GetComponent<PlayerBuff> ().EmptyBuffSlot ();
			currentParticles.Remove (p);
		}
	}

	private GameObject FindParticle (string id){
		Debug.Log ("currentParticles: " + currentParticles.Count);
		GameObject p = currentParticles.Find(obj => string.Equals(obj.GetComponent<PlayerBuff>().occupant, id));

		Debug.Log ("string", p);
		return p;
	}

}
