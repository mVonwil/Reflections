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
	static public float buttonHeld;
	public List<Color> lineColors;

	void Start(){
		lineColors.Add(Color.blue);
		lineColors.Add(Color.cyan);
		lineColors.Add(Color.green);
		lineColors.Add(Color.magenta);
		lineColors.Add(Color.red);
		lineColors.Add(Color.yellow);
		lineColors.Add(Color.black);
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
		if (Input.GetMouseButton (0)) {
			buttonHeld += (Time.deltaTime * 2);
			if (buttonHeld > 15)
				buttonHeld = 15;
			runOnce = false;
		}
		if (Input.GetMouseButtonUp (0)) {
			MouseLook.bounceMax = Mathf.RoundToInt (buttonHeld);
			LeftMouseClick ();
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
			MirrorControl.MaxRays (MouseLook.bounceMax);
			lineRend = Instantiate (lineShot);
			lineRend.SetPositions (MirrorControl.linePos);
			lineRend.material.color = lineColors[Random.Range(0,lineColors.Count)];
			lineList.Add (lineRend);
			buttonHeld = 0;
			runOnce = true;
		}
	}
}