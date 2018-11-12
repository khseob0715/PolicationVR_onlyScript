using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroytest : MonoBehaviour {
	public static destroytest instance = null;
	// Use this for initialization
	void Start () {
		
	}

	void Awake(){
		if (instance != null) {
			Destroy (this.gameObject);
			return;
		}
		instance = this;
		DontDestroyOnLoad (this.gameObject);
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
