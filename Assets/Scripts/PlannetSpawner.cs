using UnityEngine;
using System.Collections;

public class PlannetSpawner : MonoBehaviour {

	public bool _isLerping = true;
	public float timeTakenDuringLerp = 1f;
	private float _timeStartedLerping;

	public float startDept = 10f;
	public float endDept = -5f;
	public float pipeRadius = 2f;
	public Vector3 start;
	public Vector3 end;
	public GameObject startO;
	public GameObject endO;

	// Use this for initialization
	void Start () {
		start += new Vector3(0, pipeRadius, startDept);
		end += new Vector3(0, pipeRadius, endDept);

		startO = GameObject.Find("Start");
		endO = GameObject.Find("End");
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
			transform.position = Vector3.Lerp(startO.transform.position, endO.transform.position, percentageComplete);

			if(percentageComplete >= 1.0f)
			{
				_isLerping = false;
			}
		}
	}
}
