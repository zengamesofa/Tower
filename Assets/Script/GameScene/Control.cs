using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Control : MonoBehaviour {

    public static Control instance = null;

	[SerializeField]
	private GameObject floor;
	
	[SerializeField]
	private GameObject towerListParent;

	[SerializeField]
	private GameObject Anchor;

	[SerializeField]
	private GameObject modelPrefab;

	public List<TowerBox> towerBoxList = null;
	GameObject tower = null;
	TowerBox towerBox = null;

	int count = 0;
	bool isSky = false;

    int topIndex = 0;

	void Awake () {
        instance = this;

		towerBoxList = new List<TowerBox> ();
		CreateTower ();
	}

    void OnDestroy() {
        iTween.Stop();
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
        towerBox.towerBoxID = count;

		towerBox.OnCollision += OnCollision;

		towerBoxList.Add (towerBox);
	}

	void OnCollision(string _tag, int _towerIndex, int _topIndex)
    {
		Debug.Log ("_tag:" + _tag + " _towerIndex:" + _towerIndex);
		towerBox.OnCollision -= OnCollision;
		CreateTower ();

		if (_tag == "Tower" )
        {
            if (towerBoxList.Count >= 2)
            {
                towerBoxList[towerBoxList.Count - 2].lockshaking = false;
                float dec = towerBoxList[towerBoxList.Count - 1].transform.localPosition.y - 1f;

                Debug.Log(towerBoxList.Count + " / Collision_towerIndex:" + _towerIndex + " / top:" + _topIndex);
                iTween.MoveBy(towerListParent, iTween.Hash("y", dec, "time", 0.5, "easetype", iTween.EaseType.linear));
            }
		}
	}
}
