using UnityEngine;
using System.Collections;

public class RayCastColor : MonoBehaviour {

	Renderer myRenderer;
	// Use this for initialization
	void Start () {
		myRenderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray PsychicRay = new Ray(transform.position, transform.forward);

		if(Physics.Raycast(PsychicRay, out hit, 400f)){
			myRenderer.material.color = hit.collider.gameObject.GetComponent<Renderer>().material.color;
		}
		Debug.DrawRay(transform.position, transform.forward * 100f);
	}
}
