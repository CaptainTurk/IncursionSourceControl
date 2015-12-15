#pragma strict
var pauseCanvas : Canvas;


function Start () 
{
	Screen.lockCursor = true;
	Cursor.visible = false;
}

//escape button laods menu UI
function Update () 
{
	if (Input.GetKeyDown(KeyCode.Escape))
	{
		(gameObject.Find("player").GetComponent("Player") as MonoBehaviour).enabled = false;
		(gameObject.Find("Main Camera").GetComponent("cameraRoot") as MonoBehaviour).enabled = false;
		pauseCanvas.enabled = true;
		
		Time.timeScale = 0;
		Screen.lockCursor = false;
		Cursor.visible = true;		
	
	}
	
}

//Stops the running scripts and looads in Game menu		
function ResumeGame () 
{

		(gameObject.Find("player").GetComponent("Player") as MonoBehaviour).enabled = true;
		(gameObject.Find("Main Camera").GetComponent("cameraRoot") as MonoBehaviour).enabled = true;
		pauseCanvas.enabled = false;
		
		Time.timeScale = 1;
		Screen.lockCursor = true;
		Cursor.visible = false;		
	
}
/*
function Save()
{
	 var cs = GameObject.Find("CSharpGameObj");
	 var script = cs.GetComponent("GameControl");
//	 script.Save();

}
*/

//Exits the game completely
function ExitGame () 
{
	Application.Quit();
}

//Loads the main opening level menu
function ExitToMain()
{
	Application.LoadLevel("NewMenu");
	pauseCanvas.enabled = false;
	Time.timeScale = 1;
}




