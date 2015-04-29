using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    Vector3 startPos;
 
    public float amplitude = 3f;
    public float period = 2f;
	private bool colliding = false;
	private float distance = 0;
 
    protected void Start() {
        startPos = transform.position;
    }

	void Update() {
		if(!(distance > 0.1) && colliding)
		{
			print("hit");
		} else if(!(distance > 0.1)) {
			print("miss");
		}
	}
 
	protected void FixedUpdate() {
		float theta = Time.time / period ;
		//float distance = Mathf.Abs(amplitude * Mathf.Sin(theta));
		distance = amplitude * Mathf.Abs(Mathf.Sin( Mathf.PI * theta ));
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