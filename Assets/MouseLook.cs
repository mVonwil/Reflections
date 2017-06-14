using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

	public GameObject playerBody;

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

		transform.position = new Vector3(playerBody.transform.position.x, playerBody.transform.position.y + 1, playerBody.transform.position.z);

		ShootLine ();
	}

	void LookLimits(){
		if (pitch <= (-70))
			pitch = (-70);
		else if (pitch >= 60)
			pitch = 60;
	}

	void ShootLine(){
		Vector3 forward = transform.TransformDirection (Vector3.forward) * 10;
		Debug.DrawRay (transform.position, forward, Color.green);
		RaycastHit hit;

		if(Physics.Raycast(transform.position/*+forward*0.01f*/, forward, out hit)){
			if (hit.collider.tag == "Mirror") {
				Debug.Log ("In mouse");
				string mirrorName = hit.collider.gameObject.name;
				print (mirrorName);
				Vector3 impactPoint = hit.point;
				hit.collider.gameObject.GetComponent<MirrorControl> ().Reflect (forward, impactPoint, hit.normal, 0);
				//Debug.Log ("Hit Mirror");
				Debug.DrawRay(hit.point,hit.normal*1.0f,Color.cyan);
			}
		}
	}
}
