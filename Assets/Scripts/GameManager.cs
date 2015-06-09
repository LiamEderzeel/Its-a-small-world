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
	public float NumberOfLanes;
	public float StartDepth;
	public float EndDepth;

	
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
	}
}