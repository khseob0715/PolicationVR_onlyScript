using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class DummyVideoSetting : MonoBehaviour {
	public GameObject Effect;
	public GameObject ViveController;
	public GameObject VideoObejct;
	public string LoadSceneName;
	private RaycastHit hit;
	public bool start = false;

	private VideoPlayer video;

	// Use this for initialization
	void Start () {
		ViveController.SetActive (false);	
		video = VideoObejct.transform.GetComponent<VideoPlayer> ();
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = new Ray (this.transform.position, this.transform.forward * 10.0f);

		if (Physics.Raycast (ray, out hit, 10.0f)) {
			Effect.SetActive (false);
			if (!start && hit.collider.gameObject == VideoObejct) {
				start = true;
				video.Play ();
			}
		}

		if (start && !video.isPlaying) { // 영상 재생이 끝이 나면, main Scene으로 이동 
			ViveController.SetActive (true);
			SceneManager.LoadScene (LoadSceneName);
		}
	}
}
