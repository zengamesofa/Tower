using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

public class MapEditor : EditorWindow {

	GameObject house;

	public void OnEnable(){
		house = (GameObject)Resources.Load("house", typeof(GameObject));
		SceneView.onSceneGUIDelegate += OnSceneGui;

		Debug.Log ("OnEnable");
	}

	public void OnDisable()
	{
		//SceneView.onSceneGUIDelegate -= OnSceneGui;

		Debug.Log ("OnDisable");
	}

	public void OnGUI(){
		GUILayout.BeginVertical(); GUILayout.Label(" AutoModel Ver.1.0 ");
		
		GUILayout.BeginHorizontal(); 
		GUILayout.Label("Create Map "); 
		if (GUILayout.Button ("Create", GUILayout.Width (50))) {
			//Debug.Log("Button Click");
			for (int i=0; i<10; i++)
			{
				for (int j=0; j<10; j++)
				{
					//GameObject house = (GameObject)Resources.Load("house", typeof(GameObject)); 
					GameObject obj = (GameObject)PrefabUtility.InstantiatePrefab(house);
					if (obj)
					{
						GameObject container = GameObject.Find ("container");
						obj.transform.position = new Vector3(0.156f*i, 0.7f - j*0.156f, 0f);
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

	public void OnSceneGui(SceneView sceneView)
	{
		Event e = Event.current;
		if (!e.alt) 
		{
			if (e.type == EventType.mouseDown && e.button == 1)
			{
				e.Use();

				Ray mouseRay = Camera.current.ScreenPointToRay(new Vector3(e.mousePosition.x, 
				                                                           Camera.current.pixelHeight - e.mousePosition.y, 
				                                                           0.0f));
				//Debug.Log("ray y:" + mouseRay.direction.y);
				if (mouseRay.direction.z >= 0.0f)
				{
					float t = -mouseRay.origin.z / mouseRay.direction.z;
					Vector3 mouseWorldPos = mouseRay.origin + t * mouseRay.direction; 
					mouseWorldPos.y = mouseRay.origin.y;

					GameObject container = GameObject.Find ("container");
					GameObject obj = (GameObject)PrefabUtility.InstantiatePrefab(house);
					obj.transform.position = mouseWorldPos;
					obj.transform.parent = container.transform;
				}
			}
		}

		if (e.type == EventType.MouseUp) 
		{
			string fileName = "save";
			if (File.Exists(fileName))
			{
				Debug.Log(fileName + " already exists.");
			}

			StreamWriter sr = File.CreateText(fileName);
			GameObject container = GameObject.Find ("container");
			foreach (Transform ball in container.transform)
			{
				//Debug.Log("ball x:" + ball.transform.position.x + " ,y" + ball.transform.position.y);
				sr.WriteLine ("{0},{1}", ball.transform.position.x, ball.transform.position.y);
			}
			sr.Close();

			//read
			if(File.Exists(fileName)){
				var src = File.OpenText(fileName);
				var line = src.ReadLine();
				while(line != null){
					Debug.Log("read" + line); // prints each line of the file
					line = src.ReadLine();
				}  
			} else {
				Debug.Log("Could not Open the file: " + fileName + " for reading.");
				return;
			}
		}
	}
}
