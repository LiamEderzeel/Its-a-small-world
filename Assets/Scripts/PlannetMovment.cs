using UnityEngine;
using System.Collections;

public class PlannetMovment : MonoBehaviour {

	public bool _isLerping = false;
	public float timeTakenDuringLerp = 1f;
	private float _timeStartedLerping;

//	public Vector3[] start;
//	public Vector3[] end;
	private GameObject Pipe;
	private PipeGrid otherScript;
	private Vector3 _startPosition;
	private Vector3 _endPosition;

	// Use this for initialization
	void Start () {
		Pipe = GameObject.Find("Pipe");
		PipeGrid otherScript = Pipe.GetComponent<PipeGrid>();

		int randomLane = (int)Random.Range(0f, otherScript.NumberOfLans-1);
		_startPosition = otherScript.start[randomLane];
		_endPosition = otherScript.end[randomLane];
		startLerping();
	}
	void startLerping()
	{
		_isLerping = true;
		_timeStartedLerping = Time.time;

	}
	
	// Update is called once per frame
	void Update () {

	}
	void FixedUpdate()
	{
		if(_isLerping)
		{
			float timeSinceStarted = Time.time - _timeStartedLerping;
			float percentageComplete = timeSinceStarted / (timeTakenDuringLerp*6);
			transform.position = Vector3.Lerp(_startPosition, _endPosition, percentageComplete);
			if(percentageComplete >= 1.0f)
			{
				_isLerping = false;
				Destroy(gameObject);
			}
		}
	}
}
