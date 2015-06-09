using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetSpawner : MonoBehaviour
{
	private GameObject _planet;
	private GameObject _endPlanet;
	private float _spawnTime;
	private float _timer = 0f;
	private bool _spawn = false;
	private int plannetNumber = 1;
	private int randomLane;
	private int randomTexture;
	private GameObject Pipe;
	private PipeGrid otherScript;
	private int _numberOfLans = 0;
	private List<GameObject> _planets;
	public Texture[] textures;
	protected GameObject _mainCamera;
	protected GettersAndSetters _gettersAndSetters;
	
	void Start ()
	{
		_mainCamera = GameObject.Find ("Main Camera");
		_gettersAndSetters = _mainCamera.GetComponent<GettersAndSetters> ();
		_planets = _gettersAndSetters.planets;
		_spawnTime = _gettersAndSetters.spawnTime;
		_numberOfLans = _gettersAndSetters.numberOfLans;
		_timer = Time.time + _spawnTime;
		Pipe = GameObject.Find ("Pipe");
		_planet = (GameObject)Resources.Load ("Planet", typeof(GameObject));
		_endPlanet = (GameObject)Resources.Load ("EndPlanet", typeof(GameObject));
//		PipeGrid otherScript = Pipe.GetComponent<PipeGrid>();
//		NumberOfLans = otherScript.NumberOfLans;
	}

	void FixedUpdate ()
	{
		if (_spawn) {
			if (plannetNumber > 10f) {
				GameObject obj1 = Instantiate (_endPlanet, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
				obj1.name = "EndPlanet";
				obj1.transform.parent = transform;
				obj1.GetComponent<PlanetMovment> ().lane = 0;
				plannetNumber++;
				_spawn = false;
			} else {
				for (int i = 0; i < 6; i++) {
					bool spawnProbability = RandomBool ();
					if (spawnProbability) {
						randomLane = (int)Random.Range (0f, _numberOfLans);
						randomTexture = (int)Random.Range (0f, textures.Length);
						GameObject obj1 = Instantiate (_planet, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
						obj1.name = "Planet" + plannetNumber;
						obj1.transform.parent = transform;
						obj1.GetComponent<PlanetMovment> ().lane = randomLane;
						obj1.GetComponent<Renderer> ().material.mainTexture = textures [randomTexture];
						_planets.Add (obj1);
						plannetNumber++;
						_spawn = false;
					}
				}
			}
		} else {
			if (plannetNumber <= 11f) {
				if (_timer <= Time.time) {
					_spawn = true;
					_timer = Time.time + _spawnTime;
				}
			}
		}
	}

	bool RandomBool ()
	{
		int prob = (int)Random.Range (0, 100);
		if (prob < 20) {
			return true;
		} else {
			return false;
		}
	}
}
