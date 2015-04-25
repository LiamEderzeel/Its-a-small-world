using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public bool _isLerping = false;
	public float timeTakenDuringLerp = 4f;
	private float _timeStartedLerping;
	public float target = 3f;
	private Vector3 _startPosition;
	private Vector3 _endPosition;

	// Use this for initialization
	void Start () {
		startLerping();
	}
	
	// Update is called once per frame
	void Update () {
		//y = jumpHT * Mathf.Sin( Mathf.PI * ((Time.time - startTime)/duration) );
		//transform.position = Vector3.Lerp (transform.position, target, (Time.time - startTime) / duration);

	}
	void OnTriggerEnter(Collider other) {

	}
	void FixedUpdate()
	{
		if(_isLerping)
		{
			float timeSinceStarted = Time.time - _timeStartedLerping;
			float percentageComplete = timeSinceStarted / timeTakenDuringLerp;
			percentageComplete = Mathf.Sin(percentageComplete * Mathf.PI * 0.5f);
			//percentageComplete = 1f - Mathf.Cos(percentageComplete * Mathf.PI * 0.5f);
			print(percentageComplete);

			transform.position = Vector3.Lerp(_startPosition, _endPosition, percentageComplete);

			if(percentageComplete >= 1.0f)
			{
				Vector3 temp  =  _startPosition;
				_startPosition = _endPosition;
				_endPosition = temp;
				percentageComplete = 0f;
			}
		}
	}
	void startLerping()
	{
		print(_isLerping);
		_isLerping = true;
		_timeStartedLerping = Time.time;
		_startPosition = transform.position;
		_endPosition = transform.position += new Vector3(0, target, 0);
	}
}

