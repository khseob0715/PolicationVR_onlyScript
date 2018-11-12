using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scrollvaluechange : MonoBehaviour {
	Scrollbar bar;
	// Use this for initialization
	public static bool DownPress = false; 
	public static bool UpPress = false; 
	public float scrollValue = 0.01f;
	void Start () {
		bar = gameObject.GetComponent<Scrollbar> ();
		bar.value = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (DownPress) {
			if (bar.value > 0.0f) {
				bar.value -= scrollValue;
			}
		}

		if (UpPress) {
			if (bar.value < 1.0f) {
				bar.value += scrollValue;
			}
		}

	}
}
