using UnityEngine;
using System.Collections;
using UnityEditor;

public class MapEditor : EditorWindow {

	void OnGUI(){
		GUILayout.BeginVertical(); GUILayout.Label(" AutoModel Ver.1.0 ");
		
		GUILayout.BeginHorizontal(); 
		GUILayout.Label("Create Yuzu "); 
		if (GUILayout.Button ("Create", GUILayout.Width (50))) {
			Debug.Log("Button Click");
		}
		GUILayout.EndHorizontal();
		
		GUILayout.EndVertical();


		Handles.BeginGUI();
		GUI.Button(new Rect(Screen.width-110,Screen.height-60,100,20), "Create Bomb"); 
		Handles.EndGUI();
	}

}
