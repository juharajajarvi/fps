#pragma strict

var MenuActive:boolean = false;

function Start () {

}

function Update () {

}

function OnGUI () { 

	if (MenuActive == true) {      
	
	    //show mouse cursor
	
	    Screen.showCursor = true;}
	
	    else {Screen.showCursor = false;}
	
	    
	
	    if (MenuActive == true){
	
	    // Make a background box 
	
	   GUI.Box (Rect ((Screen.width-200)/2,80,200,180), "CrateSlinger"); 
	
	   //First button returns to the game in progress
	
	   if (GUI.Button (Rect ((Screen.width-150)/2,110,150,20), "Back to game")) { 
	
	      MenuActive=!MenuActive;
	
	      }
	
	      //Second button returns to main menu
	
	       if (GUI.Button (Rect((Screen.width-150)/2,190,150,20), "Main Menu")) { 
	
	      Application.LoadLevel ("menu"); 
	
	   } 
	
	   } 

 
} 

 

function LateUpdate()

{

 if (Input.GetButtonDown("Escape")) { 

      MenuActive=!MenuActive; 

      }

    if(MenuActive == true) { 

     print ("Escape pushed");
	}
}