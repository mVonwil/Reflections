using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody rb;
	public float moveSpeed = 5;
	public GameObject camObject;
	
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
	}
}