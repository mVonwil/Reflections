using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorControl : MonoBehaviour {

	//ReflectControl reflectControl;
	public Vector3 outgoing;

	void Start(){
		//reflectControl = GameObject.FindGameObjectWithTag ("GameControl").GetComponent<ReflectControl> ();
	}

	public void Reflect(Vector3 incoming, Vector3 pointOfImpact,Vector3 norm, int depth){
		if(depth<5)
		{
		Debug.Log (this.gameObject.name);
		outgoing = Vector3.Reflect (incoming, norm);
		Debug.DrawRay (pointOfImpact, outgoing,Color.magenta);
		RaycastHit hit;
		//Debug.Log ("In mirror");
			if (Physics.Raycast (pointOfImpact/*+outgoing*0.1f*/, incoming, out hit) {
				if (hit.collider.tag == "Mirror") {
					Vector3 impactPoint = hit.point;
					hit.collider.gameObject.GetComponent<MirrorControl> ().Reflect (outgoing, impactPoint,hit.normal,depth+1);
					//Debug.Log ("Hit Mirror");
					Debug.DrawRay(hit.point,hit.normal,Color.red);
				}
			}
		}
	}
}
