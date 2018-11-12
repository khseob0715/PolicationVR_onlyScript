using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingDisplay : MonoBehaviour {

    public GameObject SettingDisplayUI;
    public static bool SettingDisplayUI_active = false;
    private SteamVR_TrackedObject trackedObj;

    public GameObject InputEmailUI;
    public GameObject PointUI;
    public GameObject ResultUI;
    public GameObject PointUI_Dialog;
    public GameObject ResultUI_Dialog;
    public GameObject ResultUI_Dialog2;
    public GameObject TeamKimUI;

    public static bool InputEmailUI_active = false;
    public static bool PointUI_active = true;
    public static bool ResultUI_active = false;
    public static bool PointUI_Dialog_active = false;
    public static bool ResultUI_Dialog_active = false;
    public static bool ResultUI_Dialog_active2 = false;
    public static bool TeamKim_active = false;


    private SteamVR_Controller.Device Controller
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedObj.index);
        }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        SettingDisplayUI.SetActive(SettingDisplayUI_active);
    }


    // Use this for initialization
    void Start () {
		
	}
	

	// Update is called once per frame
	void Update () {
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            // blur 처리
            // SettingDisplayUI 활성화 
            SettingDisplayUI_active = !SettingDisplayUI_active;
            SettingDisplayUI.SetActive(SettingDisplayUI_active);
        }

        InputEmailUI.SetActive(InputEmailUI_active);
        PointUI.SetActive(PointUI_active);
        ResultUI.SetActive(ResultUI_active);
        PointUI_Dialog.SetActive(PointUI_Dialog_active);
        SettingDisplayUI.SetActive(SettingDisplayUI_active);
        ResultUI_Dialog.SetActive(ResultUI_Dialog_active);
        ResultUI_Dialog2.SetActive(ResultUI_Dialog_active2);
        TeamKimUI.SetActive(TeamKim_active);
    }
}
