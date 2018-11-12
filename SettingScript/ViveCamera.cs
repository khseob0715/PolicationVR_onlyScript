using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveCamera : MonoBehaviour {

	private SteamVR_TrackedObject trackedObj;

	private SteamVR_Controller.Device Controller {
		get{ return SteamVR_Controller.Input ((int)trackedObj.index); }
	}

	void Awake ()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject> ();


	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Controller.GetPressDown (SteamVR_Controller.ButtonMask.Touchpad)) { 
			Debug.Log("camera on");
			if (VivePlayerUserScript.collidingObject != null) {
				if (VivePlayerUserScript.collidingObject.CompareTag ("Evidence")) {
					transform.GetComponent<SceneEvidence> ().DisplayItem (VivePlayerUserScript.collidingObject);
				
				} else {
					Debug.Log ("this is not evidence");
				}
			}
		}
	}
}
