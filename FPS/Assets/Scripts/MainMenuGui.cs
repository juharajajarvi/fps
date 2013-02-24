using UnityEngine;
using System.Collections;

public class MainMenuGui : MonoBehaviour {

	private Rect imagePosition, imagePosition2;
	
	public GUIStyle newGameStyle, exitGameStyle;
	
	public int width=512, height=128;
	public int startX=90, startY=90;
	public int marginY=100;
	
	public bool centerX = true;
	
	void Start() {
		
		Screen.showCursor = true;
		
		if (centerX) {
			startX = (int)(Screen.width/2f - width/2f);	
		}
		imagePosition = new Rect(startX, startY, width, height);
		imagePosition2 = new Rect(startX, startY+marginY, width, height);
	}
	
	void OnGUI() {
		if ( GUI.Button( imagePosition, "", newGameStyle ) ) {
			Application.LoadLevel("secret_lab");	
		} else if ( GUI.Button( imagePosition2, "", exitGameStyle ) ) {
			Application.Quit();	
		}
	}
}
