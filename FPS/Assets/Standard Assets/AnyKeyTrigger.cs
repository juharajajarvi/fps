using UnityEngine;
using System.Collections;

public class AnyKeyTrigger : MonoBehaviour {
	
	public bool removeOnClick;
	public bool isTimed;
	public float timeAfterTriggered = 2.0f;
	private float timeRemaining;
	
	private Triggable triggable;
	
	void Start() {
		triggable = gameObject.GetComponent<Triggable>();
		timeRemaining = timeAfterTriggered;
	}
	
	void Update() {
		if (isTimed) {
			timeRemaining -= Time.deltaTime;
			if ( timeRemaining < 0 ) {
				DoTrigger();	
			}
		}
	}
	
	void OnGUI() {
	    if (Event.current.type == EventType.MouseDown) {
	        DoTrigger();
	    }
	}
	 
	void DoTrigger() {
		
	    triggable.Trigger();
	    
	    if (removeOnClick) {
	    	GameObject.Destroy(this);
	    }
		
	}
}