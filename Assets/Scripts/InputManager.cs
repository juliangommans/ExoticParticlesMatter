using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public Vector2 startDrag;
	public Vector2 endDrag;
	public Vector2 direction;
	public Vector2 currentDrag;

	public float distance;
	private int roundedDistance;
	private float holdingForDrag;

	public bool dragging;
	public bool draggingEnabled;
	public bool draggingFinished;

	public enum DragSize
	{
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
			Debug.Log ("EndDrag: " + endDrag);
			draggingFinished = true;
		}

	}

	private void ManageEnum(){
		roundedDistance = (int)Mathf.Round (Vector2.Distance (startDrag, currentDrag) / 100);
		if (roundedDistance < 3) {
			dragSize = DragSize.Short;
		} else if (roundedDistance >= 3 && roundedDistance < 6) {
			dragSize = DragSize.Medium;
		} else if (roundedDistance >= 6) {
			dragSize = DragSize.Long;
		}
	}
}
