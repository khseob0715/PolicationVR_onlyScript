using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalc : MonoBehaviour {

    private int GatherNum = 0;
    
	// Use this for initialization

    // 해당 Script에 public object 추가시. QustionProfile에서도 넣어야됨.. 
	void Start () {
		
	}
	
    public void GatherNumCal() // 수집된 증거물 갯수 계산
    {
        int len = ItemSelect.ItemFind.Length;
        for(int i = 0; i < len; i++)
        {
            if (ItemSelect.ItemFind[i])
            {
                GatherNum++;
            }
        }
        // 계산한 값을 넘겨줘서 애니메이션 효과를 진행할 수 있도록 함. 
        GatherNum = GatherNum * 10;
        if(GatherNum >= 350)
        {
            GatherNum = 350;
        }
        BarContentAnimation.GatherScore = GatherNum;

        
        
        SettingDisplay.ResultUI_active = true;
    }

    

	// Update is called once per frame
	void Update () {
		
	}
}
