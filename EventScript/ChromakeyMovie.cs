using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChromakeyMovie : MonoBehaviour {
	public MovieTexture movie;
	private float delayTime = 3.0f;
	private float time = 0.0f;
	void Start () {

		GetComponent<Renderer>().material.mainTexture = movie;

		movie.loop = false;
		transform.GetComponent<MeshRenderer> ().enabled = false;
	}

	void Update () {   
		if (delayTime < time) {
			movie.Play ();
			transform.GetComponent<MeshRenderer> ().enabled = true;
		} else {
			time += Time.deltaTime;
		}
	}
		
}
