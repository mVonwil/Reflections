using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody rb;
	public float moveSpeed = 5;
	public GameObject camObject;
	static public LineRenderer lineRend;
	public LineRenderer lineShot;
	public bool runOnce = false;
	public List<LineRenderer> lineList;
	public float rayBounceTimeToMax = 1;
	public int minRays = 2, maxRays = 15;
	static public float buttonHeld;
	public List<Color> lineColors;
	public Vector3[] linePos;
	public MouseLook ml;

	void Start(){
		lineColors.Add(Color.blue);
		lineColors.Add(Color.cyan);
		lineColors.Add(Color.green);
		lineColors.Add(Color.magenta);
		lineColors.Add(Color.red);
		lineColors.Add(Color.yellow);
		lineColors.Add(Color.black);

		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.transform.rotation = new Quaternion(0.0f, camObject.transform.rotation.y, 0.0f, camObject.transform.rotation.w);
		Controls();
	}

	//Move the character with WASD
	void Controls(){
		if (Input.GetKey (KeyCode.W))
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
		else if (Input.GetKey (KeyCode.S))
			transform.position -= transform.forward * moveSpeed * Time.deltaTime;
		if (Input.GetKey (KeyCode.A))
			transform.position -= transform.right * moveSpeed * Time.deltaTime;
		else if (Input.GetKey (KeyCode.D))
			transform.position += transform.right * moveSpeed * Time.deltaTime;
		if (Input.GetKey (KeyCode.Space))
			transform.position += Vector3.up * moveSpeed * Time.deltaTime;
		if (Input.GetKey(KeyCode.LeftControl))
			transform.position -= Vector3.up * moveSpeed * Time.deltaTime;


		if (Input.GetMouseButtonUp (0)) {
			LeftMouseClick ();
		}

		if (Input.GetMouseButton (0)) {
			buttonHeld += (Time.deltaTime);
			runOnce = false;
		} else {
			buttonHeld = 0;
		}

		if (Input.GetMouseButton (1)) {
			if (lineList.Count > 0) {
				LineRenderer lineObj = lineList.FindLast ((LineRenderer obj) => lineRend);
				Destroy (lineObj);
				int lastLine = lineList.Count - 1;
				lineList.RemoveAt (lastLine);
			} else
				return ;
		}
		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
		if (Input.GetKeyDown (KeyCode.R))
			SceneManager.LoadScene ("TestMirror");
	}

	public void LeftMouseClick(){
		if (runOnce == false) {
			//shoot line NOW
			ml.ShootLine(Mathf.RoundToInt (Mathf.Lerp(minRays, maxRays, buttonHeld / rayBounceTimeToMax)));

			//MaxRays (buttonHeld);
			lineRend = Instantiate (lineShot);
			lineRend.SetPositions (MouseLook.lineVectors);
//			lineRend.SetPositions (linePos);
			lineRend.material.color = lineColors[Random.Range(0,lineColors.Count)];
			lineList.Add (lineRend);
			buttonHeld = 0;
			runOnce = true;
		}
	}

	public void MaxRays(int bounceMax){
		for (int e = 1; e < bounceMax; e++){
			linePos[e] = MouseLook.lineVectors[e];
		}
	}
}