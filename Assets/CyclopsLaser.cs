﻿using UnityEngine;
using System.Collections;

public class CyclopsLaser : MonoBehaviour {

	public float rayLength;
	GameObject lastLookedAt;
	public Camera otherCamera;
	public Camera thisCamera;
	// Use this for initialization
	void Start () {
		otherCamera.enabled = false;
		thisCamera.enabled = true;
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
			}
		}
		Debug.DrawRay(transform.position, transform.forward * rayLength);
	}
}