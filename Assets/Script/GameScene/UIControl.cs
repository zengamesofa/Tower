using UnityEngine;
using System.Collections;

public class UIControl : MonoBehaviour {

	public UISlider timeSlider;
	public UILabel peopleNumLabel;
	public UILabel houseNumLabel;

	//new Time
	public float time;
	public float maxTime;

	//Game value
	public float disTime;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		time = time - disTime;
		timeSlider.sliderValue = time / maxTime;
	}

    void setPeopleNumber(int number)
	{
		peopleNumLabel.text = "" + number;
	}

    void setHouseNumber(int number)
	{
		houseNumLabel.text = "" + number;
	}
}
