using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartTextScript : MonoBehaviour {
	public Text startText;
	public ScoreTextScript ScoreTextScript;
	public TimerTextScript TimerTextScript;
	private float width;
	private float height;
	// Use this for initialization
	void Start () {
		width = transform.GetComponent<RectTransform> ().sizeDelta.x;
		height = transform.GetComponent<RectTransform> ().sizeDelta.y;
		startText.text="START!";
	}
	
	void Update() {
		if (Input.touchCount > 0 && !TimerTextScript.startGame) {
			Touch touch = Input.GetTouch (0);
			if (TouchText(touch.position,width,height)&&!TimerTextScript.startTimer) {
				GameObject.Find ("TimerText").SendMessage ("Start");
				TimerTextScript.startTimer = true;
				ScoreTextScript.score = 0;
				TimerTextScript.startTime = Time.time;
				GameObject.Find ("nyuszi_14").SendMessage ("Start");
				GameObject.Find ("Objects").SendMessage ("Start");
				startText.text="";
			}
		}
	}

	bool TouchText(Vector3 touch, float width, float height){
		if (transform.position.x - width  < touch.x && touch.x < transform.position.x + width  && touch.y > transform.position.y - height / 2 && touch.y < transform.position.y + height / 2) {
			return true;
		} else {
			return false; 
		}
	}
}
