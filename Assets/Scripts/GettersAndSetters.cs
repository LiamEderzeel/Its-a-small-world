using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GettersAndSetters : MonoBehaviour {

	public float _jumpForce = 250f;
	public float _stompForce = 600f;
	public int _comboAmount = 2; 
	public float _comboMultiplier = 0.8f;
	private int _planetCombo = 0;
	public float _timeTakenDuringLerp = 8f;
	public List<GameObject> _planets = new List<GameObject>();
	public float _spawnTime = 1f;
	public int _numberOfLans = 8;
	public float _startDept = 20f;
	public float _endDept = -10f;
	public float _radius = 4f;

	public float jumpForce
	{
		get { return _jumpForce; }
		set { _jumpForce = value; }
	}
	public float stompForce
	{
		get { return _stompForce; }
		set { _stompForce = value; }
	}
	public int comboAmount
	{
		get { return _comboAmount; }
		set { _comboAmount = value; }
	}
	public float comboMultiplier
	{
		get { return _comboMultiplier; }
		set { _comboMultiplier = value; }
	}
	public int planetCombo
	{
		get { return _planetCombo; }
		set { _planetCombo = value; }
	}
	public float timeTakenDuringLerp
	{
		get { return _timeTakenDuringLerp; }
		set { _timeTakenDuringLerp = value; }
	}
	public List<GameObject> planets
	{
		get { return _planets; }
		set { _planets = value; }
	}
	public float spawnTime
	{
		get { return _spawnTime; }
		set { _spawnTime = value; }
	}
	public int numberOfLans
	{
		get { return _numberOfLans; }
		set { _numberOfLans = value; }
	}
	public float startDept
	{
		get { return _startDept; }
		set { _startDept = value; }
	}
	public float endDept
	{
		get { return _endDept; }
		set { _endDept = value; }
	}
	public float radius
	{
		get { return _radius; }
		set { _radius = value; }
	}
	
	void Start () {
	
	}

	void Update () {
	
	}
}
