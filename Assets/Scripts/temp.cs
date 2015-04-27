using UnityEngine;
using System.Collections;

public class temp : MonoBehaviour {

    Vector3 startPos;
 
    public float amplitude = 3f;
    public float period = 2f;
	private bool colliding = false;
 
    protected void Start() {
        startPos = transform.position;
    }

	void Update() {

	}
 
	protected void FixedUpdate() {
		float theta = Time.time / period ;
		//float distance = Mathf.Abs(amplitude * Mathf.Sin(theta));
		float distance = amplitude * Mathf.Abs(Mathf.Sin( Mathf.PI * theta ));
        transform.position = startPos + Vector3.up * distance;
    }

	void OnTriggerStay(Collider other) {
		if(other.tag == "Plannet") {
			colliding = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.tag == "Plannet") {
			colliding = false;
		}
	}
}