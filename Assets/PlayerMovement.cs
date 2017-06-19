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
	public List<LineRenderer> spawnedLineList;
	public List<LineRenderer> lineVariants;
	static public float rayBounceTimeToMax = 5;
	public int minRays = 2, maxRays = 15;
	static public float buttonHeld;
	public List<Color> lineColors;
	public Vector3[] linePos;
	public MouseLook ml;
	public UIManager ui;
	static public int reflectNum;

	public LineRenderer line1;
	public LineRenderer line2;
	public LineRenderer line3;
	public LineRenderer line4;
	public LineRenderer line5;
	public LineRenderer line6;
	public LineRenderer line7;
	public LineRenderer line8;
	public LineRenderer line9;
	public LineRenderer line10;
	public LineRenderer line11;
	public LineRenderer line12;
	public LineRenderer line13;
	public LineRenderer line14;
	public LineRenderer line15;

	void Start(){
		lineColors.Add(Color.blue);
		lineColors.Add(Color.cyan);
		lineColors.Add(Color.green);
		lineColors.Add(Color.magenta);
		lineColors.Add(Color.red);
		lineColors.Add(Color.yellow);
		lineColors.Add(Color.black);

		Cursor.lockState = CursorLockMode.Locked;
	}

	// Update is called once per frame
	void FixedUpdate () {
		rb.transform.rotation = new Quaternion(0.0f, camObject.transform.rotation.y, 0.0f, camObject.transform.rotation.w);
		Controls();
		reflectNum = Mathf.RoundToInt (Mathf.Lerp(minRays, maxRays, buttonHeld / rayBounceTimeToMax));
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
		if (Input.GetKey (KeyCode.LeftControl))
			transform.position -= Vector3.up * moveSpeed * Time.deltaTime;
		if (Input.GetMouseButtonUp (0)) {
			LeftMouseClick ();
			ui.charger.SetActive(false);
		}
		if (Input.GetMouseButton (0)) {
			buttonHeld += (Time.deltaTime);
			ui.charger.SetActive(true);
			runOnce = false;
		} else {
			buttonHeld = 0;
		}
		if (Input.GetMouseButtonDown (1)) {
			int lastLine = spawnedLineList.Count - 1;
			Destroy (spawnedLineList[lastLine]);
			spawnedLineList.RemoveAt (lastLine);
			}
		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
		if (Input.GetKeyDown (KeyCode.R))
			SceneManager.LoadScene ("TestMirror");
	}

	public void LeftMouseClick(){
		if (runOnce == false) {
			//shoot line NOW
			ml.ShootLine(reflectNum);
			WhichLine (reflectNum);
			lineRend = Instantiate (lineShot);
			lineRend.SetPositions (ml.lineVectors);
			lineRend.material.color = lineColors[Random.Range(0,lineColors.Count)];
			spawnedLineList.Add (lineRend);
			buttonHeld = 0;
			runOnce = true;
		}
	}

	public void WhichLine(int numOfPositions){
		if (numOfPositions == 1)
			lineShot = line1;
		else if (numOfPositions == 2)
			lineShot = line2;
		else if (numOfPositions == 3)
			lineShot = line3;
		else if (numOfPositions == 4)
			lineShot = line4;
		else if (numOfPositions == 5)
			lineShot = line5;
		else if (numOfPositions == 6)
			lineShot = line6;
		else if (numOfPositions == 7)
			lineShot = line7;
		else if (numOfPositions == 8)
			lineShot = line8;
		else if (numOfPositions == 9)
			lineShot = line9;
		else if (numOfPositions == 10)
			lineShot = line10;
		else if (numOfPositions == 11)
			lineShot = line11;
		else if (numOfPositions == 12)
			lineShot = line12;
		else if (numOfPositions == 13)
			lineShot = line13;
		else if (numOfPositions == 14)
			lineShot = line14;
		else if (numOfPositions == 15)
			lineShot = line15;
		else
			return;
	}
}