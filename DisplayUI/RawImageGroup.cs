using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RawImageGroup : MonoBehaviour {

    public Texture[] TextureTorawImages;
    public GameObject Monitor;
    public static bool End = false;

    private int index = 0;
    
	// Use this for initialization
	void Start () {
        
	}

    public void NextPage()
    {
        if(index == TextureTorawImages.Length)
        {
            index = 0;
            End = true;
        }
        Monitor.transform.GetComponent<RawImage>().texture = TextureTorawImages[index++];
    }

	// Update is called once per frame
	void Update () {
		
	}
}
