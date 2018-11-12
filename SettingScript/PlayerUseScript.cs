using UnityEngine;
using System.Collections;

public class PlayerUseScript : MonoBehaviour {

	public float interactDistance = 20f;
	void Start(){
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

	}
	void Update () 
	{

		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // so, i used a mouse raycast 
			RaycastHit hit;
            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                if (hit.collider.CompareTag("Door"))
                {
                    hit.collider.transform.parent.GetComponent<DoorScript>().ChangeDoorState();
                }

                if (hit.collider.CompareTag("DoorZ"))
                {
                    hit.collider.transform.parent.GetComponent<DoorScriptZ>().ChangeDoorStateZ();
                }

                if (hit.collider.CompareTag("DoorY"))
                {
                    hit.collider.transform.parent.GetComponent<DoorScriptY>().ChangeDoorStateY();
                }


                if (hit.collider.CompareTag("Drawer"))
                {
                    //Debug.Log ("hit");
                    hit.collider.transform.GetComponent<DrawerScript>().ChangeDrawerState();
                }

                if (hit.collider.gameObject == GameObject.Find("Closet_Door_R_Zombie"))
                {
                    hit.collider.transform.parent.GetComponent<DoorScriptWithZombie>().ChangeDoorStateZombie();
                }

                if (hit.collider.gameObject == GameObject.Find("Closet_Door_L_Zombie"))
                {
                    hit.collider.transform.parent.GetComponent<DoorScriptWithZombie>().ChangeDoorStateZombie();
                }

                if (hit.collider.gameObject == GameObject.Find("CorkBoard"))
                {
                    //Debug.Log ("hit");
                    hit.collider.transform.parent.GetComponent<ThrowItem>().HitCount();
                }

                if (hit.collider.gameObject == GameObject.Find("PC"))
                {
                    hit.collider.transform.GetComponent<MonitorOn>().turnOnScreen();
                }

                if (hit.collider.gameObject == GameObject.Find("Room3Board"))
                {
                    Debug.Log("hit");
                    hit.collider.transform.parent.GetComponent<Rotation>().RotationBoard();
                }

                if (hit.collider.CompareTag("Diary"))
                {
                    hit.collider.transform.GetComponent<DiaryOpen>().TouchCount();

                }

                if(hit.collider.gameObject == GameObject.Find("Laptop"))
                {
                    DispalyLaptopMonitor.LaptopMonitorActive = !DispalyLaptopMonitor.LaptopMonitorActive;
                    hit.collider.transform.GetComponent<DispalyLaptopMonitor>().DisplayLaptop(DispalyLaptopMonitor.LaptopMonitorActive);
                }

                if(hit.collider.gameObject == GameObject.Find("Mouse"))
                {
                    if (RawImageGroup.End)
                    {
                      //  this.transform.parent.GetComponentInChildren<SceneEvidence>().DisplayItem(hit.collider.gameObject.transform.GetChild(0).gameObject);
                        RawImageGroup.End = false;
                    }
                    hit.collider.gameObject.transform.GetComponent<RawImageGroup>().NextPage();
                }
            }
		}
	}
}
