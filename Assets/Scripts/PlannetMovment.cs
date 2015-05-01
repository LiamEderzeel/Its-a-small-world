using UnityEngine;
using System.Collections;

public class PlannetMovment : MonoBehaviour
{
	public bool _isLerping = false;
	public float timeTakenDuringLerp = 6f;
	private float _timeStartedLerping;
	private Vector3 _startPosition;
	private Vector3 _endPosition;
	private int randomLane = 0;
	public int lane = 0;

	// Use this for initialization
	void Start ()
	{
		startLerping();
	}
	void startLerping()
	{
		_isLerping = true;
		_timeStartedLerping = Time.time;
	}
	// Update is called once per frame
	void Update ()
	{
			_startPosition = GameObject.Find("Start"+lane).transform.position;
			_endPosition = GameObject.Find("End"+lane).transform.position;
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
				Destroy(gameObject);
			}
		}
	}
}
