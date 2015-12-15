using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{	
	public static bool New = false;
	public static bool Load = false;


	void OnGUI()
	{
		if (GUI.Button(new Rect(Screen.width/2.5f,Screen.height/3,Screen.width/5,Screen.height/10),"New Game"))
			
		{
			New = true;
			Load = false;
			Application.LoadLevel (1);
			
		}


		if (GUI.Button(new Rect(Screen.width/2.5f,Screen.height/3,Screen.width/5,Screen.height/10),"Load Game"))

		    {
				Load = true;
				New = false;
				Application.LoadLevel (1);

			}

		if (GUI.Button(new Rect(Screen.width/2.5f,Screen.height/1.5f,Screen.width/5,Screen.height/10),"Exit Game"))
			
		{
			
			Application.Quit();
			
		}

	}
}
