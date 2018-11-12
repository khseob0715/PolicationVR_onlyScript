using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDisplayUI : MonoBehaviour {

	private SteamVR_TrackedObject trackedObj;
	// right controller application Button Press

	public static GameObject DisplayUI;


	public static bool bGameDisplayUI = true;

	private SteamVR_Controller.Device Controller {
		get {
			return SteamVR_Controller.Input ((int)trackedObj.index);
		}
	}

	void Awake ()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}

	// Use this for initialization
	void Start () {
		DisplayUI = GameObject.Find ("GameDisplayUI");
		DisplayUI.SetActive (false);
		bGameDisplayUI = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Controller.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu)){
			if (!SettingDisplay.SettingDisplayUI_active && !PaperDisplay.Display && !bGameDisplayUI) {
				DisplayUI.SetActive (true);
				bGameDisplayUI = !bGameDisplayUI;
			} else {
				DisplayUI.SetActive (false);
				bGameDisplayUI = !bGameDisplayUI;
			}

		}
        if (bGameDisplayUI)
        {
            //Debug.Log ("Open");
            DisplayUI.SetActive(true);
            if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                Vector2 touchPadAxis = Controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);

                if (touchPadAxis.y < -0.7f)
                {
                    scrollvaluechange.DownPress = true;
                }
                else if (touchPadAxis.y > 0.7f)
                {
                    scrollvaluechange.UpPress = true;
                }
                else if (touchPadAxis.x < -0.7f && LaserPointer.notChangeUI == false)
                {
                    if (ItemSelect.Item_detail_active)
                    {
                        ItemSelect.Item_detail_active = false;
                        ItemSelect.AllItemScroll_active = true;
                    }
                    if (UIProfileSelect.ProfileDetail_active)
                    {
                        UIProfileSelect.ProfileDetail_active = false;
                        UIProfileSelect.AllProfile_active = true;
                    }
                }
            }
            else{
                scrollvaluechange.DownPress = false;
                scrollvaluechange.UpPress = false;
            }
        }
        else{
            DisplayUI.SetActive(false);
        }
	}
}
