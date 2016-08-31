using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public Vector2 startDrag;
	public Vector2 endDrag;
	public Vector2 direction;
	public Vector2 currentDrag;

	private PlayerAuxillaryParticles pAux;

	public float distance;
	private float distanceCap;
	private float factoredDistance;
	private float holdingForDrag;

	private float doubleTapTimer;

	public bool dragging;
	public bool draggingEnabled;
	public bool draggingFinished;

	public bool doubleTapEnabled;

	public enum DragSize
	{
		Cancel,
		Short,
		Medium,
		Long
	};
	public DragSize dragSize;

	void Start () {
		dragSize = DragSize.Short;
		draggingEnabled = true;
		pAux = FindObjectOfType<PlayerAuxillaryParticles> ();
		distanceCap = 620f;
	}

	void Update () {
		ManageInputs();
		ManageEnum ();
		if (doubleTapEnabled) {
			doubleTapTimer += Time.deltaTime;
		}
	}

	private void ManageInputs(){
		draggingFinished = false;
		if (Input.GetMouseButton (0)) {
			holdingForDrag += Time.deltaTime;
			currentDrag = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
			if (holdingForDrag >= 0.1f && draggingEnabled) { // might need bigger holdingForDrag
				dragging = true;
				draggingEnabled = false;
			}
		}

		if (Input.GetMouseButtonDown(0)){
			startDrag = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
			if (doubleTapEnabled && doubleTapTimer <= 0.35f) {
				pAux.UseBuffs ();
				doubleTapEnabled = false;
			}
			if (!doubleTapEnabled) {
				doubleTapEnabled = true;
			}
			doubleTapTimer = 0f;
		}

		if (Input.GetMouseButtonUp (0) && dragging) {
			// Reset vars for next movement
			holdingForDrag = 0f;
			dragging = false;
			draggingEnabled = true;
			// Calculate physics
			endDrag = currentDrag;
			direction = (startDrag - endDrag).normalized;
			distance = Vector2.Distance (startDrag, endDrag);
			if (distance >= distanceCap){
				distance = distanceCap;
			}
			draggingFinished = true;
		}
	}

	private void ManageEnum(){
		factoredDistance = Vector2.Distance (startDrag, currentDrag) / 100;
		if (factoredDistance < 0.12f) {
			dragSize = DragSize.Cancel;
		} else if (factoredDistance >= 0.12f && factoredDistance < 2.25f) {
			dragSize = DragSize.Short;
		} else if (factoredDistance >= 2.25f && factoredDistance < 4.5f) {
			dragSize = DragSize.Medium;
		} else if (factoredDistance >= 4.5f) {
			dragSize = DragSize.Long;
		}
	}
}
