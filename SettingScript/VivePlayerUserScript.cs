using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VivePlayerUserScript : MonoBehaviour
{

	private SteamVR_TrackedObject trackedObj;

	public static GameObject collidingObject;
	private GameObject objectInHand;

	private bool SmartPhone_Grab = false;
	private bool TouchDown_set = false;

	private GameObject SmartPhoneObject;

	public GameObject Effect;

	public GameObject ArrowEffect;

	private SteamVR_Controller.Device Controller {
		get{ return SteamVR_Controller.Input ((int)trackedObj.index); }
	}

    public bool Current_tutorial = false;

	void Awake ()
	{
		ArrowEffect.SetActive (false);
		trackedObj = GetComponent<SteamVR_TrackedObject> ();

        //	DontDestroyOnLoad (this.gameObject);
        if (this.GetComponent<Tutorial_explain>())
        {
            Current_tutorial = true;
        }
	}

	private void SetCollidingObject (Collider col)
	{
		if (collidingObject || !col.GetComponent<Rigidbody> ()) {
			return;
		}

		collidingObject = col.gameObject;
	}


	public void OnTriggerEnter (Collider other)
	{ 
		// trigger collier가 다른 collider에 진입했을 때 collider를 움직일 수 있는 잠재적 타겟으로 설정 
		SetCollidingObject (other);
	}

	public void OnTriggerStay (Collider other)
	{
		SetCollidingObject (other);
	}

	public void OnTriggerExit (Collider other)
	{
		if (!collidingObject) {
			return; 
		}
		collidingObject = null;
	}

	private void GrabObject ()
	{
		objectInHand = collidingObject;
		collidingObject = null; 

		var joint = AddFixedJoint ();
		joint.connectedBody = objectInHand.GetComponent<Rigidbody> ();
	}

	private FixedJoint AddFixedJoint ()
	{
		FixedJoint fx = gameObject.AddComponent<FixedJoint> ();
		fx.breakForce = 20000;
		fx.breakTorque = 20000;
		return fx;
	}

	private void ReleaseObject ()
	{
		if (GetComponent<FixedJoint> ()) {
			GetComponent<FixedJoint> ().connectedBody = null;
			Destroy (GetComponent<FixedJoint> ());

			objectInHand.GetComponent<Rigidbody> ().velocity = Controller.velocity;
			objectInHand.GetComponent<Rigidbody> ().angularVelocity = Controller.angularVelocity;
		}

		objectInHand = null;
	}


	// Update is called once per frame
	void Update ()
	{
		Vector2 touchDown = new Vector2 (0.0f, 0.0f);

		if (!TouchDown_set && SmartPhone_Grab && Controller.GetTouchDown (SteamVR_Controller.ButtonMask.Touchpad)) { // 터치패드를 왼쪽에서 오른쪽으로 가면 
			TouchDown_set = true;
			touchDown = Controller.GetAxis (Valve.VR.EVRButtonId.k_EButton_Axis0);
			Debug.Log ("TouchDown" + touchDown.x + "x  y" +touchDown.y);
			if (touchDown.x > 0.0f) {
				SmartPhoneObject.transform.GetComponent<PhoneSlide> ().slide (1);
			} else if(touchDown.x < 0.0f){
				SmartPhoneObject.transform.GetComponent<PhoneSlide> ().slide (-1);
			}
		} else if(TouchDown_set && SmartPhone_Grab && Controller.GetTouchUp (SteamVR_Controller.ButtonMask.Touchpad)) { // 터치패드를 왼쪽에서 오른쪽으로 가면 {
			TouchDown_set = false;
		}


		if (Controller.GetHairTriggerDown()) {
			if (collidingObject) {

				if (collidingObject.CompareTag ("Evidence")) {
					// 집었을 때 증거일 경우 바로 찾아 들어 감
					this.transform.parent.GetComponentInChildren<SceneEvidence>().DisplayItem (collidingObject);
					GameObject EffectEvidence = Instantiate (Effect,this.transform.position, this.transform.rotation);
					Destroy (EffectEvidence, 1.0f);  // 증거물 이펙트 표시. 
                    if (Current_tutorial) //  현재가 튜토리얼 씬이라면! 
                    {
                        if (collidingObject.name == "Evi0")
                        {
                            this.GetComponent<Tutorial_explain>().index++;
                        }
                        this.GetComponent<Tutorial_explain>().count++;
                    }
                    GrabObject(); // 증거물이지만 들어볼 수는 있어야지!! 
				}
                else if (collidingObject.CompareTag("Door"))
                {
                    // 문 열기 
                    collidingObject.transform.parent.GetComponent<DoorScript>().ChangeDoorState();
                    //
                }else if (collidingObject.CompareTag("DoorY"))
                {
                    collidingObject.transform.parent.GetComponent<DoorScriptY>().ChangeDoorStateY();
                }
                else if (collidingObject.CompareTag("DoorZ"))
                {
                    // Z 축으로 문열기 
                    collidingObject.transform.parent.GetComponent<DoorScriptZ>().ChangeDoorStateZ();
                    // 
                }
                else if (collidingObject.CompareTag("Drawer"))
                {
                    // 서랍 열기 
                    collidingObject.transform.GetComponent<DrawerScript>().ChangeDrawerState();
                    //
                }
                else if (collidingObject.CompareTag("ItemPaper"))
                {

                    GameObject EffectEvidence = Instantiate(Effect, this.transform.position, this.transform.rotation);
                    Destroy(EffectEvidence, 1.0f);  // 증거물 이펙트 표시. 

                    // 문서 증거 물 
                    PaperDisplay.Display = true;

                    // Item Display change script
                    this.transform.parent.GetComponentInChildren<SceneEvidence>().DisplayItem(collidingObject);

                    // Paper Display change script
                    Texture paperTexture = collidingObject.transform.GetComponent<RawImage>().texture;
                    this.transform.GetComponent<PaperDisplay>().turnDisplay(paperTexture);

                }
                else if (collidingObject.CompareTag("SmartPhone"))
                {
                    this.transform.parent.GetComponentInChildren<SceneEvidence>().DisplayItem(collidingObject); // 스마트폰이 증거 수집 UI에 반영됨. 
                    SmartPhoneObject = collidingObject;
                    SmartPhoneObject.transform.localScale = new Vector3(3, 3, 3);
                    ArrowEffect.SetActive(true);
                    GrabObject();

                    SmartPhone_Grab = true;
                }
                else if (collidingObject.CompareTag("Diary"))
                {
                    this.transform.parent.GetComponentInChildren<SceneEvidence>().DisplayItem(collidingObject); // Diary가 증거 수집 UI에 반영됨. 
                    // this는 vive controller
                    
                    collidingObject.GetComponent<DiaryOpen>().TouchCount();


                }
                else { 
                    switch (collidingObject.name)
                    {
                        case "Closet_Door_R_Zombie":
                        case "Closet_Door_L_Zombie":
                            collidingObject.transform.parent.GetComponent<DoorScriptWithZombie>().ChangeDoorStateZombie();
                            break;
                        case "CorkBoard":
                            collidingObject.transform.parent.GetComponent<ThrowItem>().HitCount();
                            break;
                        case "PC":
                            collidingObject.transform.GetComponent<MonitorOn>().turnOnScreen();
                            break;
                        case "Room3Board":
                            collidingObject.transform.parent.GetComponent<Rotation>().RotationBoard();
                            break;
                        case "Mouse":
                            if (RawImageGroup.End)
                            {
                                this.transform.parent.GetComponentInChildren<SceneEvidence>().DisplayItem(collidingObject.transform.GetChild(0).gameObject);
                                RawImageGroup.End = false;
                            }
                            collidingObject.transform.GetComponent<RawImageGroup>().NextPage();
                            break;
                        case "Laptop":
                            DispalyLaptopMonitor.LaptopMonitorActive = !DispalyLaptopMonitor.LaptopMonitorActive;
                            collidingObject.transform.GetComponent<DispalyLaptopMonitor>().DisplayLaptop(DispalyLaptopMonitor.LaptopMonitorActive);
                            break;
                        case "FileTop":
                            collidingObject.transform.parent.GetComponent<Animation>().Play();
                            break;
                        default:
                            Debug.Log("grab");
                            GrabObject();
                            break;
                    }
                }
            }
		}


		if (Controller.GetHairTriggerUp ()) {
			Debug.Log ("grab release");
			if (SmartPhone_Grab) {
				SmartPhone_Grab = false;
				SmartPhoneObject.transform.localScale = new Vector3 (1, 1, 1);
				ArrowEffect.SetActive (false);
			}
			if (objectInHand) {
				ReleaseObject ();
			}
		}
	}
}
