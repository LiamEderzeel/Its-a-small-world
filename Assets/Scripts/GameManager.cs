using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
	public float PlanetMovementSpeed;
	public int PlanetComboAmount;
	public float PlanetComboMultiplier;

	public float JumpForce;
	public float StompForce;

	public float SpawnTime;
	public int NumberOfLans;
	public float StartDepth;
	public float EndDepth;
	public float Radius;

	public int GameDuration;

	public static bool Paused{
		get{return _paused;}
		set{_paused = value;}
	}
	private static bool _paused = false;

	
	//Here is a private reference only this class can access
	private static GameManager _instance;
	
	//This is the public reference that other classes will use
	public static GameManager instance
	{
		get
		{
			//If _instance hasn't been set yet, we grab it from the scene!
			//This will only happen the first time this reference is used.
			if(_instance == null)
				_instance = GameObject.FindObjectOfType<GameManager>();
			return _instance;
		}
	}
	
	public void Awake()
	{
		PlanetMovment.MovementSpeed = PlanetMovementSpeed;
		PlanetMovment.ComboMultiplier = PlanetComboMultiplier;

		PlayerMovment.JumpForce = JumpForce;
		PlayerMovment.StompForce = StompForce;
		PlayerMovment.ComboAmount = PlanetComboAmount;
		PlanetMovment.EndDepth = EndDepth;

		PlanetTutorialMovment.MovementSpeed = PlanetMovementSpeed;

		PlanetSpawner.NumberOfLans = NumberOfLans;
		PlanetSpawner.GameDuration = GameDuration;
		PlanetSpawner.SpawnTime = SpawnTime;

		PipeGrid.NumberOfLans = NumberOfLans;
		PipeGrid.StartDepth= StartDepth;
		PipeGrid.Radius = Radius;
	}
	public void Start()
	{
		gameObject.SetActive(false);
	}
}