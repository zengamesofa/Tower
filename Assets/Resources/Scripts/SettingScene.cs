using UnityEngine;
using System.Collections;

public class SettingScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("test");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		Debug.Log ("onClick");
		Application.LoadLevel(0);
	}
}
