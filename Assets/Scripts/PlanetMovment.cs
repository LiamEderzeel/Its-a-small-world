using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetMovment : MonoBehaviour
{
	public static float MovementSpeed
	{
		set{_movementSpeed = value;}
	}
	public static float ComboMultiplier
	{
		set{ _comboMultiplier = value;}
	}
	private static float _movementSpeed = 8;
	private static float _startSpeed;
	private bool _isLerping = false;
	private Vector3 _startPosition;
	public static float EndDepth{
		set{ _endDepth = value;}
	}
	private static float _endDepth;
	private int _lane = 0;
	private static float _comboMultiplier;
	private GameObject Pipe;
	private int _curentCombo;


	public int lane
	{
		get{ return _lane;}
		set{ _lane = value;}
	}

	protected GameObject _mainCamera;
	protected GettersAndSetters _gettersAndSetters;
	
	void Start ()
	{
		_startSpeed = _movementSpeed;
		_startPosition = GameObject.Find("Start"+lane).transform.position;
		GetComponent<Transform>().position = _startPosition;
		_mainCamera = GameObject.Find("Main Camera");

		Pipe = GameObject.Find("Pipe");
	}

	void Update ()
	{

		if(gameObject.transform.position.z <= _endDepth)
		{
			Destroy(gameObject, 0f);
		}
		if(!GameManager.Paused){
		GetComponent<Transform>().Translate(Vector3.forward * -Time.deltaTime * _movementSpeed);
		}
	}
 	public static void MultiplieSpeed(){
		_movementSpeed *= _comboMultiplier;
	}
	public static void ResetSpeed(){
		_movementSpeed = _startSpeed;
	}
}
