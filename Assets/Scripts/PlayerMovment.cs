using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour
{
	public static float JumpForce
	{
		set{ _jumpForce = value;}
	}
	public static float StompForce
	{
		set{ _stompForce = value;}
	}
	public static int CurentCombo
	{
		get{return _curentCombo;}
		//set{_curentCombo = value;}
	}
	public static int ComboAmount
	{
		set{ _comboAmount = value;}
	}
	private static int _comboAmount;
	private static float _jumpForce;
	private static float _stompForce;
	private bool _collisionCap = false;
	private bool _stomp = true;
	private static int _curentCombo;
	private bool _start = false;
	private Vector3 _startLocation;
	protected GameObject _mainCamera;
	protected GettersAndSetters _gettersAndSetters;

    void Start()
	{
		_mainCamera = GameObject.Find("Main Camera");
		_gettersAndSetters = _mainCamera.GetComponent<GettersAndSetters>();
		_startLocation = gameObject.transform.position;
    }
	void Update()
	{

	}
	void Combo()
	{
		if(_curentCombo % _comboAmount == 0)
		{
			PlanetMovment.MultiplieSpeed();
			Debug.Log("Multiplie");
		}
	}
	void FixedUpdate()
	{
		gameObject.GetComponent<Transform>().Rotate(Vector3.up * Time.deltaTime * 6);
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
				gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
				gameObject.GetComponent<Rigidbody>().AddForce(transform.up * -_stompForce);
			}
			if(gameObject.transform.position.y <= -8f)
			{
				_start = false;
				gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
				gameObject.transform.position = _startLocation;
				_gettersAndSetters.planetCombo = 0;
				_curentCombo = 0;
				PlanetMovment.ResetSpeed();
				Debug.Log("Reset");
				StartCoroutine (Reset());

			}
		}
    }
	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider && !_collisionCap && collision.gameObject.tag == "Planet")
		{
			_gettersAndSetters.planetCombo++;
			_collisionCap = true;
			gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
			gameObject.GetComponent<Rigidbody>().AddForce(transform.up * _jumpForce);
			_curentCombo ++;
			Combo();
			StartCoroutine (Reset());
		}
		if(collision.collider && collision.gameObject.name == "EndPlanet")
		{
			Main.ToOutro();
		}
	}
	IEnumerator Reset()
	{
		yield return new WaitForSeconds (0.01f);
		_collisionCap = false;
		_stomp = true;
	}
}