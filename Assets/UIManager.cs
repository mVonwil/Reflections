using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Slider chargeTimer;
	
	// Update is called once per frame
	void Update () {
		chargeTimer.value = PlayerMovement.buttonHeld;
	}
}
