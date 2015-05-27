using UnityEngine;
using System.Collections;
using System;

public class TowerBox : MonoBehaviour {

	public Action<string, int, int> OnCollision = null;
	public Rigidbody towerRigidbody = null;
	private BoxCollider towerBoxCollider = null;

	void Awake(){
		towerBoxCollider = this.gameObject.AddComponent<BoxCollider> ();
		towerBoxCollider.center = new Vector3 (0f, 5f, 0f);
		towerBoxCollider.size = new Vector3 (9f, 10f, 6f);

		towerRigidbody = this.gameObject.AddComponent<Rigidbody>();
		towerRigidbody.mass = 2;
		towerRigidbody.useGravity = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision){
		Debug.Log ("TowerBox OnCollisionEnter: " + collision.gameObject.name + " tag: " + collision.gameObject.tag);

		if(towerRigidbody != null) {
			towerRigidbody.useGravity = false;
			towerRigidbody.isKinematic = true;
			towerRigidbody.Sleep();
		}
		
		switch (collision.gameObject.tag) {
		case "Floor":
			if(OnCollision != null)
				OnCollision("Floor", 0, 0);
			break;
		case "Tower":
            if (OnCollision != null)
            {
                string[] _mytower = this.gameObject.name.Split('_');

                string[] _tower = collision.gameObject.name.Split('_');
                OnCollision("Tower", Convert.ToInt32(_tower[1]), Convert.ToInt32(_mytower[1]));
            }
			break;
		}

	}
}
