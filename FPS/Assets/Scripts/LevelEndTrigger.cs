using UnityEngine;
using System.Collections;

public class LevelEndTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider collider) {
		if ( collider.name == "Player") {
			Application.LoadLevel("world_saved");	
		}
	}
}
