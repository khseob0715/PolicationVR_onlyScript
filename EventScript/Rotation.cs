using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {


	public float smooth = 2f;
	public float upTime = 2f;
	private float delayTime = 0f;

	private bool up = false;
	// Use this for initialization
	void Start () {
		
	}


	public void RotationBoard(){
		up = !up;
	}
	// Update is called once per frame
	void Update () {
		if (up) {
			Quaternion targetRotation = Quaternion.Euler (-60, 90, 0);
			transform.localRotation = Quaternion.Slerp (transform.localRotation, targetRotation, smooth * Time.deltaTime);
			delayTime += Time.deltaTime;
			if (delayTime > upTime) {
				up = !up;
				delayTime = 0f;
			}
		} else {
			Quaternion targetRotation = Quaternion.Euler (0, 90, 0);
			transform.localRotation = Quaternion.Slerp (transform.localRotation, targetRotation, smooth * Time.deltaTime);
		}

	}
}
