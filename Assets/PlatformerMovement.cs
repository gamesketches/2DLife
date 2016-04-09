using UnityEngine;
using System.Collections;

public class PlatformerMovement : MonoBehaviour {

	CharacterController controller;
	public bool GravityY = true;
	private Vector3 jumpVector;
	private float movement;
	public float jumpSpeed;
	public Camera otherCamera;
	public Camera thisCamera;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		movement = 0;
		if(!GravityY) {
			/*Vector3 newPosition = new Vector3(gameObject.transform.position.x,
										gameObject.transform.position.y + 7f,
										gameObject.transform.position.z);

			gameObject.transform.position = newPosition;*/
			gameObject.transform.Rotate(-34f, 0f, -90f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		float hori = Input.GetAxis("Horizontal");
		float vert = Input.GetAxis("Vertical");

		//controller.Move(transform.forward * vert * Time.deltaTime * 10.0f);
		if(GravityY) {
			Vector3 moveVector = (vert * Camera.main.transform.forward * Time.deltaTime * 2f + Physics.gravity);
			controller.Move(moveVector + jumpVector);
			movement+= moveVector.z;
			if(!controller.isGrounded) {
				jumpVector.y -= 1f * Time.deltaTime;
			}
			else {
				jumpVector.y = 0f;
			}
			if(Input.GetKeyDown(KeyCode.Space) && jumpVector.y <= 0) {
				jumpVector.y = jumpSpeed;
			}
		}
		else {
			Vector3 moveVector = (transform.forward * vert * Time.deltaTime * 10.0f);
			controller.Move(moveVector);
			transform.Rotate(0f, hori * 2f, 0f);
			movement += moveVector.z;
			Debug.Log(movement);
		}

		if(Input.GetKeyDown(KeyCode.E)){
			otherCamera.enabled = true;
			Vector3 mainBody = otherCamera.transform.parent.gameObject.transform.position;
			mainBody.z += movement / 2;
			otherCamera.transform.parent.gameObject.transform.position = mainBody;
			thisCamera.enabled = false;
		}
	}
}
