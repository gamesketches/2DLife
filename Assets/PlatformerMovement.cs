using UnityEngine;
using System.Collections;

public class PlatformerMovement : MonoBehaviour {

	CharacterController controller;
	public bool GravityY = true;
	private Vector3 jumpVector;
	public float jumpSpeed;
	public Camera otherCamera;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		float hori = Input.GetAxis("Horizontal");
		float vert = Input.GetAxis("Vertical");

		//controller.Move(transform.forward * vert * Time.deltaTime * 10.0f);
		if(GravityY) {
			Vector3 moveVector = (vert * Camera.main.transform.forward * Time.deltaTime * 2f + Physics.gravity);
			controller.Move(moveVector + jumpVector);
			if(Input.GetKeyDown(KeyCode.Space) && jumpVector.y <= 0) {
				jumpVector.y = jumpSpeed;
				//Debug.Log(jumpVector.y);
			}
			if(!controller.isGrounded) {
				jumpVector.y -= 1f * Time.deltaTime;
			}
		}
		else {
			controller.Move(transform.forward * vert * Time.deltaTime * 10.0f);
			transform.Rotate(0f, hori * 2f, 0f);
		}

		if(Input.GetKeyDown(KeyCode.E)){
			Debug.Log("Back to 3d space");
		}
	}
}
