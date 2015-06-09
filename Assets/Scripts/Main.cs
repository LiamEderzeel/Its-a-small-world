using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	public bool SkipIntro;
	private enum GameState {Game=1, Intro=2, Outro=3, Menu=0};
	private static GameState _gameState;

	private static GameObject _gameManager;
	private static GameObject _intro;
	private static GameObject _outro;
	private static GameObject _menu;

	private static Main _instance;
	
	//This is the public reference that other classes will use
	public static Main instance
	{
		get
		{
			//If _instance hasn't been set yet, we grab it from the scene!
			//This will only happen the first time this reference is used.
			if(_instance == null)
				_instance = GameObject.FindObjectOfType<Main>();
			return _instance;
		}
	}
	void Awake()
	{
		_gameManager = GameObject.Find ("GameManager");
		_gameManager.SetActive(false);
		_intro = GameObject.Find ("IntroVideo");
		_intro.SetActive(false);
		_outro = GameObject.Find ("OutroVideo");
		_outro.SetActive(false);
		_menu = GameObject.Find ("Menu");
		_menu.SetActive(false);
	}

	// Use this for initialization
	void Start () {
		ToMenu();

	}
	
	// Update is called once per frame
	void Update () {
		switch(_gameState)
		{
		case GameState.Game:
			_gameManager.SetActive(true);
			break;
		case GameState.Intro:
			if(SkipIntro){
				ToGame();
			} else{
				_intro.SetActive(true);
			}

			break;
		case GameState.Outro:
			_outro.SetActive(true);
			break;
		default:
			_menu.SetActive(true);
			break;
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {  
			ResetGame();
		}
		if (Input.GetKeyDown (KeyCode.L)) {  
			if(GameManager.Paused){
				GameManager.Paused = false;
			} else {
				GameManager.Paused = true;
			}
		}

	}
	public static void ToGame()
	{
		FreshState();
		_gameState = GameState.Game;
	}
	public static void ToIntro()
	{
		FreshState();
		_gameState = GameState.Intro;
	}
	public static void ToOutro()
	{
		FreshState();
		_gameState = GameState.Outro;
	}
	public static void ToMenu()
	{
		FreshState();
		_gameState = GameState.Menu;
	}
	private static void FreshState (){
		_gameManager.SetActive(false);
		_intro.SetActive(false);
		_outro.SetActive(false);
		_menu.SetActive(false);
	}
	public static void ResetGame()
	{
		Application.LoadLevel (0);
	}
}
