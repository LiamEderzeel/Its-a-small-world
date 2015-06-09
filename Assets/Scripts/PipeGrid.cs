using UnityEngine;
using System.Collections;

public class PipeGrid : MonoBehaviour {

	public bool visualisation = false;
	public static int NumberOfLans{
		set{_numberOfLans = value;}
	}
	private static int _numberOfLans;
	public static float Radius{
		set{_radius = value;}
	}
	private static float _radius;
	public static float StartDepth{
		set{_startDepth = value;}
	}
	private static float _startDepth;
	public GameObject target;

	protected GameObject _mainCamera;
	protected GettersAndSetters _gettersAndSetters;

	void Start ()
	{
		_mainCamera = GameObject.Find("Main Camera");
		_gettersAndSetters = _mainCamera.GetComponent<GettersAndSetters>();


		GameObject obj0 = Instantiate(target, new Vector3(0,0, _startDepth), Quaternion.identity) as GameObject;
		obj0.name = "Start0"; 
		obj0.transform.parent = transform; 

		for(int i = 1; i < _numberOfLans; i++)
		{
			float angle = i *Mathf.PI * 2 / _numberOfLans;
			Vector3 pos = new Vector3(Mathf.Cos (angle), Mathf.Sin (angle), 0) * _radius;
			Vector3 posStart = pos + new Vector3(0,0,_startDepth);

			GameObject obj1 = Instantiate(target, posStart, Quaternion.identity) as GameObject;
			obj1.name = "Start" + i;
			obj1.transform.parent = transform;

		}
	}
}
