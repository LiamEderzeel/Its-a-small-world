using UnityEngine;
using System.Collections;

public class PipeGrid : MonoBehaviour {

	public bool visualisation = false;
	private int _numberOfLans;
	private float _radius;
	private float _startDept;
	private float _endDept;
	public GameObject target;

	protected GameObject _mainCamera;
	protected GettersAndSetters _gettersAndSetters;

	void Awake ()
	{
		_mainCamera = GameObject.Find("Main Camera");
		_gettersAndSetters = _mainCamera.GetComponent<GettersAndSetters>();
		_numberOfLans = _gettersAndSetters.numberOfLans;
		_startDept = _gettersAndSetters.startDept;
		_endDept = _gettersAndSetters.endDept;
		_radius = _gettersAndSetters.radius;

		for(int i = 0; i < _numberOfLans; i++)
		{
			float angle = i *Mathf.PI * 2 / _numberOfLans;
			Vector3 pos = new Vector3(Mathf.Cos (angle), Mathf.Sin (angle), 0) * _radius;
			Vector3 posStart = pos + new Vector3(0,0,_startDept);
			Vector3 posEnd = pos + new Vector3(0,0,_endDept);

			GameObject obj1 = Instantiate(target, posStart, Quaternion.identity) as GameObject;
			obj1.name = "Start" + i;
			obj1.transform.parent = transform;

			GameObject obj2 = Instantiate(target, posEnd, Quaternion.identity) as GameObject;
			obj2.name = "End" + i;
			obj2.transform.parent = transform;
		}
	}
	void Update () {

	}
}
