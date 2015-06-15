using UnityEngine;
using System.Collections;
using UnityEditor;

public class MapEditor : EditorWindow {

	void OnGUI(){
		GUILayout.BeginVertical(); GUILayout.Label(" AutoModel Ver.1.0 ");
		
		GUILayout.BeginHorizontal(); 
		GUILayout.Label("Create Map "); 
		if (GUILayout.Button ("Create", GUILayout.Width (50))) {
			//Debug.Log("Button Click");
			for (int i=0; i<10; i++)
			{
				for (int j=0; j<10; j++)
				{
					GameObject house = (GameObject)Resources.Load("house", typeof(GameObject)); 
					GameObject obj = (GameObject)PrefabUtility.InstantiatePrefab(house);
					if (obj)
					{
						GameObject container = GameObject.Find ("container");
						obj.transform.position = new Vector3(0.2f*i, 0.5f - j*0.2f, 0f);
						obj.transform.parent = container.transform;
					}
				}
			}
		}
		if (GUILayout.Button ("Clear", GUILayout.Width (50))) {
			GameObject container = GameObject.Find ("container");
			int childs = container.transform.childCount; //container.transform.childCount;
			for (int i = childs - 1; i >= 0; i--)
			{
				GameObject.Destroy(container.transform.GetChild(i).gameObject);
			}
		}
		GUILayout.EndHorizontal();
		
		GUILayout.EndVertical();


		Handles.BeginGUI();
		GUI.Button(new Rect(Screen.width-110,Screen.height-60,100,20), "Create Bomb"); 
		Handles.EndGUI();
	}

}
