using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour {
	private RaycastHit hit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = new Ray (this.transform.position, this.transform.forward * 10.0f);

		if (Physics.Raycast (ray, out hit, 10.0f)) {
			if (hit.collider.gameObject.name.Equals("Video")) {
				
			}
		}
	}
}
