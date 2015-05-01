using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
	public float toVel = 2.5f;
	public float maxVel = 15.0f;
	public float maxForce = 40.0f;
	public float gain = 5f;
	public GameObject Target;
	private bool action = false;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKey(KeyCode.A))
		{
			action = true;
		}
	}

	void FixedUpdate()
	{
		print(action);
		if(action)
		{
			Vector3 dist = Target.transform.position - transform.position;
			dist.x = 0;
			dist.z = 0;// ignore height differences
			// calc a target vel proportional to distance (clamped to maxVel)
			Vector3 tgtVel = Vector3.ClampMagnitude(toVel * dist, maxVel);
			// calculate the velocity error
			Vector3 error = tgtVel - GetComponent<Rigidbody>().velocity;
			// calc a force proportional to the error (clamped to maxForce)
			Vector3 force = Vector3.ClampMagnitude(gain * error, maxForce);
			GetComponent<Rigidbody>().AddForce(force);
			if(gameObject.transform.position == Target.transform.position)
			{
				action = false;
			}
		}
	}
}


