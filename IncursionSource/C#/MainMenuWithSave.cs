using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class MainMenuWithSave : MonoBehaviour {

	public GUIStyle style;
	// Use this for initialization
	void Save() 
	{
		GameControl.control.Save();
		//Application.LoadLevel (IncursionFirstLevel);
	}
	
	// Load level 1
	void Load() 
	{
		GameControl.control.Load ();
		GUI.TextArea(new Rect(1,1,200,200)," Hello World ",style);
	}
		void OnGUI()

		{
			

		}
	}

