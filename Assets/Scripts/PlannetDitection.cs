using UnityEngine;
using System.Collections;

public class PlannetDitection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other) {
		if(other) {
			//coliding = true;
			print("working1");
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if(other) {
			print("working2");
		}
	}
}
