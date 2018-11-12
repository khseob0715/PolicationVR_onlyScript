using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneEvidence : MonoBehaviour {
	public GameObject Tab01Group; // Item Image Group;
	public static GameObject[] EvidenceObject;
	public static bool[] objectset; 
	public Texture[] EvidenceTexture;
	public static bool allocate = false;

	private int len; 
	// Use this for initialization
	void Start () {
		len = EvidenceObject.Length;
	}

	void Awake(){
		EvidenceObject = new GameObject[100];
		objectset = new bool[100];
//		DontDestroyOnLoad (this.gameObject);
	}


	public void allocateEvidence(){
		Debug.Log ("allocate");

		for (int i = 0; i < len; i++) {
			if (GameObject.Find ("Evi" + i) != null) {
				Debug.Log ("Evi" + i + "allocate object");
				EvidenceObject [i] = GameObject.Find ("Evi" + i);
				objectset [i] = true;
				Debug.Log (EvidenceObject [i].name);
			} else {
				objectset [i] = false;
			}
		}
	}


	public void DisplayItem(GameObject hitObject){
		string hitName = hitObject.name;
		Debug.Log ("DisplayItem(), hit : " + hitName);
		for (int i = 0; i < len; i++) {
			//Debug.Log (EvidenceObject [i].name);
			if (objectset [i] == true) {
				if (hitName == EvidenceObject [i].name) {
					GameObject item = Tab01Group.transform.GetComponent<ItemSelect> ().Item [i];
					item.transform.GetComponent<RawImage> ().texture = EvidenceTexture [i];
					ItemSelect.ItemFind [i] = true;
					break;
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {

		if (allocate) {
			allocateEvidence ();
			allocate = false;
		}
		
	}
}
