using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIProfileSelect : MonoBehaviour {
	private Text NameText;
	private Text DetailText;
	private Text ContentText;
	public GameObject[] Profile;

	public GameObject ProfileDetail;
	public GameObject AllProfile;
	public static bool ProfileDetail_active = false;
	public static bool AllProfile_active = true;

	/*Profile content change object*/
	public GameObject Name;
	public GameObject DetailProfile;
	public GameObject ProfileContent;

	void Awake(){
//		DontDestroyOnLoad (this.gameObject);
	}

	public void contentDisplay(GameObject hitObject){
		NameText.transform.parent.GetComponent<RawImage> ().texture = hitObject.transform.GetComponent<RawImage> ().texture;
		// 프로필 이미지 변경 
		NameText.text = hitObject.GetComponentInChildren<ProfileDetailContent>().DetailContent;
		// name change
		DetailText.text = hitObject.GetComponentInChildren<ProfileDetailContent>().DetailContent.Substring(4);
		// detail profile change

		ContentText.text = hitObject.GetComponentInChildren<Text> ().text;
		// profile content change
	}

	void Start () {
		NameText = Name.GetComponent<Text> ();
		DetailText = DetailProfile.GetComponent<Text> ();
		ContentText = ProfileContent.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (ProfileDetail_active) {
			ProfileDetail_active = true;
			AllProfile_active = false;
			ProfileDetail.SetActive (ProfileDetail_active);
			AllProfile.SetActive (AllProfile_active);
		} else {
			ProfileDetail_active = false;
			AllProfile_active = true;
			ProfileDetail.SetActive (ProfileDetail_active);
			AllProfile.SetActive (AllProfile_active);
		}
	}
}
