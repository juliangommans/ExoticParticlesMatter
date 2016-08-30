using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public Vector2 startDrag;
	public Vector2 endDrag;
	public Vector2 direction;
	public Vector2 currentDrag;

	public float distance;
	private float factoredDistance;
	private float holdingForDrag;

	public bool dragging;
	public bool draggingEnabled;
	public bool draggingFinished;

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
	}

	void Update () {
		ManageInputs();
		ManageEnum ();
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
			draggingFinished = true;
		}

	}

	private void ManageEnum(){
		factoredDistance = Vector2.Distance (startDrag, currentDrag) / 100;
		if (factoredDistance < 0.1f) {
			dragSize = DragSize.Cancel;
		} else if (factoredDistance >= 0.1f && factoredDistance < 3f) {
			dragSize = DragSize.Short;
		} else if (factoredDistance >= 3f && factoredDistance < 6f) {
			dragSize = DragSize.Medium;
		} else if (factoredDistance >= 6f) {
			dragSize = DragSize.Long;
		}
	}
}
