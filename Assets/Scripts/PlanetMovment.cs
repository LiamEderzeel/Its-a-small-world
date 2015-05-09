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
	public float ComboMultiplier = 0.8f;
	private GameObject Player;
	private GameObject Pipe;
	private PlayerMovment PlayerMovment;
	private PlanetSpawner PlanetSpawner;
	private int PlanetCombo;
	public int ComboAmount = 2;
	public List<GameObject> Planets;
	
	void Start ()
	{
		startLerping();
		Player = GameObject.Find("Player");
		Pipe = GameObject.Find("Pipe");

	}
	void startLerping()
	{
		_isLerping = true;
		_timeStartedLerping = Time.time;
	}
	void Update ()
	{
		PlayerMovment PlayerMovment = Player.GetComponent<PlayerMovment>();
		PlanetCombo = PlayerMovment.PlanetCombo;
		PlanetSpawner = PlanetSpawner = Pipe.GetComponent<PlanetSpawner>();
		Planets = PlanetSpawner.Planets;

			_startPosition = GameObject.Find("Start"+lane).transform.position;
			_endPosition = GameObject.Find("End"+lane).transform.position;
		if(PlanetCombo > ComboAmount)
		{
			print(timeTakenDuringLerp);
			timeTakenDuringLerp = timeTakenDuringLerp * ComboMultiplier;
			PlayerMovment.PlanetCombo = 0;
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
