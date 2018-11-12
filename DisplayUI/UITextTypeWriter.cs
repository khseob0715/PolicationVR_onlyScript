using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextTypeWriter : MonoBehaviour {

	private Text txt;
	private string story;

	public void Typing(int index, int last_index){
		this.GetComponent<Text> ().text = this.transform.parent.parent.parent.parent.parent.GetComponent<ItemSelect> ().Item [index].GetComponentInChildren<Text>().text;
		txt = this.GetComponent<Text> ();
		story = txt.text.Substring (last_index);
		txt.text = txt.text.Substring (0, last_index);
		QuestionProfile.Question_able = false;
		StartCoroutine ("PlayText");
	}


	IEnumerator PlayText(){
		foreach (char c in story) {
			txt.text += c;
			yield return new WaitForSeconds (0.08f);
		}
		QuestionProfile.Question_able = true;
	}

}
