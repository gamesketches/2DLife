using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	CharacterController controller;
	Camera camera;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if(!camera.enabled) {
			return;
		}
		float hori = Input.GetAxis("Horizontal");
		float vert = Input.GetAxis("Vertical");

		controller.Move(transform.forward * vert * Time.deltaTime * 10.0f);
		transform.Rotate(0f, hori * 2f, 0f);
	}
}
