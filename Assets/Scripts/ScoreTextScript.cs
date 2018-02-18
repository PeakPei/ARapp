using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour {
	public Text scoreText;
	public int score;
	public int goal;

	void Start(){
		score = 0;
		goal = 20;
	}
	void Update () {
		if (score == goal) {
			scoreText.text = "CLEAR!";
		}else {
			scoreText.text = "SCORE:" + score.ToString ();
		}
	}
}
