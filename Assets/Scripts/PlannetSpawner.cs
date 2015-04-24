using UnityEngine;
using System.Collections;

public class PlannetSpawner : MonoBehaviour {

	private bool _Spawn = true;
	private int timer = 0;
	public GameObject plannet;
	private int plannetNumber = 1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(_Spawn)
		{
			GameObject obj1 = Instantiate(plannet,new Vector3(0,0,0), Quaternion.identity) as GameObject;
			obj1.name = "Plannet" + plannetNumber;
			obj1.transform.parent = transform;
			plannetNumber++;
			_Spawn = false;
		} else {
			if(timer == 50){
				_Spawn = true;
				timer = 0;
			} else {
				timer++;
			}
		}
	}
}
