using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScriptWithZombie : MonoBehaviour {

	public bool openZ = false;
	public bool Zombie = false;
	public float LdoorOpenAngleZ;
	public float RdoorOpenAngleZ;
	public float smooth = 1.5f;

	public GameObject zombieObject;
	public GameObject LDoor;
	public GameObject RDoor;

	void Start () 
	{
		
	}


	public void ChangeDoorStateZombie()
	{
		openZ = !openZ;
		zombieObject.SetActive (true);
		Zombie = true;
	}

	void Update () 
	{

		if (Zombie) {
			zombieObject.GetComponent<Animator>().enabled = true;
		}

		if(openZ) //open == true
		{
			Quaternion targetRotationL = Quaternion.Euler(0, 0, LdoorOpenAngleZ);
			Quaternion targetRotationR = Quaternion.Euler(0, 0, RdoorOpenAngleZ);

			LDoor.transform.localRotation = Quaternion.Slerp(LDoor.transform.localRotation, targetRotationL, smooth * Time.deltaTime);
			RDoor.transform.localRotation = Quaternion.Slerp(RDoor.transform.localRotation, targetRotationR, smooth * Time.deltaTime);

		}

	}
}
