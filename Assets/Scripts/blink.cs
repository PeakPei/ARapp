using UnityEngine;
using System.Collections;

public class blink : MonoBehaviour {



	public Material Eye_1, Eye_2;
	public GameObject bunny;
	public Material[] bunnymats1,bunnymats2;



	// Use this for initialization
	void Start () {
		//bunnymats1 = bunny.GetComponent<Renderer>().materials;

		bunny.GetComponent<Renderer>().enabled = true;
		InvokeRepeating("Blink", 2.0f, 4.0f);

	}

	void Blink (){
		bunny.GetComponent<Renderer>().materials = bunnymats2;
		//bunnymats[1] = Eye_2;
		Invoke("NormalEye", 0.1f);

	}

	void NormalEye(){
		bunny.GetComponent<Renderer>().materials = bunnymats1;

	}



	// Update is called once per frame
	void Update () {



	
	}
}
