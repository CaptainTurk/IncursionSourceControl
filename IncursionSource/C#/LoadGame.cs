using UnityEngine;
using System.Collections;

public class LoadGame : MonoBehaviour 
{
	private int thegame = 1;


	// Use this for initialization
	void Start () 
	{
		if (Menu.Load == true) 
		{

		}

		if (Menu.New == true) 
		
		{


		}
	}
	
	// Update is called once per frame
	void Update () 
	
	{
		if (Input.GetKeyDown ("h")) 
		
		{
			PlayerPrefs.Save ();

		}


	}
}
