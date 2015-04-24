using UnityEngine;
using System.Collections;

public class PipeController : MonoBehaviour {
	public float speed = 60.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			print("Left");
			gameObject.transform.Rotate(Vector3.forward * speed * Time.deltaTime);
		}
		else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			print("Right");
			gameObject.transform.Rotate(-Vector3.forward * speed * Time.deltaTime);
		}
	}
}
