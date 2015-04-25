using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float thrust = 300f;
	private Rigidbody rb;
	private Vector3 force;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			rb.AddForce(Vector3.up * thrust);
			print("kanker");
		}
	}
	void OnTriggerEnter(Collider other) {
		if(other)
		{
			rb.AddForce(Vector3.up * thrust);
		}
	} 
}
