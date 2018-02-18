using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsScript : MonoBehaviour {

	public GameObject Object1;
	public GameObject Object2;
	public GameObject Object3;
	public GameObject Object4;
	public GameObject Object5;
	public ScoreTextScript ScoreTextScript;

	// Use this for initialization
	void Start () {
		ScoreTextScript = GameObject.Find ("ScoreText").GetComponent<ScoreTextScript> ();
		Object1 = (GameObject)Resources.Load ("Prefab/Sphere");
		Object2 = (GameObject)Resources.Load ("Prefab/Cube");
		Object3 = (GameObject)Resources.Load ("Prefab/Capsule");
		Object4 = (GameObject)Resources.Load ("Prefab/Cylinder");
		Object5 = (GameObject)Resources.Load ("Prefab/Quad");
		Instantiate (Object1, generateNewPosition(), Quaternion.identity);
		Instantiate (Object2, generateNewPosition(), Quaternion.identity);
		Instantiate (Object3, generateNewPosition(), Quaternion.identity);
		Instantiate (Object4, generateNewPosition(), Quaternion.identity);
		Instantiate (Object5, generateNewPosition(), Quaternion.identity);
	}

	void OnCollisionEnter(Collision collision) {
		ScoreTextScript.score ++;
		GameObject collidedObject = GameObject.FindGameObjectsWithTag ("Collided") [0];
		if (ScoreTextScript.score > 15) {
			Destroy (collidedObject);
		} else {
			collidedObject.tag = "Objects";
			collidedObject.transform.position = generateNewPosition();
		}
	} 

	float generateRandom(){
		return Random.Range (-100,100);
	}
	//This is to prevent a new object from being too close to the existing objects and the bunny
	public Vector3 generateNewPosition (){
		GameObject[] objects = GameObject.FindGameObjectsWithTag ("Objects");
		bool flag1 = false;
		bool flag2 = false;
		Vector3 newPos = new Vector3 (generateRandom(),5,generateRandom());
		while (!flag1) {
			flag2 = false;
			newPos = new Vector3 (generateRandom (), 5, generateRandom ());
			foreach (GameObject obj in objects) {
				if (Vector3.Distance (obj.transform.position, newPos) < 60) {
					flag2 = true;
					break;
				}
			}
			if (!flag2 && Vector3.Distance (GameObject.Find ("nyuszi_14").transform.position, newPos) > 60) {
				flag1 = true;
			}
		}
		return newPos;
	}
}
