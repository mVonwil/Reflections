using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Slider chargeTimer;
	public GameObject charger;

	void Start(){
		charger.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		chargeTimer.value = PlayerMovement.buttonHeld / PlayerMovement.rayBounceTimeToMax;
	}
}
