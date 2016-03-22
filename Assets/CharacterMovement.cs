using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	CharacterController controller;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		float hori = Input.GetAxis("Horizontal");
		float vert = Input.GetAxis("Vertical");

		controller.Move(transform.forward * vert * Time.deltaTime * 10.0f);
		transform.Rotate(0f, hori * 2f, 0f);
	}
}
