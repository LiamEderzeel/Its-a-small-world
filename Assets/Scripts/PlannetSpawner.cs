using UnityEngine;
using System.Collections;

public class PlannetSpawner : MonoBehaviour {

	private bool _Spawn = false;
	public float time = 6f;
	private float timer = 0f;
	public GameObject plannet;
	private int plannetNumber = 1;

	// Use this for initialization
	void Start () {
		timer = Time.time + time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(_Spawn)
		{
			GameObject obj1 = Instantiate(plannet,new Vector3(0,0,0), Quaternion.identity) as GameObject;
			obj1.name = "Plannet" + plannetNumber;
			obj1.transform.parent = transform;
			plannetNumber++;
			_Spawn = false;
		} else {
			if(timer <= Time.time){
				_Spawn = true;
				timer = Time.time + time;
			}
		}
	}
}
