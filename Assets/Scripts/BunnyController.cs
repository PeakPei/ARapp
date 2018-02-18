using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using DG.Tweening;

public class BunnyController: MonoBehaviour {
	public TimerTextScript TimerTextScript;
	public GUIText message = null;
	public Ray ray;
	public RaycastHit hit;
	public NavMeshAgent bunny;
	public Vector3 destination;
	public Animation anime;

	void Start () {
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag ("Objects")) {
			Destroy (obj);
		}
	 	bunny = GetComponent<NavMeshAgent>();
		anime = GetComponent<Animation> ();
		transform.position = new Vector3 (0, 0, 0);
	}

	void Update () {
		if (!TimerTextScript.startGame) {
			bunny.ResetPath();
			transform.DORotate (new Vector3(0,180,0),1);
			anime.Play ("Idle");
			bunny.isStopped=true;
			destination = new Vector3 (0, 0, 0);
		}
		if (TimerTextScript.startGame){
			if (Input.touchCount > 0){		
				Touch touch = Input.GetTouch (0);
				if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Moved ) {
					ray = Camera.main.ScreenPointToRay (Input.mousePosition);
					if (Physics.Raycast (ray, out hit)) {
						destination = hit.point;
						moveTo (destination);
					}
				}
			}
			if (isFar(destination)) {
				anime.Play ("Walk");
			}else{
				transform.DORotate (new Vector3(0,180,0),2f);
				anime.Play ("Idle");
			}
		}

	}

	protected void moveTo(Vector3 destination){	
		bunny.ResetPath();	
		transform.DORotate (new Vector3 (0, Mathf.Atan2 (destination.x - transform.position.x, destination.z - transform.position.z) * Mathf.Rad2Deg, 0), 2f);
		bunny.SetDestination (destination);	
		bunny.isStopped=false; 
	}

	protected bool isFar(Vector3 destination){
		if (Mathf.Abs (destination.x - transform.position.x) > 0.3f || Mathf.Abs (destination.z - transform.position.z) > 0.3f ) {
			return true;
		} else {
			return false; 
		}
	}
}
