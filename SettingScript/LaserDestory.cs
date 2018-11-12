using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDestory : MonoBehaviour {

	public static LaserDestory Laserinstance = null;
	// Use this for initialization
	void Start () {

	}

	void Awake(){
		DontDestroyOnLoad (this.gameObject);
	}


	// Update is called once per frame
	void Update () {

	}
}
