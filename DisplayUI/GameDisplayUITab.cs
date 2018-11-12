using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDisplayUITab : MonoBehaviour {

	public static GameObject Tab01UI;
	public static GameObject Tab02UI;
	public static GameObject Tab03UI;

	public static GameObject Tab01Group;
	public static GameObject Tab02Group;
	public static GameObject Tab03Group;


	//public static bool bTab01 = true;
	//public static bool bTab02 = true;
	//public static bool bTab03 = true;

	// Use this for initialization
	void Start () {
		Tab01UI = GameObject.Find ("Tab01UI");
		Tab02UI = GameObject.Find ("Tab02UI");
		Tab03UI = GameObject.Find ("Tab03UI");
		Tab01Group = GameObject.Find ("Tab01Group");
		Tab02Group = GameObject.Find ("Tab02Group");
		Tab03Group = GameObject.Find ("Tab03Group");

		Tab01UI.SetActive (false);
		Tab02UI.SetActive (true);
		Tab03UI.SetActive (true);

		Tab01Group.SetActive(true);
		Tab02Group.SetActive(false);
		Tab03Group.SetActive(false);
	}

	public static void TabConvert(int num){
		switch (num) {
		case 1:
			Tab01UI.SetActive (false);
			Tab02UI.SetActive (true);
			Tab03UI.SetActive (true);
			Tab01Group.SetActive(true);
			Tab02Group.SetActive(false);
			Tab03Group.SetActive(false);
			break;
		case 2:
			Tab01UI.SetActive (true);
			Tab02UI.SetActive (false);
			Tab03UI.SetActive (true);
			Tab01Group.SetActive(false);
			Tab02Group.SetActive(true);
			Tab03Group.SetActive(false);
			break;
		case 3:
			Tab01UI.SetActive (true);
			Tab02UI.SetActive (true);
			Tab03UI.SetActive (false);
			Tab01Group.SetActive(false);
			Tab02Group.SetActive(false);
			Tab03Group.SetActive(true);
			break;

		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
