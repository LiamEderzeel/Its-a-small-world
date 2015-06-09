using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour
{

	private int _tutorialStage = 0;
	private bool _hitPlanet = false;
	private bool _paused = false;
	
	void Start ()
	{
		
	}

	void Update ()
	{
		switch (_tutorialStage) {
		case 0:
			if (!_paused) {
				StartCoroutine (PauseInSecont (2.4f));
			}
			if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.Joystick1Button0)) {

			}
			if (_hitPlanet) {
				StartCoroutine (NextStage ());
			}
			break;
		case 1:
			if (!_paused) {
				StartCoroutine (PauseInSecont (2f));
			}
			if (_hitPlanet) {
				StartCoroutine (NextStage ());
			}
			break;
		case 2:
			if (!_paused) {
				StartCoroutine (PauseInSecont (2f));
			}
			if (_hitPlanet) {
				StartCoroutine (NextStage ());
			}
			break;
		case 3:
			if (_hitPlanet) {
				StartCoroutine (NextStage ());
			}
			break;
		case 4:
			if (!_paused) {
				PlayerMovment.StompControlles = true;
				PipeController.RotationControlles = true;
			}
			break;
		}
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.collider && collision.gameObject.tag == "Planet") {

			_hitPlanet = true;
		}
	}

	IEnumerator PauseInSecont (float time)
	{
		_paused = true;
		yield return new WaitForSeconds (time);
		GameManager.Paused = true;
		PlayerMovment.Gravity = false;
		gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		PlayerMovment.StompControlles = true;
		PipeController.RotationControlles = true;
	}

	IEnumerator NextStage ()
	{
		_hitPlanet = false;
		_tutorialStage ++;
		_paused = false;
		//PlayerMovment.StompControlles = false;
		PipeController.RotationControlles = false;
		GameManager.Paused = false;
		yield return null;
	}
}