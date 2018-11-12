using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class BarContentAnimation : MonoBehaviour {
    public static int GatherScore = 0;
    public static int InvestScore = 0;

    public GameObject BarContentParent;
    public GameObject BarContentParent2;
    public GameObject GatherScoreText;
    public GameObject InvestScoreText;
    public GameObject TotalScoreText;
    // public GameObject MainButtonText;

    private bool GatherFinal = false;
    private bool InvestFinal = false;

    private RawImage[] BarContent_Image;
    private RawImage[] BarContent_Image2;

    FirebaseApp fbApp;
    DatabaseReference dbRef;

    // Use this for initialization
    void Start () {
		
	}

    private void Awake()
    {

        BarContent_Image = BarContentParent.GetComponentsInChildren<RawImage>();
        BarContent_Image2 = BarContentParent2.GetComponentsInChildren<RawImage>();
        int len = BarContent_Image.Length;
        for (int i = 1; i < len; i++)
        {
            BarContent_Image[i].gameObject.SetActive(false);
            BarContent_Image2[i].gameObject.SetActive(false);
        }
        TotalScoreText.SetActive(false);
        ScoreNumberAnimation();
    }

    public void ScoreNumberAnimation()
    {
        // MainButtonText.transform.GetComponent<Text>().text = "View Result";
        StartCoroutine("NumberAnim");
    }

	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator NumberAnim()
    {
        GameObject Effect = GatherScoreText.transform.GetChild(0).gameObject;
        GameObject Effect2 = InvestScoreText.transform.GetChild(0).gameObject;
        Effect.SetActive(false);
        Effect2.SetActive(false);
        
        for (int i = 0; i <= GatherScore || i <= InvestScore; i++)
        {
            if(i % 10 == 0)
            {
                if (!GatherFinal)
                {
                    BarContent_Image[i / 10].gameObject.SetActive(true);
                }
                if (!InvestFinal)
                {
                    BarContent_Image2[i / 10].gameObject.SetActive(true);
                }
                
            }

            if (i <= GatherScore)
            {
                GatherScoreText.GetComponent<Text>().text = i.ToString();
            }
            else
            {
                Effect.SetActive(true);
                GatherFinal = true;
            }

            if (i <= InvestScore)
            {
                InvestScoreText.GetComponent<Text>().text = i.ToString();
            }
            else
            {
                Effect2.SetActive(true);
                InvestFinal = true;
            }
            yield return new WaitForSeconds(0.005f);
        }
        TotalScoreText.GetComponent<Text>().text = (GatherScore + InvestScore).ToString();
        TotalScoreText.SetActive(true);

        // 최종 점수가 작성되는 곳. 
        // GatherScore 
        // InvestScore 사용해서 서버에 넘기면 됨. 
        // Email,   InputEmail.emailAddress;
        // 1
        int testcase = 1;
        fbApp = FirebaseDatabase.DefaultInstance.App;
        fbApp.SetEditorDatabaseUrl("https://policationvrweb.firebaseio.com/");
        dbRef = FirebaseDatabase.DefaultInstance.RootReference;

        string key = dbRef.Child("Users").Push().Key;

        dbRef.Child("Users").Child(key).Child("Test_case").SetValueAsync(testcase); //사건 케이스
        dbRef.Child("Users").Child(key).Child("User_email").SetValueAsync(InputEmail.emailAddress); //입력할 이메일 주소
        dbRef.Child("Users").Child(key).Child("case_mail").SetValueAsync(testcase + "_" + InputEmail.emailAddress); //검색 기준 "1_exam01@naver.com" 형식
        dbRef.Child("Users").Child(key).Child("date").SetValueAsync(DateTime.Now.ToString("yyyy-MM-dd")); //날짜 yyyy-MM-dd 형식
        dbRef.Child("Users").Child(key).Child("evidence").SetValueAsync(GatherScore);
        dbRef.Child("Users").Child(key).Child("witness").SetValueAsync(InvestScore);
        dbRef.Child("Users").Child(key).Child("Average").SetValueAsync((GatherScore + InvestScore)/2);

    }
}
