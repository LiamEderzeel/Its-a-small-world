using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetMovment : MonoBehaviour
{
	public bool _isLerping = false;
	public float timeTakenDuringLerp = 8f;
	private float _timeStartedLerping;
	private Vector3 _startPosition;
	private Vector3 _endPosition;
	public int lane = 0;
	private float _comboMultiplier;
	private GameObject Pipe;
	private PlayerMovment PlayerMovment;
	private PlanetSpawner PlanetSpawner;
	private int _planetCombo;
	private int _comboAmount;
	public List<GameObject> Planets;

	protected GameObject _mainCamera;
	protected GettersAndSetters GettersAndSetters;
	
	void Start ()
	{
		_mainCamera = GameObject.Find("Main Camera");
		GettersAndSetters GettersAndSetters = _mainCamera.GetComponent<GettersAndSetters>();
		_comboMultiplier = GettersAndSetters.comboMultiplier;
		_comboAmount = GettersAndSetters.comboAmount;
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
		GettersAndSetters GettersAndSetters = _mainCamera.GetComponent<GettersAndSetters>();
		_planetCombo = GettersAndSetters.planetCombo;
		PlanetSpawner = PlanetSpawner = Pipe.GetComponent<PlanetSpawner>();
		Planets = PlanetSpawner.Planets;

			_startPosition = GameObject.Find("Start"+lane).transform.position;
			_endPosition = GameObject.Find("End"+lane).transform.position;
		if(_planetCombo > _comboAmount)
		{
			print(timeTakenDuringLerp);
			timeTakenDuringLerp = timeTakenDuringLerp * _comboMultiplier;
			GettersAndSetters.planetCombo = 0;
			print(timeTakenDuringLerp);
			foreach(GameObject Planet in Planets)
			{
				Planet.GetComponent<PlanetMovment>().timeTakenDuringLerp = timeTakenDuringLerp;
			}
		}
	}
	void FixedUpdate()
	{
		if(_isLerping)
		{
			float timeSinceStarted = Time.time - _timeStartedLerping;
			float percentageComplete = timeSinceStarted / timeTakenDuringLerp;
			transform.position = Vector3.Lerp(_startPosition, _endPosition, percentageComplete);
			if(percentageComplete >= 1.0f)
			{
				_isLerping = false;
				Planets.Remove(gameObject);
				Destroy(gameObject);
			}
		}
	}
}
