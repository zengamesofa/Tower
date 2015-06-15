using UnityEngine;
using System.Collections;

public class UIControl : MonoBehaviour {

	public static UIControl Instance = null;

	public UISlider timeSlider;
    public UILabel peopleNumLabel;
    public UILabel houseNumLabel;

	//new Time
	public float time;
	public float maxTime;

	//Game value
	public float disTime;

	//Control Bar Shinging 
	private bool isShining = false;

	void Awake(){
		if (Instance == null)
			Instance = this;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		time = time - disTime;
		timeSlider.sliderValue = time / maxTime;

		//Bar Shining
		StartCoroutine ("barShiningAnimation");

		//GameOver
		if (time == 0) 
		{

		}
	}

	IEnumerator barShiningAnimation()
	{
		if (time < 30 && isShining == false) {
			timeSlider.foregroundWidget.color = new Color (255, 0, 0);
			timeSlider.backgroundWidget.color = new Color (255, 0, 0);
			yield return new WaitForSeconds (0.5f);
			isShining = true;
		} 
		else if (isShining == true) 
		{
			timeSlider.foregroundWidget.color = new Color (0, 255, 0);
			timeSlider.backgroundWidget.color = new Color (255, 255, 255);
			yield return new WaitForSeconds (0.5f);
			isShining = false;
		}
	}

    public void setPeopleNumber(int number)
	{
		peopleNumLabel.text = "" + number;
	}

 	public void setHouseNumber(int number)
	{
		Debug.Log ("houseNumber" + number);
		houseNumLabel.text = number.ToString();
	}

	public void setTimeBarNumber(int addTime)
	{
		time = time + addTime;
		if (time > 100)
			time = 100;
	}
}
