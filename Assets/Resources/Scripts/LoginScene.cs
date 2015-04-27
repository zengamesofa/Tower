using UnityEngine;
using System.Collections;

public class LoginScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("test2");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		Debug.Log ("onClick");
		Application.LoadLevel(1);
	}
}
