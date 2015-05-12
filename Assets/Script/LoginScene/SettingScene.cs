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
		if (AudioEx.Instance) {
			AudioEx.Instance.setMusicSound (UIProgressBar.current.value);
			Debug.Log ("change music:" + UIProgressBar.current.value);
		}
	}

	public void OnValueChangeSound()
	{
		if (AudioEx.Instance) {
			AudioEx.Instance.setSoundVolume (UIProgressBar.current.value);
			Debug.Log ("change sound:" + UIProgressBar.current.value);
		}
	}

	public void OnValueChangeSoundEnd()
	{
		if (AudioEx.Instance) {

		}
	}
}
