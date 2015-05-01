using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float JumpForce = 0;
	public float StompForce = 0;
	private bool collisioncap = false;
	private bool jump = true;

    void Start()
	{
        
    }
	void Update()
	{
		if(gameObject.transform.position.y > 5f)
		{
			gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
		print(jump);
	}
	void FixedUpdate()
	{
		if(Input.GetKey(KeyCode.Space) && jump)
		{
			jump = false;
			gameObject.GetComponent<Rigidbody>().AddForce(transform.up * -StompForce);
		}
    }
	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider && !collisioncap)
		{
			jump = true;
			collisioncap = true;
			gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
			gameObject.GetComponent<Rigidbody>().AddForce(transform.up * JumpForce);
			Invoke("collisioncapvoid", 0.5f);
		}
	}
	void collisioncapvoid()
	{
		collisioncap = false;
	}
}