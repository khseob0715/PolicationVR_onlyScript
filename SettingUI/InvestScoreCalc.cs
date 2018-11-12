using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestScoreCalc : MonoBehaviour {
    private int InvestNum = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void InvestNumCal()
    {
        Debug.Log("InvestNum : " + InvestNum);
        InvestNum++;
        BarContentAnimation.InvestScore = InvestNum;
    }
}
