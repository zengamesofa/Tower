using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Control : MonoBehaviour {

	[SerializeField]
	private GameObject floor;
	
	[SerializeField]
	private GameObject towerListParent;

	[SerializeField]
	private GameObject Anchor;

	[SerializeField]
	private GameObject modelPrefab;

	List<TowerBox> towerBoxList = null;
	GameObject tower = null;
	TowerBox towerBox = null;

	int count = 0;
	bool isSky = false;

	void Awake () {
		towerBoxList = new List<TowerBox> ();
		CreateTower ();


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			isSky = true;
			towerBox.towerRigidbody.useGravity = true;
			tower.transform.parent = towerListParent.transform;
		}
	}

	void CreateTower(){
		tower = Instantiate (modelPrefab);
		tower.name = "tower_" + count++;
		tower.tag = "Tower";
		tower.transform.parent = Anchor.transform;
		tower.transform.localPosition = new Vector3 (0f, -1f, 0f);
		tower.transform.localEulerAngles = new Vector3 (0f, 270f, 0f);
		tower.transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f);

		towerBox = tower.AddComponent<TowerBox> ();
		towerBox.OnCollision += OnCollision;

		towerBoxList.Add (towerBox);
	}

	void OnCollision(string _tag, int _towerIndex){
		Debug.Log ("_tag:" + _tag + " _towerIndex:" + _towerIndex);
		towerBox.OnCollision -= OnCollision;
		CreateTower ();

		Debug.Log (towerBoxList.Count +" / "+_towerIndex);

		if (_tag == "Tower" && towerBoxList.Count >=2 ) {
			float dec = towerBoxList[towerBoxList.Count -1].transform.localPosition.y-1;

			iTween.MoveBy (towerListParent, iTween.Hash ("y", dec, "time", 0.5, "easetype", iTween.EaseType.easeInOutExpo));


			//iTween.RotateBy(towerListParent, iTween.Hash("z", .1, "easeType", "easeInOutBack", "loopType", "pingPong", "delay", .4));
			//iTween.RotateTo(towerListParent, iTween.Hash("z", .03, "easeType", "easeInOutBack", "loopType", "pingPong", "delay", .4));
			//iTween.MoveBy(towerListParent, iTween.Hash("x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .3));
		}
	}
}
