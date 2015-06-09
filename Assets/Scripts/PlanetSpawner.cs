using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetSpawner : MonoBehaviour
{
	private GameObject _planet;
	private GameObject _endPlanet;
	public static float SpawnTime{
		set{_spawnTime = value;}
	}
	private static float _spawnTime;
	private float _timer = 0f;
	private bool _spawn = false;
	private int plannetNumber = 1;
	private int randomLane;
	private int randomTexture;
	private GameObject Pipe;
	private PipeGrid otherScript;

	public static int NumberOfLans {
		set{ _numberOfLans = value;}
	}

	private static int _numberOfLans;

	public static int GameDuration {
		set{ _gameDuraion = value;}
	}

	private static int _gameDuraion;
	private List<GameObject> _planets;
	public Texture[] textures;
	protected GameObject _mainCamera;
	protected GettersAndSetters _gettersAndSetters;
	private bool _paused;
	private bool _diverensKnown;
	private bool _diverensAplied = false;
	private float _timerDivrens;

	void Start ()
	{
		_mainCamera = GameObject.Find ("Main Camera");
		_gettersAndSetters = _mainCamera.GetComponent<GettersAndSetters> ();
		_planets = _gettersAndSetters.planets;
		_timer = Time.time + _spawnTime;
		Pipe = GameObject.Find ("Pipe");
		_planet = (GameObject)Resources.Load ("Planet", typeof(GameObject));
		_endPlanet = (GameObject)Resources.Load ("EndPlanet", typeof(GameObject));
//		PipeGrid otherScript = Pipe.GetComponent<PipeGrid>();
//		NumberOfLans = otherScript.NumberOfLans;
	}

	void FixedUpdate ()
	{
		if (!GameManager.Paused) {
			if (!_diverensAplied) {
				StartCoroutine("AplieDiverens");
			}else if (_spawn)
			{
				if (plannetNumber >= _gameDuraion) {
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
							randomLane = (int)Random.Range (1f, _numberOfLans);
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
				if (plannetNumber <= _gameDuraion + 1) {
					if (_timer <= Time.time) {
						_spawn = true;
						_timer = Time.time + _spawnTime;
					}
				}
			}
		} else {
			if (!_diverensKnown) {
				StartCoroutine("CalcDiverens");
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

	IEnumerator CalcDiverens ()
	{
		_timerDivrens = _timer - Time.time;
		_diverensAplied = false;
		_diverensKnown = true;
		//Debug.Log ("Diverens Calculated" + _timerDivrens);
		yield return null;
	}

	IEnumerator AplieDiverens ()
	{
		_timer = Time.time + _timerDivrens;
		_diverensAplied = true;
		_diverensKnown = false;
		_spawn = false;
		//.Log ("Diverens Aplied");
		yield return null;
	}
}
