using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperDisplay : MonoBehaviour {

	public GameObject PaperCanvas;
	public GameObject PaperTexture;

	// Use this for initialization
	public static bool Display = false;
	void Start () {
		PaperCanvas.SetActive (false);
	}

	public void turnDisplay(Texture paperTexture){
		if (Display) {
			PaperTexture.transform.GetComponent<RectTransform> ().sizeDelta = new Vector2 (paperTexture.width, paperTexture.height);
			PaperTexture.transform.GetComponent<RawImage> ().texture = paperTexture;
			PaperCanvas.SetActive (Display);

		} else {
			PaperCanvas.SetActive (Display);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
