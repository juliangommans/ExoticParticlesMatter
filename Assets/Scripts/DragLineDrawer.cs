using UnityEngine;
using System.Collections;

public class DragLineDrawer : MonoBehaviour {
	public Color c0 = Color.green;
	public Color c1 = Color.yellow;
	public Color c2 = Color.red;

	private InputManager inputManager;
	public LineRenderer lineRenderer;
	private Camera camera;

	private Vector3 startLine;
	private Vector3 currentLine;
	private Vector3 endLine;

	private bool drawingLine;

	void Start() {
		camera = Camera.main;
		inputManager = FindObjectOfType<InputManager> ();
		drawingLine = false;
		lineRenderer = GetComponent<LineRenderer>();
//		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.material.color = c2;
		lineRenderer.SetColors(c2,c2);
		lineRenderer.SetWidth(0.2F, 0.2F);
		lineRenderer.sortingLayerName = "Player";
	}

	void Update() {
		if (inputManager.dragging && !drawingLine) {
			StartDrawingLine ();
		}

		if (drawingLine && inputManager.dragging) {
			currentLine = camera.ScreenToWorldPoint( new Vector3 (inputManager.currentDrag.x, inputManager.currentDrag.y, 2));
			lineRenderer.SetPosition (1, currentLine);
		} 

		if (inputManager.draggingFinished) {
			drawingLine = false;
			lineRenderer.enabled = false;
		}
	}

	private void StartDrawingLine(){
		lineRenderer.enabled = true;
		startLine = camera.ScreenToWorldPoint( new Vector3 (inputManager.startDrag.x, inputManager.startDrag.y, 2));
		lineRenderer.SetPosition (0, startLine);
		drawingLine = true;
	}
}
