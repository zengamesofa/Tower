using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Control : MonoBehaviour {

<<<<<<< HEAD
    public static Control instance = null;

=======
>>>>>>> origin/master
	[SerializeField]
	private GameObject floor;
	
	[SerializeField]
	private GameObject towerListParent;

	[SerializeField]
	private GameObject Anchor;

	[SerializeField]
	private GameObject modelPrefab;

<<<<<<< HEAD
	public List<TowerBox> towerBoxList = null;
=======
	List<TowerBox> towerBoxList = null;
>>>>>>> origin/master
	GameObject tower = null;
	TowerBox towerBox = null;

	int count = 0;
	bool isSky = false;

    int topIndex = 0;

	void Awake () {
<<<<<<< HEAD
        instance = this;

=======
>>>>>>> origin/master
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
<<<<<<< HEAD
        towerBox.towerBoxID = count;

=======
>>>>>>> origin/master
		towerBox.OnCollision += OnCollision;

		towerBoxList.Add (towerBox);
	}

<<<<<<< HEAD
	void OnCollision(string _tag, int _towerIndex, int _topIndex)
    {
=======
	void OnCollision(string _tag, int _towerIndex, int _topIndex){
>>>>>>> origin/master
		Debug.Log ("_tag:" + _tag + " _towerIndex:" + _towerIndex);
		towerBox.OnCollision -= OnCollision;
		CreateTower ();

<<<<<<< HEAD
		if (_tag == "Tower" )
        {
            if (towerBoxList.Count >= 2)
            {
                towerBoxList[towerBoxList.Count - 2].lockshaking = false;
                float dec = towerBoxList[towerBoxList.Count - 1].transform.localPosition.y - 1f;
=======
        

		if (_tag == "Tower" ) {

            if (towerBoxList.Count >= 2)
            {
                float dec = towerBoxList[towerBoxList.Count - 1].transform.localPosition.y - 1;
>>>>>>> origin/master

                Debug.Log(towerBoxList.Count + " / Collision_towerIndex:" + _towerIndex + " / top:" + _topIndex);
                iTween.MoveBy(towerListParent, iTween.Hash("y", dec, "time", 0.5, "easetype", iTween.EaseType.linear));
            }
<<<<<<< HEAD
=======

            if (towerBoxList.Count >= 7)
            {
                if (towerListParent.GetComponent<DropShadowAnim>() == null)
                    towerListParent.AddComponent<DropShadowAnim>();
            }
>>>>>>> origin/master
		}
	}
}
