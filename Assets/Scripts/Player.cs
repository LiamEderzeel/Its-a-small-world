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
		//print(jump);
	}
	void FixedUpdate()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log(jump);
		}
		if(Input.GetKeyDown(KeyCode.Space) && jump)
		{
			jump = false;
			gameObject.GetComponent<Rigidbody>().AddForce(transform.up * -StompForce);
		}
    }
	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider && !collisioncap)
		{

			collisioncap = true;
			gameObject.GetComponent<Rigidbody>().AddForce(transform.up * JumpForce);
			StartCoroutine (Reset ());
		}
	}
	IEnumerator Reset()
	{
		yield return new WaitForSeconds (0.1f);
		collisioncap = false;
		jump = true;
	}
}