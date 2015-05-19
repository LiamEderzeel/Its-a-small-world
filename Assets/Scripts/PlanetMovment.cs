using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetMovment : MonoBehaviour
{
	private bool _isLerping = false;
	private float _timeTakenDuringLerp;
	private float _timeStartedLerping;
	private Vector3 _startPosition;
	private Vector3 _endPosition;
	private int _lane = 0;
	private float _comboMultiplier;
	private GameObject Pipe;
	private PlayerMovment PlayerMovment;
	private PlanetSpawner PlanetSpawner;
	private int _planetCombo;
	private int _comboAmount;
	private List<GameObject> _planets;
	public int lane
	{
		get{ return _lane;}
		set{ _lane = value;}
	}

	protected GameObject _mainCamera;
	protected GettersAndSetters _gettersAndSetters;
	
	void Start ()
	{
		_mainCamera = GameObject.Find("Main Camera");
		_gettersAndSetters = _mainCamera.GetComponent<GettersAndSetters>();
		_comboMultiplier = _gettersAndSetters.comboMultiplier;
		_comboAmount = _gettersAndSetters.comboAmount;
		_timeTakenDuringLerp = _gettersAndSetters.timeTakenDuringLerp;

		startLerping();

		Pipe = GameObject.Find("Pipe");

	}
	void startLerping()
	{
		_isLerping = true;
		_timeStartedLerping = Time.time;
	}
	void Update ()
	{
		_planets = _gettersAndSetters.planets;
		_planetCombo = _gettersAndSetters.planetCombo;
		PlanetSpawner = PlanetSpawner = Pipe.GetComponent<PlanetSpawner>();
		//_planets = PlanetSpawner.Planets;

			_startPosition = GameObject.Find("Start"+lane).transform.position;
			_endPosition = GameObject.Find("End"+lane).transform.position;
		if(_planetCombo > _comboAmount)
		{
			_timeTakenDuringLerp = _timeTakenDuringLerp * _comboMultiplier;
			_gettersAndSetters.planetCombo = 0;
			foreach(GameObject Planet in _gettersAndSetters.planets)
			{
				Planet.GetComponent<PlanetMovment>()._timeTakenDuringLerp = _timeTakenDuringLerp;
			}
		}
	}
	void FixedUpdate()
	{
		if(_isLerping)
		{
			float timeSinceStarted = Time.time - _timeStartedLerping;
			float percentageComplete = timeSinceStarted / _timeTakenDuringLerp;
			transform.position = Vector3.Lerp(_startPosition, _endPosition, percentageComplete);
			if(percentageComplete >= 1.0f)
			{
				_isLerping = false;
				_planets.Remove(gameObject);
				Destroy(gameObject);
			}
		}
	}

}
