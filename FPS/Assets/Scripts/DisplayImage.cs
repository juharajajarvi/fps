using UnityEngine;
using System.Collections;

public class DisplayImage : MonoBehaviour {
	
	public Texture image;
	public int width=693, height=368;
	public int startX=90, startY=90;
	public bool centerX = true;
	
	public bool isFadeOn = false;
	public float showTime=2f, fadeDuration=0.5f;
	private float fadeTime;
	
	private Color opacity;
	private int state;
	private Triggable triggable;
	
	// Use this for initialization
	void Start () {
		
		if (centerX) {
			startX = (int)(Screen.width/2f - width/2f);	
		}
		
		state = 0;
		opacity = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		fadeTime = fadeDuration;
		triggable = GetComponent<Triggable>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (isFadeOn) {
		
			if ( state == 0 ) {
				
				// Fade in
				fadeTime -= Time.deltaTime;
				opacity = new Color(1.0f, 1.0f, 1.0f, 1 - (fadeTime / fadeDuration) );
				if ( fadeTime < 0 ) {
					state = 1;
					fadeTime = fadeDuration; // for state 2
				}
				
			} 
			else if ( state == 1 ) {
				
				// Normal show
				opacity = new Color(1.0f, 1.0f, 1.0f, 1.0f );
				showTime -= Time.deltaTime;
				if (showTime < 0 ) {
					state = 2;
				}
				
			} 
			else if ( state == 2 ) {
				
				// Fade out
				fadeTime -= Time.deltaTime;
				opacity = new Color(1.0f, 1.0f, 1.0f, fadeTime / fadeDuration );
				if ( fadeTime < 0 ) {
					triggable.Trigger();
				}
			}
			
		}

	}

	void OnGUI() {
		GUI.color = opacity;
		GUI.DrawTexture( new Rect(startX, startY, width, height), image );
	}
	
}