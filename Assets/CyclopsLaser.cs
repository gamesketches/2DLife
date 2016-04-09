using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class CyclopsLaser : MonoBehaviour {

	public float rayLength;
	GameObject lastLookedAt;
	public Camera otherCamera;
	public Camera thisCamera;
	// Use this for initialization
	void Start () {
		otherCamera.enabled = false;
		thisCamera.enabled = true;
		VRSettings.renderScale = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray PsychicRay = new Ray(transform.position, transform.forward);

		if(Physics.Raycast(PsychicRay, out hit, rayLength)){
			if(hit.collider.gameObject.tag == "Painting" && 
				Input.GetKeyDown(KeyCode.E)) {
				otherCamera.enabled = true;
				thisCamera.enabled = false;
				gameObject.transform.parent.transform.Rotate(new Vector3(0, 180, 0));
			}
		}
		Debug.DrawRay(transform.position, transform.forward * rayLength);
	}
}
