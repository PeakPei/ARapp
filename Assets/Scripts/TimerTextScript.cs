using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class TimerTextScript : MonoBehaviour {
	public Text timerText;
	public ScoreTextScript ScoreTextScript;
	float timeLimit;
	float gameStartTime;
	public float startTime;
	public bool  startTimer= false;
	public bool startGame = false;

	// Use this for initialization

	void Start(){
		timeLimit = 120f;
		gameStartTime = timeLimit - 0.5f;
		timerText.text = convert2String (timeLimit);

	}

	// Update is called once per frame
	void Update () {
		if (startTimer) {
			if (ScoreTextScript.score == ScoreTextScript.goal) {
				finish();
			}
			float time = timeLimit - (Time.time - startTime);
			if (time > 0) {
				timerText.text = convert2String (time);
			} else {
				timerText.text = "Time Over";
				finish ();
			}
			if (convert2String (time) == convert2String (gameStartTime))//This is to ignore first touch which is to start the timer. 
				startGame = true;
		}
	}

	void finish(){
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag ("Objects")) {
			Destroy (obj);
		}
		startTimer = false;
		startGame = false;
		GameObject.Find ("StartText").SendMessage ("Start");
	}

	string convert2String(float time){
		string min = ((int)time / 60).ToString ();
		string sec = (time % 60).ToString ("f1");
		if (sec.Length < 4) //show 2:5 as 2:05
			sec = "0" + sec;
		return  min + ":" + sec;
	}
}
