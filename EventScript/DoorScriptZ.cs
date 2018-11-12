using UnityEngine;
using System.Collections;

public class DoorScriptZ : MonoBehaviour {

	public bool openZ = false;
	public float doorOpenAngleZ = 90f;
	public float doorCloseAngleZ = 0f;
	public float smooth = 2f;

	void Start () 
	{

	}


	public void ChangeDoorStateZ()
	{
		openZ = !openZ;
	}

	void Update () 
	{
		
		if(openZ) //open == true
		{
			Quaternion targetRotation = Quaternion.Euler(0, 0, doorOpenAngleZ);
			transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
		}
		else
		{
			Quaternion targetRotation2 = Quaternion.Euler(0, 0, doorCloseAngleZ);
			transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, smooth * Time.deltaTime);
		}
	}
}
