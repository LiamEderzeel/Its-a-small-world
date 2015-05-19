using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour
{
	private float _jumpForce;
	private float _stompForce;
	private bool _collisionCap = false;
	private bool _stomp = true;
	private int _planetCombo;
	private bool _start = false;
	private Vector3 _startLocation;
	protected GameObject _mainCamera;
	protected GettersAndSetters _gettersAndSetters;

    void Start()
	{
		_mainCamera = GameObject.Find("Main Camera");
		_gettersAndSetters = _mainCamera.GetComponent<GettersAndSetters>();
		_jumpForce = _gettersAndSetters.jumpForce;
		_stompForce = _gettersAndSetters.stompForce;
		_startLocation = gameObject.transform.position;
    }
	void Update()
	{

	}
	void FixedUpdate()
	{
		if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && !_start)
		{
			_start = true;
		}
		if(!_start)
		{
			gameObject.GetComponent<Rigidbody>().AddForce(transform.up * 3);
		}
		else
		{
			if((Input.GetKeyDown(KeyCode.Space)  || Input.GetKeyDown(KeyCode.Joystick1Button0))&& _stomp)
			{
				_stomp = false;
				gameObject.GetComponent<Rigidbody>().AddForce(transform.up * -_stompForce);
			}
			if(gameObject.transform.position.y <= -5f)
			{
				gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
				gameObject.transform.position = _startLocation;
				_gettersAndSetters.planetCombo = 0;
				StartCoroutine (Reset());
				_start = false;
			}
		}
    }
	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider && !_collisionCap && collision.gameObject.tag == "Planet")
		{
			_gettersAndSetters.planetCombo++;
			_collisionCap = true;
			gameObject.GetComponent<Rigidbody>().AddForce(transform.up * _jumpForce);
			StartCoroutine (Reset());
		}
	}
	IEnumerator Reset()
	{
		yield return new WaitForSeconds (0.1f);
		_collisionCap = false;
		_stomp = true;
	}
}