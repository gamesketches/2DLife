using UnityEngine;
using System.Collections;

public class RayCastColor : MonoBehaviour {

	Renderer myRenderer;
	Light light;
	// Use this for initialization
	void Start () {
		myRenderer = GetComponent<Renderer>();
		light = gameObject.transform.parent.gameObject.GetComponentInChildren<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray PsychicRay = new Ray(transform.position, transform.forward);

		if(Physics.Raycast(PsychicRay, out hit, 100f)){
			myRenderer.material.color = hit.collider.gameObject.GetComponent<Renderer>().material.color;
			light.intensity = 1f - (hit.distance / 30f);
		}
		Debug.DrawRay(transform.position, transform.forward * 100f);
	}
}
