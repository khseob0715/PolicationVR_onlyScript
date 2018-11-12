using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initanimationscript : MonoBehaviour {


	public float moveX;
	public float moveY;
	public float moveZ;

	public float smooth = 2f;

	public float disableScript = 30f;
	public float time = 0f;
	public bool scriptactive = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (scriptactive) {
			Vector3 tagetPosition = new Vector3 (moveX, moveY, moveZ);
			transform.position = Vector3.Lerp (transform.position, tagetPosition, smooth * Time.deltaTime);
			time += Time.deltaTime;
		}

		if (disableScript < time) {
			scriptactive = false;
		}
	}
}
