using UnityEngine;
using System.Collections;

public class MenuNavigationTriggable : Triggable {

	public string levelToOpen;

	override public void Trigger () {
		Application.LoadLevel( levelToOpen );
	}

}
