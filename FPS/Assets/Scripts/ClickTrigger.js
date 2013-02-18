#pragma strict

public var removeOnClick : boolean;

function OnGUI() {
    if (Event.current.type == EventType.KeyDown || Event.current.type == EventType.MouseDown) {
        KeyPressedEventHandler();
    }
}
 
function KeyPressedEventHandler() {
    GetComponent(Triggable).Trigger();
    
    if (removeOnClick) {
    	GameObject.Destroy(this);
    }
}