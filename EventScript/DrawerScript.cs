using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerScript : MonoBehaviour {


	private bool open = false;
	public float OpenDrawerX;
	public float OpenDrawerY;
	public float OpenDrawerZ;

	public float CloseDrawerX;
	public float CloseDrawerY;
	public float CloseDrawerZ;

	public float smooth = 2f;


	// Use this for initialization
	void Start () {
		
	}


	public void ChangeDrawerState()
	{
		Debug.Log ("Hit Open");
		open = !open;

	}

	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown("0"))
        {
            open = !open;
        }
		if(open) //open == true
		{
			Vector3 tagetPosition = new Vector3(OpenDrawerX, OpenDrawerY, OpenDrawerZ);
			transform.position = Vector3.Lerp(transform.position, tagetPosition, smooth*Time.deltaTime);

		}
		else
		{
			Vector3 tagetPosition = new Vector3(CloseDrawerX, CloseDrawerY, CloseDrawerZ);
			transform.position = Vector3.Lerp(transform.position, tagetPosition, smooth*Time.deltaTime);
		}
	}
}
