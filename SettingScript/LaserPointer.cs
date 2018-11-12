using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserPointer : MonoBehaviour
{

    private SteamVR_TrackedObject trackedObj;

    public static GameObject laserPrefab;
    public static GameObject laser;
    public static GameObject RightControllerLaser;
    public static GameObject teleportReticlePrefab;

    private Transform laserTransform;
    private Vector3 hitPoint;

    public Transform cameraRigTransform;

    private GameObject reticle;
    private Transform teleportReticleTransform;
    public Transform headTransform;

    public Vector3 teleportReticleOffset;
    public LayerMask teleportMask;
    public LayerMask UIMask;

    private bool shouldTeleport;

    public static bool notChangeUI = false;

    private string IsEmail = ""; // 입력받은 Email 값 저장. 

    public GameObject PaperEvidecneScript; 

    private SteamVR_Controller.Device Controller
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedObj.index);
        }
    }

    private void ShowLaser(RaycastHit hit)
    {
        laser.SetActive(true);
        laserTransform.position = Vector3.Lerp(trackedObj.transform.position, hitPoint, 0.5f);
        laserTransform.LookAt(hitPoint);
        laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y, hit.distance);
    }

    private void Teleport()
    {
        shouldTeleport = false;
        reticle.SetActive(false);
        Vector3 difference = cameraRigTransform.position - headTransform.position;
        difference.y = 0;
        cameraRigTransform.position = hitPoint + difference;
    }

    // Use this for initialization
    void Start()
    {
        //GameOjbect Find
        laserPrefab = GameObject.Find("Laser");
        teleportReticlePrefab = GameObject.Find("TeleportDestination");
        RightControllerLaser = GameObject.Find("RightControllerLaser");

        //laser = Instantiate (laserPrefab);
        laser = laserPrefab;
        laserTransform = laser.transform;

        //reticle = Instantiate (teleportReticlePrefab);
        reticle = teleportReticlePrefab;
        teleportReticleTransform = reticle.transform;
        RightControllerLaser.SetActive(false);
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PaperDisplay.Display && !GameDisplayUI.bGameDisplayUI && !SettingDisplay.SettingDisplayUI_active && !ViewPaperEvidence.bEvidencePaperDisplay)
        {
            // 어떠한 UI도 active status가 No라면, teleport가 active able status이다. 
            RightControllerLaser.SetActive(false);
            if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad) && shouldTeleport)
            {
                Teleport();
            }

            if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                RaycastHit hit;
                if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 100, teleportMask))
                {
                    hitPoint = hit.point;
                    ShowLaser(hit);

                    reticle.SetActive(true);
                    teleportReticleTransform.position = hitPoint + teleportReticleOffset;
                    shouldTeleport = true;
                }
            }
            else
            {
                laser.SetActive(false);
                reticle.SetActive(false);
            }
        }
        else if (ViewPaperEvidence.bEvidencePaperDisplay)
        {
            laser.SetActive(false);
            //GameDisplayUI.bGameDisplayUI = false;
            if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                PaperEvidecneScript.transform.GetComponent<ViewPaperEvidence>().NextEvidence();
                notChangeUI = true;
                Vector2 touchPadAxis = Controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);

                if (touchPadAxis.x < -0.7f)
                {
                   
                    PaperEvidecneScript.transform.GetComponent<ViewPaperEvidence>().EvidencePaperDisplay(0);
                    
                }
                
            }
        }
        else if (PaperDisplay.Display)
        {
            if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
            {
                PaperDisplay.Display = false;
                Debug.Log("button mask touch pad");
                this.transform.GetComponent<PaperDisplay>().turnDisplay(null);
            }
        }
        else if (SettingDisplay.SettingDisplayUI_active)
        {
            GameDisplayUI.bGameDisplayUI = false;
            RaycastHit hit;
            GameObject MainButtonText = GameObject.Find("MainButton");

            RightControllerLaser.SetActive(true); // 일단 키고 
            if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                RightControllerLaser.SetActive(false); // 다시 끈 다음에 UIMask에 충돌이 들어오면 해당 오브젝트와의 거리와 맞춰 재 생성.
                if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 100, UIMask))
                {
                    hitPoint = hit.point;
                    ShowLaser(hit);

                    GameObject Pointed_Profile;

                    if (hit.collider.CompareTag("Keyboard"))
                    {
                        hit.collider.transform.parent.parent.GetComponent<InputEmail>().ViveInputText(hit.collider.gameObject.name.ToString());
                    }
                    else if (hit.collider.CompareTag("PointUIProfile"))
                    {
                        // Result UI 띄우기 전에 정말 끝낼건지 확인을 하는 UI
                        // 경고문, 범인 지목시 현재까지의 기록을 토대로 평가가 진행되며
                        // 평가 이후에는 이어하는 것(?)이 불가능하다. 
                        SettingDisplay.PointUI_Dialog_active = true;
                        Pointed_Profile = hit.collider.gameObject;
                        // hit collider에 대한 정보도 넘겨야 됨. 
                    }


                    switch (hit.collider.gameObject.name)
                    {
                        case "YesButton": // SettingDisplay -> PointUI -> Dialog Yes button
                            hit.collider.transform.GetComponent<ScoreCalc>().GatherNumCal();
                            MainButtonText.transform.GetComponent<Text>().text = "View Result";
                            SettingDisplay.PointUI_Dialog_active = false;
                            SettingDisplay.PointUI_active = false;
                            break;
                        case "NoButton": // SettingDisplay -> PointUI -> Dialog No button
                            SettingDisplay.PointUI_Dialog_active = false;
                            break;
                        case "ResultYesButton":
                            SettingDisplay.ResultUI_active = false;
                            SettingDisplay.InputEmailUI_active = true;
                            SettingDisplay.ResultUI_Dialog_active = false;
                            break;
                        case "ResultYesButton2":
                            SettingDisplay.ResultUI_Dialog_active2 = false;
                            break;
                        case "ResultNoButton":
                            SettingDisplay.ResultUI_Dialog_active = false;
                            break;
                        case "ContinueButton":
                            SettingDisplay.SettingDisplayUI_active = false;
                            // 콘텐츠 계속 진행. 
                            break;
                        case "MainButton":
                            string buttonText = hit.collider.transform.GetComponent<Text>().text.ToString();
                            Debug.Log(buttonText);
                            if (buttonText.Equals("Input Email"))
                            {
                                hit.collider.transform.GetComponent<Text>().text = "Main";
                                SettingDisplay.InputEmailUI_active = true;
                                SettingDisplay.TeamKim_active = false;
                                SettingDisplay.PointUI_active = false;
                                SettingDisplay.PointUI_Dialog_active = false;
                            }
                            else if (buttonText.Equals("Main"))
                            {
                                hit.collider.transform.GetComponent<Text>().text = "Input Email";
                                IsEmail = GameObject.Find("InputField").transform.GetComponent<InputField>().text.ToString();
                                SettingDisplay.InputEmailUI_active = false;
                                SettingDisplay.TeamKim_active = false;
                                SettingDisplay.PointUI_active = true;
                                SettingDisplay.PointUI_Dialog_active = false;
                            }
                            else
                            {
                                IsEmail = GameObject.Find("InputField").transform.GetComponent<InputField>().text.ToString();
                                SettingDisplay.InputEmailUI_active = false;
                                SettingDisplay.TeamKim_active = false;
                                SettingDisplay.PointUI_active = false;
                                SettingDisplay.PointUI_Dialog_active = false;
                                SettingDisplay.ResultUI_active = true;
                                SettingDisplay.ResultUI_Dialog_active = false;
                            }

                            break;
                        case "OptionsButton":
                            MainButtonText.transform.GetComponent<Text>().text = "Main";
                            SettingDisplay.TeamKim_active = true;
                            SettingDisplay.InputEmailUI_active = false;
                            SettingDisplay.ResultUI_active = false;
                            SettingDisplay.PointUI_active = false;
                            SettingDisplay.PointUI_Dialog_active = false;
                            break;
                        case "ExitButton": // Unity Application 종료 
#if UNITY_EDITOR
                            // Application.Quit() does not work in the editor so
                            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
                            UnityEditor.EditorApplication.isPlaying = false;
#else
                                Application.Quit();
#endif
                            break;
                        case "ViveButton":  // InputEmail UI -> ViveButton
                            hit.collider.transform.GetComponent<InputConvert>().Select_Vive();
                            break;
                        case "KeyButton":   // InputEmail UI  -> Key Button
                            hit.collider.transform.parent.GetComponent<InputConvert>().Select_KeyBoard();
                            break;
                        case "StorageButton": // 평가 결과 저장 버튼 
                            if (IsEmail.Equals(""))
                            {
                                // 만약 Email이 저장되어 있지 않으면, 취소 
                                SettingDisplay.ResultUI_Dialog_active = true;
                            }
                            else
                            {
                                // Email이 저장되어 있으면 Firebase와 연동된 웹으로 이메일과 함께 결과 전달
                                SettingDisplay.ResultUI_Dialog_active2 = true;
                            }
                            break;
                    }

                }
                else
                {
                    laser.SetActive(false);
                }

            }
            else
            {
                laser.SetActive(false);
                RightControllerLaser.SetActive(true);
            }
        }
        else if (GameDisplayUI.bGameDisplayUI)
        {
            // GameDisplay UI가 active status일 때 동작 

            RaycastHit hit;
            RightControllerLaser.SetActive(true);
            if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                RightControllerLaser.SetActive(false);
                if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 100, UIMask))
                {
                    hitPoint = hit.point;
                    ShowLaser(hit);
                    notChangeUI = false;
                   
                    int num = 0;
                    if (hit.collider.gameObject == GameObject.Find("Tab01UI"))
                    {
                        num = 1;
                        GameDisplayUITab.TabConvert(num);
                    }

                    if (hit.collider.gameObject == GameObject.Find("Tab02UI"))
                    {
                        num = 2;
                        GameDisplayUITab.TabConvert(num);
                    }

                    if (hit.collider.gameObject == GameObject.Find("Tab03UI"))
                    {
                        num = 3;
                        GameDisplayUITab.TabConvert(num);
                    }

                    if (hit.collider.CompareTag("ItemFrame"))
                    {
                        hit.collider.transform.parent.parent.parent.parent
                            .GetComponent<ItemSelect>().contentDisplay(hit.collider.gameObject);

                        QuestionButton.QuestionProfile_active = false;
                        QuestionButton.ProfileDisplay();
                    }
                    if (hit.collider.CompareTag("ProfileFrame"))
                    {
                        UIProfileSelect.ProfileDetail_active = true;
                        hit.collider.transform.parent.parent.
                        GetComponent<UIProfileSelect>().contentDisplay(hit.collider.gameObject);
                    }

                    if (hit.collider.CompareTag("QuestionProfileFrame"))
                    {
                        Debug.Log("QuestionProfileFrameButton");
                        QuestionProfile.Question_able = true;
                        hit.collider.transform.parent.GetComponent<QuestionProfile>().addProfileContent(hit.collider.gameObject);
                    }

                    if (hit.collider.gameObject == GameObject.Find("QuestionButton"))
                    {
                        QuestionButton.QuestionProfile_active = !QuestionButton.QuestionProfile_active;
                        QuestionButton.ProfileDisplay();
                    }

                    if (hit.collider.CompareTag("RoomFrame"))
                    {
                        if (this.transform.GetComponent<VivePlayerUserScript>().Current_tutorial)
                        {
                            this.transform.GetComponent<VivePlayerUserScript>().Current_tutorial = false;
                            hit.collider.transform.parent.GetComponent<TutorialToScene>().ChangeRoom(hit.collider.gameObject);
                        }
                        else { 
                            hit.collider.transform.parent.GetComponent<RooomSelect>().ChangeRoom(hit.collider.gameObject);
                        }
                    }

                    if (hit.collider.gameObject == GameObject.Find("ViewPaper"))
                    {
                        // 문서 증거물을 Display UI에서 보여주는 버튼. 
                        hit.collider.transform.GetComponent<ViewPaperEvidence>().EvidencePaperDisplay(ItemSelect.PaperEvidenceSize);
                    }

                    if (hit.collider.gameObject == GameObject.Find("BackButton"))
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
                else
                {
                    laser.SetActive(false);
                }

            }
            else
            {
                laser.SetActive(false);
                RightControllerLaser.SetActive(true);
            }
        }




    }
}
