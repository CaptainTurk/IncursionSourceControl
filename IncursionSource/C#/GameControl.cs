/*********************************
 * Persitent Data Game Controller*
**********************************/

using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary; // Writes unreadable binary files for security
using System.IO;

public class GameControl : MonoBehaviour 
{
	public static GameControl control;

	public float health;
	public float level;
	public float aura;


	// Use this for initialization
	void Awake () 

	{
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} 
		//if the data does not math the original data destroy the gameobject
		else if (control != this) 
		{
			Destroy (gameObject);
		}

	}
	// Write the data fields on the screen
	void OnGUI () 
	{
		GUI.Label (new Rect(30,10,100,30), "Health:" + health);
		GUI.Label (new Rect(30,40,150,30), "Character Level:" + level);
		GUI.Label (new Rect(30,70,150,30), "Aura:" + aura);
		
	}

	//creates a file and writes the data to it.
	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/MainPlayerPersistentData.dat"); //	

		PlayerData data = new PlayerData();

		data.health = health;
		data.level = level;
		data.aura = aura;

		bf.Serialize (file, data); //serialization, not human readebale before conversion
		file.Close(); //closes the file

	}

	//Reads from the saved file and deserializes it 
	public void Load()

	{
		if (File.Exists (Application.persistentDataPath + "/MainPlayerPersistentData.dat")) //checks the data exists or not
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/MainPlayerPersistentData.dat", FileMode.Open);

			PlayerData data = (PlayerData)bf.Deserialize(file); //converts the binary to readable data
			file.Close();

			health = data.health;
			level = data.level;
			aura = data.aura;
		}
	}
}

[Serializable]//allows the communication with Unity for serizalization
class PlayerData	
{
	public float health;
	public float level;
	public float aura;	
	
}
