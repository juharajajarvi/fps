#pragma strict

public var removeOnClick : boolean;

function OnMouseOver () {

	if (Input.GetMouseButtonDown(0)) {
		Debug.Log("moi");
        GetComponent(Triggable).Trigger();
    
	    if (removeOnClick) {
	    	GameObject.Destroy(this);
	    }
	}
}