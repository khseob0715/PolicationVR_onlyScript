using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowItem : MonoBehaviour {

	public GameObject CorkBoard;
	public GameObject ItemPaper;

	public float UpperZ;
	public float smooth;

	private int hitCount = 0;

	private float delayTime = 0.0f;

	private bool oneTime = true;
	void Start () {

	}

	public void HitCount(){
		hitCount++;
	}

	// Update is called once per frame
	void Update () {
        if (delayTime >= 3.0f && oneTime) {
			ItemPaper.SetActive (false);
			oneTime = false;
		} else{

			delayTime += Time.deltaTime;
		}

		if (hitCount == 1) {
            //			Quaternion targetRotation = Quaternion.Euler (-120, 90, 0);
            Quaternion targetRotation = Quaternion.Euler(-120, 90, 0);
            transform.localRotation = Quaternion.Slerp (transform.localRotation, targetRotation, smooth * Time.deltaTime);
		}

		if (hitCount == 2) {
            //Quaternion targetRotation = Quaternion.Euler (-60, 90, 0);
            Quaternion targetRotation = Quaternion.Euler(-60, 90, 0);
            transform.localRotation = Quaternion.Slerp (transform.localRotation, targetRotation, smooth * Time.deltaTime);
		}

		if (hitCount == 3) {
            //			Quaternion targetRotation = Quaternion.Euler (-90, 90, 0);
            Quaternion targetRotation = Quaternion.Euler(-90, 90, 0);
            transform.localRotation = Quaternion.Slerp (transform.localRotation, targetRotation, smooth * Time.deltaTime);
			ItemPaper.transform.GetComponent<Rigidbody> ().useGravity = true;
			ItemPaper.SetActive (true);
		}
	}
}
