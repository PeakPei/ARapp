using System.Collections;
using UnityEngine;

public class EachObjectScript : MonoBehaviour {
	// Use this for initialization
	void OnCollisionEnter(Collision collision) {
		this.gameObject.tag = "Collided";
		GameObject.Find ("Objects").SendMessage("OnCollisionEnter", collision);
	} 
}
