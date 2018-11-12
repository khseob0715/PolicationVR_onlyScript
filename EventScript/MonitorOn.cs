using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorOn : MonoBehaviour {

	private bool OnOff = false;
	public GameObject LCD;
	public GameObject LCD2;
	public Material OnShader;
	public Material OffShader;

	public GameObject PointRight; 

	public Renderer rend;
	public Renderer rend2;

	private float blinkTime = 0.5f;
	private float checkTime = 0.0f;
	private bool blink = false;

    public GameObject AnimationDisplay;
    public GameObject blinkMouse;

	// Use this for initialization
	void Start () {
		rend = LCD.GetComponent<Renderer> ();
		rend2 = LCD2.GetComponent<Renderer> ();
	}

	public void turnOnScreen(){
		OnOff = !OnOff;
		
	}
	// Update is called once per frame
	void Update () {

		checkTime += Time.deltaTime;
		if (checkTime > blinkTime) {
			PointRight.SetActive (blink);
			blink = !blink;
			checkTime = 0.0f;
		}

		if (OnOff) 
		{
			rend.material = OnShader;
			rend2.material = OnShader;
            AnimationDisplay.SetActive(true);
            blinkMouse.SetActive(true);

        } 
		else 
		{
			rend.material = OffShader;
			rend2.material = OffShader;
            AnimationDisplay.SetActive(false);
            blinkMouse.SetActive(false);
        }
	}
}
