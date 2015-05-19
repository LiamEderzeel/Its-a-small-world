using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetSpawner : MonoBehaviour
{
	public GameObject planet;
	private float _spawnTime;
	private float _timer = 0f;
	private bool _spawn = false;
	private int plannetNumber = 1;
	private int randomLane;
	private GameObject Pipe;
	private PipeGrid otherScript;
	private int _numberOfLans = 0;
	private List<GameObject> _planets;

	protected GameObject _mainCamera;
	protected GettersAndSetters _gettersAndSetters;
	
	void Start ()
	{
		_mainCamera = GameObject.Find("Main Camera");
		_gettersAndSetters = _mainCamera.GetComponent<GettersAndSetters>();
		_planets = _gettersAndSetters.planets;
		_spawnTime = _gettersAndSetters.spawnTime;
		_numberOfLans = _gettersAndSetters.numberOfLans;
		_timer = Time.time + _spawnTime;
		Pipe = GameObject.Find("Pipe");
//		PipeGrid otherScript = Pipe.GetComponent<PipeGrid>();
//		NumberOfLans = otherScript.NumberOfLans;
	}
	void FixedUpdate ()
	{
		if(_spawn)
		{
			for(int i = 0; i < 6; i++)
			{
				bool spawnProbability = RandomBool();
				if(spawnProbability)
				{
					randomLane = (int)Random.Range(0f, _numberOfLans);
					GameObject obj1 = Instantiate(planet,new Vector3(0,0,0), Quaternion.identity) as GameObject;
					obj1.name = "Planet" + plannetNumber;
					obj1.transform.parent = transform;
					obj1.GetComponent<PlanetMovment>().lane = randomLane;
					_planets.Add(obj1);
					plannetNumber++;
					_spawn = false;
				}
			}
		}
		else
		{
			if(_timer <= Time.time)
			{
				_spawn = true;
				_timer = Time.time + _spawnTime;
			}
		}
	}
	bool RandomBool()
	{
		int prob = (int)Random.Range(0,100);
		if (prob < 20)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
