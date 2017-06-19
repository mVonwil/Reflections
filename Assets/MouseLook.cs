using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

	public GameObject playerBody;
	static public Vector3[] lineVectors;

	public float horizontalSpeed = 2.0f;
	public float verticalSpeed = 2.0f;

	public float yaw = 0.0f;
	public float pitch = 0.0f;
	
	// Update is called once per frame
	void Update () {
		yaw += horizontalSpeed * Input.GetAxis ("Mouse X");
		pitch -= verticalSpeed * Input.GetAxis ("Mouse Y");

		transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

		LookLimits ();

		transform.position = new Vector3(playerBody.transform.position.x, playerBody.transform.position.y + 0.25f, playerBody.transform.position.z);
	}

	void LookLimits(){
		if (pitch <= (-70))
			pitch = (-70);
		else if (pitch >= 60)
			pitch = 60;
	}

	public void ShootLine(int bounceMax){

		Debug.Log ("Boucning " + bounceMax.ToString () + " Rays");

		RaycastHit[] myHits = new RaycastHit[bounceMax];

		lineVectors = new Vector3[bounceMax+1];
		lineVectors [0] = transform.position;

		MirrorControl.BounceRays (transform.position, transform.forward, ref myHits, ref lineVectors);

		myHits = myHits;
	}


}
