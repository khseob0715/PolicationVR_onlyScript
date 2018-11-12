using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispalyLaptopMonitor : MonoBehaviour {
    public GameObject LaptopMonitor;
    public static bool LaptopMonitorActive = false;

	// Use this for initialization
	void Start () {
        DisplayLaptop(LaptopMonitorActive); // 처음에는 꺼놓음. 
	}
	
    public void DisplayLaptop(bool OnOff)
    {
        LaptopMonitor.SetActive(OnOff);
    }

	// Update is called once per frame
	void Update () {
        
	}
}
