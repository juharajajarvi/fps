#pragma strict

class ExitTriggable extends Triggable {

	function Trigger () {
		Application.Quit();
	}

}