#pragma strict

public var playerController:PlayerController;

// This would stop the player from looking around when on pause mode,
// but can't find that script!
//public var playerLook:PlayerLook;

var MenuActive:boolean = false;

function Start () {
	Screen.lockCursor = true;
}

function Update () {

}

function OnGUI () { 
	
	if (MenuActive == true) {      
		//show mouse cursor
		Screen.showCursor = true;
	}
	else {
		Screen.showCursor = false;
	}
	
	if (MenuActive == true) {
		
		// Make a background box 
		GUI.Box (Rect ((Screen.width-200)/2,80,200,180), "ALIEN FPS -- PAUSED"); 
	
		//First button returns to the game in progress
		if (GUI.Button (Rect ((Screen.width-150)/2,150,150,20), "Back to game")) { 
			MenuActive = false;
			Resume();
		}
	
		//Second button returns to main menu
		if (GUI.Button (Rect((Screen.width-150)/2,180,150,20), "Quit")) { 
			Application.LoadLevel("main_menu"); 
		}
	}
	
}


function LateUpdate() {

	if (Input.GetButtonDown("Escape")) {
		MenuActive=!MenuActive;
	}
	
	if (MenuActive) {
		SetPaused();
	} else {
		Resume();
	}
}

function SetPaused() {
	Time.timeScale = 0.0;
	playerController.enabled = false;
	Screen.lockCursor = false;
	//playerLook.enabled = false;
	Debug.Log("Paused");
}

function Resume() {
	Time.timeScale = 1.0;
	playerController.enabled = true;
	Screen.lockCursor = true;
	//playerLook.enabled = true;
}