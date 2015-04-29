using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float JumpForce = 0;
	public float StompForce = 0;
 
    
 
    void Start()
	{
        
    }
	void Update()
	{

	}
	void FixedUpdate()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			gameObject.GetComponent<Rigidbody>().AddForce(transform.up * -StompForce);
		}
    }
	void OnCollisionEnter(Collision collision)
	{
		bool collisioncap = false;
		if(collision.collider)
		{
			collisioncap = true;
			print("colission!)");
			gameObject.GetComponent<Rigidbody>().AddForce(transform.up * JumpForce);
		}
	}
}