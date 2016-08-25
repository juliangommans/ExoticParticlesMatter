using UnityEngine;
using System.Collections;

public class DragLineDrawer : MonoBehaviour {
	public Color green = Color.green;
	public Color yellow = Color.yellow;
	public Color red = Color.red;
	public Color gray = Color.gray;

	private InputManager inputManager;
	public LineRenderer lineRenderer;

	private Vector3 startLine;
	private Vector3 currentLine;
	private Vector3 endLine;

	private bool drawingLine;

	void Start() {
		inputManager = FindObjectOfType<InputManager> ();
		drawingLine = false;
		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.SetColors(green,green);
		lineRenderer.SetWidth(0.2F, 0.2F);
		lineRenderer.sortingLayerName = "Player";
	}

	void Update() {
		if (inputManager.dragging && !drawingLine) {
			StartDrawingLine ();
		}

		if (drawingLine && inputManager.dragging) {
			currentLine = Camera.main.ScreenToWorldPoint( new Vector3 (inputManager.currentDrag.x, inputManager.currentDrag.y, 2));
			lineRenderer.SetPosition (1, currentLine);
			LineColor ();
		} 

		if (inputManager.draggingFinished) {
			drawingLine = false;
			lineRenderer.enabled = false;
		}
	}

	private void StartDrawingLine(){
		lineRenderer.enabled = true;
		startLine = Camera.main.ScreenToWorldPoint( new Vector3 (inputManager.startDrag.x, inputManager.startDrag.y, 2));
		lineRenderer.SetPosition (0, startLine);
		drawingLine = true;
	}

	private void LineColor(){
		switch (inputManager.dragSize) {
		case InputManager.DragSize.Cancel:
			lineRenderer.SetColors (gray, gray);
			break;
		case InputManager.DragSize.Short:
			lineRenderer.SetColors(green,green);
			break;
		case InputManager.DragSize.Medium:
			lineRenderer.SetColors(yellow,yellow);
			break;
		case InputManager.DragSize.Long:
			lineRenderer.SetColors(red,red);
			break;
		}
	}
}
