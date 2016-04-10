using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	CharacterController controller;
	public Camera camera;
	public GameObject scene;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
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
		if(Input.GetKeyDown(KeyCode.E)) {
			scene.transform.localScale = new Vector3(2f, 2f, 2f);
		}
		else if(Input.GetKeyDown(KeyCode.Q)) {
			scene.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
		}
	}
}
