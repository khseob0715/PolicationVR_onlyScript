using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RooomSelect : MonoBehaviour {
	public GameObject[] Room;
	public GameObject ViveController;

    public string[] SceneName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeRoom(GameObject hitObject){
		string hitObjectName = hitObject.name;
		int index = 0;
		for (int i = 0; i < Room.Length; i++) {
			if (hitObject.name == Room [i].name) {
				index = i;
				break;
			}
		}
		switch (index) {
		case 0:
			ViveController.transform.position = new Vector3 (2.0f, 0.0f, 0.0f);
			SceneManager.LoadScene (SceneName[0]);
			break;
		case 1:
			ViveController.transform.position = new Vector3 (0.0f, 0.0f, 0.0f);
			SceneManager.LoadScene (SceneName[1]);
			break;
		case 2:
			ViveController.transform.position = new Vector3 (0.0f, 0.0f, 0.0f);
			SceneManager.LoadScene (SceneName[2]);
			break;
		case 3:
			ViveController.transform.position = new Vector3 (1.66f, 0.0f, -2.0f);
			SceneManager.LoadScene (SceneName[3]);
			break;
		case 4:
			ViveController.transform.position = new Vector3 (0.58f, 0.0f, -2.17f);
			SceneManager.LoadScene (SceneName[4]);
			break;
		case 5:
			ViveController.transform.position = new Vector3 (0.837f, 0.0f, -1.75f);
			SceneManager.LoadScene (SceneName[5]);
			break;
		case 6:
			ViveController.transform.position = new Vector3 (0.18f, 0.0f, 0.0f);
			SceneManager.LoadScene (SceneName[6]);
			break;
		case 7:
			ViveController.transform.position = new Vector3 (0.2f, 0.0f, 0.0f);
			SceneManager.LoadScene (SceneName[7]);
			break;
		}
	}
}
