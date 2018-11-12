using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneSlide : MonoBehaviour {

	public Material[] PhoneDisplayMaterial; 

	private Material[] origin;

	private int index = 0;




	// private Renderer rend;
	// Use this for initialization
	void Start () {
		//rend = this.GetComponent<Renderer> ();
		origin = this.GetComponent<Renderer> ().materials;
	}

	public void slide(int RL){		
		if (RL == 1) {
			Debug.Log ("Right");
			index++;
		} else {
			Debug.Log ("Left");
			index--;
		}

		if (index == PhoneDisplayMaterial.Length) {
			index = 0;
		}

		if (index == -1) {
			index = PhoneDisplayMaterial.Length - 1;
		}

		Debug.Log ("index:" + index);

		origin[1] = PhoneDisplayMaterial[index];
		this.GetComponent<Renderer> ().materials = origin;
	
	}


	// Update is called once per frame
	void Update () {
		
	}
}
