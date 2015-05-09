﻿using UnityEngine;
using System.Collections;

public class PipeGrid : MonoBehaviour {

	public bool visualisation = false;
	public int NumberOfLans = 12;
	public float radius = 3f;
	public float startDept = 10f;
	public float endDept = -10f;
	public GameObject sphere;

	void Awake () {
		for(int i = 0; i < NumberOfLans; i++)
		{
			float angle = i *Mathf.PI * 2 / NumberOfLans;
			Vector3 pos = new Vector3(Mathf.Cos (angle), Mathf.Sin (angle), 0) * radius;
			Vector3 posStart = pos + new Vector3(0,0,startDept);
			Vector3 posEnd = pos + new Vector3(0,0,endDept);

			GameObject obj1 = Instantiate(sphere, posStart, Quaternion.identity) as GameObject;
			obj1.name = "Start" + i;
			obj1.transform.parent = transform;

			GameObject obj2 = Instantiate(sphere, posEnd, Quaternion.identity) as GameObject;
			obj2.name = "End" + i;
			obj2.transform.parent = transform;
		}
	}
	void Update () {

	}
}
