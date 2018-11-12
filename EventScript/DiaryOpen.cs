using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryOpen : MonoBehaviour {

    public GameObject[] Page;

    private int TCount = 0;
    private bool Once = false;

    
	// Use this for initialization
	void Start () {
		
	}

    public void TouchCount()
    {
        TCount++;
    }

    private void OnceAnim()
    {
        if (!Once) { 
            this.GetComponent<Animation>().Play();
            Once = true;
        }

    }
	// Update is called once per frame
	void Update () {
        Quaternion targetRotation = Quaternion.Euler(0, 120, 0);
        Quaternion returntargetRotation = Quaternion.Euler(0, 0, 0);
        switch (TCount) {
            case 1:
                OnceAnim();
                break;
            case 2:
                Page[0].transform.localRotation = Quaternion.Slerp(Page[0].transform.localRotation, targetRotation, 2 * Time.deltaTime);
                Page[1].SetActive(true);            
                
                break;
            case 3:
                Page[1].transform.localRotation = Quaternion.Slerp(Page[1].transform.localRotation, targetRotation, 2 * Time.deltaTime);
                Page[2].SetActive(true);

                break;
            case 4:
                Page[2].transform.localRotation = Quaternion.Slerp(Page[2].transform.localRotation, targetRotation, 2 * Time.deltaTime);
                break;
            case 5:
                Page[2].transform.localRotation = Quaternion.Slerp(Page[2].transform.localRotation, returntargetRotation, 2 * Time.deltaTime);
                Page[1].transform.localRotation = Quaternion.Slerp(Page[1].transform.localRotation, returntargetRotation, 2 * Time.deltaTime);
                Page[0].transform.localRotation = Quaternion.Slerp(Page[0].transform.localRotation, returntargetRotation, 2 * Time.deltaTime);
                break;
            case 6:
                TCount = 2;
                break;
        }

	}

}
