using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MirrorControl : MonoBehaviour {

	static public void BounceRays(Vector3 startRayAt, Vector3 rayDir, ref RaycastHit[] hits, ref Vector3[] lineVectors)
	{
		Ray curRay = new Ray (startRayAt, rayDir);

		for (int i = 0; i < hits.Length; i++) {
			
			RaycastHit rayHit = new RaycastHit ();

			if (Physics.Raycast (curRay, out rayHit)) {

				hits [i] = rayHit;

				lineVectors [i + 1] = rayHit.point;

				var hitPoint = curRay.GetPoint (rayHit.distance - 0.005f);
				Debug.DrawLine (curRay.origin, hitPoint, Color.red);

				curRay = new Ray (hitPoint, Vector3.Reflect (curRay.direction, rayHit.normal));

			} else {
				break;
			}
		} 
	}
}