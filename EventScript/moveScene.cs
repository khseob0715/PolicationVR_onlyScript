using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveScene : MonoBehaviour {


	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		switch (this.name) {
		case "CubeScene01":
			SceneManager.LoadScene ("Dummy");
			break;
		case "CubeScene02":
			SceneManager.LoadScene ("Dummy2");
			break;
		case "CubeScene03":
			SceneManager.LoadScene ("Dummy3");
			break;
		case "Tutorial_CubeScene":
			SceneManager.LoadScene ("Tutorial");
			break;
		}

	}
}
