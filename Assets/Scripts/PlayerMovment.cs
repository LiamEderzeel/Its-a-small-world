using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour
{
	public float JumpForce = 0;
	public float StompForce = 0;
	private bool CollisionCap = false;
	private bool Stomp = true;
	private int PlannetCombo = 0;
	public bool start = false;
	private Vector3 startLocation;

    void Start()
	{
		startLocation = gameObject.transform.position;
    }
	void Update()
	{

	}
	void FixedUpdate()
	{
		if(Input.GetKeyDown(KeyCode.Space) && !start){
			start = true;
		}
		if(!start)
		{
			gameObject.GetComponent<Rigidbody>().AddForce(transform.up * 3);
		}
		else
		{
			if(Input.GetKeyDown(KeyCode.Space) && Stomp)
			{
				Stomp = false;
				gameObject.GetComponent<Rigidbody>().AddForce(transform.up * -StompForce);
			}
			if(gameObject.transform.position.y <= -5f)
			{
				gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
				gameObject.transform.position = startLocation;
				StartCoroutine (Reset());
				start = false;
			}
		}
    }
	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider && !CollisionCap && collision.gameObject.tag == "Planet")
		{
			Debug.Log("hit");
			PlannetCombo++;
			CollisionCap = true;
			gameObject.GetComponent<Rigidbody>().AddForce(transform.up * JumpForce);
			StartCoroutine (Reset());
		}
	}
	IEnumerator Reset()
	{
		yield return new WaitForSeconds (0.1f);
		CollisionCap = false;
		Stomp = true;
	}
}