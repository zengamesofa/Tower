using UnityEngine;
using System.Collections;

public class SettingScene : MonoBehaviour {

	//public float num = 0.5;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		Application.LoadLevel(0);
	}

	public void OnValueChange()
	{
		AudioEx.Instance.setMusicSound (UIProgressBar.current.value);
		Debug.Log ("change:" + UIProgressBar.current.value);
	}
}
