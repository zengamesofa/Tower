using UnityEngine;
using System.Collections;

public class LoginScene : MonoBehaviour {

	public GameObject earth;
	public GameObject background;
	public GameObject music;

	void Awake () {
		DontDestroyOnLoad(music);
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		earth.transform.Rotate(Vector3.forward, 1 * Time.deltaTime);
		background.transform.localScale += new Vector3 (0.02f, 0.02f, 0);
	}

	public void SingleClick(){
		Application.LoadLevel(2);
	}

	public void MultiplayerClick(){
		Application.LoadLevel(2);
	}

	public void SettingClick(){
		Application.LoadLevel(1);
	}

	public void ExitClick(){
//		Application.LoadLevel(1);
	}
}
