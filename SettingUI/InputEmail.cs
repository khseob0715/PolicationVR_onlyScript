using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputEmail : MonoBehaviour {

    // Email Input Field;
    public InputField emailField;

    public static string emailAddress;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ViveInputText(string c)
    {
        if (c.Equals("BackKey"))
        {
            emailField.text = emailField.text.ToString().Substring(0, emailField.text.Length-1);
            Debug.Log("backspace");
        }
        else
        { 
            emailField.text += c;
        }
        OnSubmit();
    }

    public void OnSubmit() // 향후 웹으로 넘길 값. 
    {
        //Set emailAddress string to text in emailField;
        emailAddress = emailField.text;

        
    }
}
