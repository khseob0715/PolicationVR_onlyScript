using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionButton : MonoBehaviour {
	public static GameObject QuestionProfile;
	public static bool QuestionProfile_active = false;
	// Use this for initialization
	void Start () {
		QuestionProfile = GameObject.Find ("QuestionProfile");
		QuestionProfile.SetActive (false);
		QuestionProfile_active = false;
	}

	public static void ProfileDisplay(){
		if (QuestionProfile_active) {
			QuestionProfile.SetActive (true);
			QuestionProfile_active = true;
		} else {
			QuestionProfile.SetActive (false);
			QuestionProfile_active = false;
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
