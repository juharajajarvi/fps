#pragma strict

class MenuNavigationTriggable extends Triggable {

	public var levelToOpen : String;

	function Trigger () {
		Application.LoadLevel( levelToOpen );
	}

}