using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputConvert : MonoBehaviour {

    private bool ViveInput = true;
    public GameObject CameraSetting;

    private Camera TargetEye;

	// Use this for initialization
	void Start () {
        TargetEye = CameraSetting.GetComponent<Camera>();
	}

    public void Select_Vive()
    {
        ViveInput = true;
    }

    public void Select_KeyBoard()
    {
        ViveInput = false;
    }
	
	// Update is called once per frame
	void Update () {


        if (ViveInput) // vive input
        {
            TargetEye.stereoTargetEye = StereoTargetEyeMask.Both;
        }
        else // keyboard input
        {
            TargetEye.stereoTargetEye = StereoTargetEyeMask.None;
            // Both 에서 None으로 바꾸면 컴퓨터 화면에서 키보드 입력을 받을 수 있음. 
        }
	}
}
