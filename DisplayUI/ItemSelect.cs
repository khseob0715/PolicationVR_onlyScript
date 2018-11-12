using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelect : MonoBehaviour {

	public static bool[] ItemFind;  // 증거품을 찾았는지 못 찾았는지에 대한 정보를 갖고 있음.
	public GameObject[] Item;    // item frame에 대한 정보를 갖고 있음.    

	public GameObject EvidenceTextureObject; 

	public GameObject AllItemScroll;    // tab 1
	public GameObject Item_detail;      // tab 2 
	 
	public static bool Item_detail_active = false;
	public static bool AllItemScroll_active = true;

	public GameObject ItemImage;        // tab 2_image 
	public GameObject ItemName; 
	public GameObject ItemText; 

	public GameObject ViwePaperText;
	public GameObject EvidencePaper;

    public static int PaperEvidenceSize = 0; 

	// 세부 정보 보기 눌렀을때!
	void Awake ()
	{
		ItemFind = new bool[100];

		for (int i = 0; i < 100; i++) {
			ItemFind [i] = false;
		}
	}
 
	public void contentDisplay(GameObject hitObject){
		// 상세 보기 
		string hitObjectName = hitObject.transform.GetComponent<RawImage>().texture.name;
		Debug.Log (hitObjectName);

		if (!hitObjectName.Equals("ItemFrameUI")) {  // 못 찾았을 경우 texture가 변하지 않았음
			if (ViewPaperEvidence.bEvidencePaperDisplay == true) {
				ViewPaperEvidence.bEvidencePaperDisplay = false;
				EvidencePaper.SetActive (false);
			} // 문서 보기가 활성화 상태일 경우 비활성화 상태로 만들기. 

			//Debug.Log("true");
			ItemImage.transform.GetComponent<RawImage>().texture = hitObject.transform.GetComponent<RawImage> ().texture;   // 이미지 
			QuestionProfile.CurrentViewItemName = ItemImage.transform.GetComponent<RawImage>().texture.name;                // 이미지의 이름을 알아서 QustionProfile에서 사용함. 
			ItemName.transform.GetComponent<Text>().text = hitObject.transform.GetComponent<TextMesh>().text;               // 이름 
			ItemText.transform.GetComponent<Text> ().text = hitObject.GetComponentInChildren<Text> ().text;                 // item 내용

			if (hitObjectName.IndexOf ("P") == 13 || hitObjectName.IndexOf("p") == 13) {
				ViwePaperText.SetActive (true);  // 문서 보기 버튼 활성화. 
				Debug.Log (hitObject.GetComponentInChildren<RawImage> ().texture.name);

                // 아래의 스크립트를 다른 형식으로 변경해야됨. 
                // 많은 문서가 있어도 그 문서를 전부다 볼 수 있는 형태로. 
                //EvidencePaper.transform.GetComponent<RawImage> ().texture = hitObject.transform.GetComponent<GUITexture> ().texture;

                // PaperEvidenceGroup Script를 추가해, List를 받았음.
                ViwePaperText.transform.GetComponent<ViewPaperEvidence>().TextureArrayInput(hitObject.transform.GetComponent<PaperEvidenceGroup>().PaperEvidenceTexture);
                // Image 초기값.
                EvidencePaper.transform.GetComponent<RawImage>().texture = hitObject.transform.GetComponent<PaperEvidenceGroup>().PaperEvidenceTexture[0];
                
                PaperEvidenceSize = hitObject.transform.GetComponent<PaperEvidenceGroup>().PaperEvidenceTexture.Length; // 수를 받음. 

			} else {
				ViwePaperText.SetActive (false);
			}
			Item_detail_active = true;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Item_detail_active) {
			Item_detail_active = true;
			AllItemScroll_active = false;
			Item_detail.SetActive (Item_detail_active);
			AllItemScroll.SetActive (AllItemScroll_active);
		} else {
			
			Item_detail_active = false;
			AllItemScroll_active = true;
			Item_detail.SetActive (Item_detail_active);
			AllItemScroll.SetActive (AllItemScroll_active);
		}



	}
}
