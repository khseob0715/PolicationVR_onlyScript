using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class QuestionProfile : MonoBehaviour {

	public GameObject[] Profile;
	public GameObject[] Tab03_Profile;
	public GameObject Name;

	public static string CurrentViewItemName;
	private int ItemIndex;

	private GameObject ItemObject;
	private string ItemDetailTextObject_text;

	public static bool Question_able = true;
	// Use this for initialization
	void Start () {
		
	}

	public void addProfileContent(GameObject hitObject){

		if (Question_able) {

            Debug.Log("QuestionProfileFrameButton_able");
            ItemIndex = int.Parse (CurrentViewItemName.Substring (CurrentViewItemName.Length - 2)); // item index;
                                                                                                    // string -> int
            Debug.Log("Question");
			ItemObject = this.transform.parent.parent.GetComponent<ItemSelect> ().Item [ItemIndex];

			string hitObjectName = hitObject.name;
			int index = 0;
			for (int i = 0; i < Profile.Length; i++) {
				if (hitObject.name == Profile [i].name) {
					index = i;
					break;
				}
			}

			string answer_text = "";

			answer_text = ItemObject.transform.GetComponent<QuestionAnswer> ().answer [index];
			ItemObject.transform.GetComponent<QuestionAnswer> ().answer [index] = "";


			if (!answer_text.Equals ("")) {
			    // 개인별 Profile의 Content에 내용 추가 중. 
				Tab03_Profile [index].transform.GetComponentInChildren<Text> ().text += "\r\n";
				Tab03_Profile [index].transform.GetComponentInChildren<Text> ().text += Name.transform.GetComponent<Text> ().text;
				Tab03_Profile [index].transform.GetComponentInChildren<Text> ().text += " - ";
				Tab03_Profile [index].transform.GetComponentInChildren<Text> ().text += answer_text.Substring (6); // Q & A의 name만 지워서 가져옴 

				ItemDetailTextObject_text = ItemObject.GetComponentInChildren<Text> ().text;
				ItemDetailTextObject_text += "\r\n";
				ItemDetailTextObject_text += answer_text;

				int len = ItemObject.GetComponentInChildren<Text> ().text.Length;
				ItemObject.GetComponentInChildren<Text> ().text = ItemDetailTextObject_text;
				this.transform.parent.parent.GetComponent<ItemSelect> ().ItemText.transform.GetComponent<UITextTypeWriter> ().Typing (ItemIndex, len);

                this.transform.GetComponent<InvestScoreCalc>().InvestNumCal();

				Debug.Log ("test");
			}
        }
        else
        {
            Debug.Log("Question able : " + Question_able);
        }

	}


	// Update is called once per frame
	void Update () {
		
	}
}
