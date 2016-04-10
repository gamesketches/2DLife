using UnityEngine;
using System.Collections;

public class RotateCube : MonoBehaviour {

	public GameObject parentObject;
	bool rotating = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator rotateEverybody() {
		Debug.Log("rotation started");
		for(int i = 0; i < 90; i++) {
			parentObject.transform.Rotate(new Vector3(0f, 0f, 1f));
			yield return null;
		}
		rotating = false;
	}

	public void startRotation() {
		if(!rotating) {
			rotating = true;
			StartCoroutine(rotateEverybody());
		}
	}
		
}
