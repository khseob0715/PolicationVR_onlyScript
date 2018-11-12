using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewPaperEvidence : MonoBehaviour {

    public GameObject EvidencePaper;

    public GameObject NextButton;
  //  public GameObject PreButton;

    public static bool bEvidencePaperDisplay = false;

    private int EvidencePaperNum;

    private int CurrnetViewEvidenceIndex = -1;

    private Texture[] PaperEvidenceTexture;

    public GameObject LaserPrefabs;
    
    public void EvidencePaperDisplay(int PaperEvidenceSize) {
        bEvidencePaperDisplay = !bEvidencePaperDisplay;
        EvidencePaperNum = PaperEvidenceSize; // 수를 넘겨 받았음.

        EvidencePaper.transform.GetChild(0).GetComponent<RawImage>().texture = PaperEvidenceTexture[0];

        if (bEvidencePaperDisplay) {
            if(PaperEvidenceSize != 0) { 
                ImageSizeChange(0);
            }

            EvidencePaper.SetActive(true);
            if (EvidencePaperNum >= 2)
            {
                Debug.Log("Size : " + EvidencePaperNum);
                NextButton.SetActive(true);
            }
            
        } else {
            
            EvidencePaper.SetActive(false);
            NextButton.SetActive(false);
        //    PreButton.SetActive(false);
            CurrnetViewEvidenceIndex = -1;
        }

    }

    public void TextureArrayInput(Texture[] texture)
    {
        PaperEvidenceTexture = texture;
    }

    private void ImageSizeChange(int index)
    {
        // 원래 크기
        float OriginHeight = (float)PaperEvidenceTexture[index].height;
        float OriginWidth = (float)PaperEvidenceTexture[index].width;

        // EvidencePaprer Object의 Height 크기 변경
        // EvidencePaper.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(270.0f, OriginHeight * 270.0f / OriginWidth);
    }

    public void NextEvidence()
    {
        Debug.Log("call NextEvidence()");
        CurrnetViewEvidenceIndex++;
        if (CurrnetViewEvidenceIndex == EvidencePaperNum)
        {
            CurrnetViewEvidenceIndex = 0;
            
        }

        ImageSizeChange(CurrnetViewEvidenceIndex);
        EvidencePaper.transform.GetChild(0).GetComponent<RawImage>().texture = PaperEvidenceTexture[CurrnetViewEvidenceIndex];

      
    }

 
	// Use this for initialization
	void Start () {
		EvidencePaper.SetActive (false);
        NextButton.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
