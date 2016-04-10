using UnityEngine;
using System.Collections;

public class RotateLaser : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray PsychicRay = new Ray(transform.position, transform.forward);

		if(Physics.Raycast(PsychicRay, out hit, 1000f)){
			if(hit.collider.gameObject.tag == "RotatorCube") {
				hit.collider.gameObject.GetComponent<RotateCube>().startRotation();
			}
		}
		Debug.DrawRay(transform.position, transform.forward * 1000f);
	}
}
