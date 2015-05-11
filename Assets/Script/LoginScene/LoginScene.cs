using UnityEngine;
using System.Collections;

public class LoginScene : MonoBehaviour {

	public GameObject earth;
	public GameObject comet;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		earth.transform.Rotate(Vector3.forward, 1 * Time.deltaTime);
//		comet.transform.RotateAround (new Vector3(336, -121, 0), new Vector3(10, 10, 50), Time.deltaTime * 0.5);
	}

	public void SingleClick(){
//		Application.LoadLevel(1);
	}

	public void MultiplayerClick(){
//		Application.LoadLevel(1);
	}

	public void SettingClick(){
		Application.LoadLevel(1);
	}

	public void ExitClick(){
//		Application.LoadLevel(1);
	}
}
