using UnityEngine;
using System.Collections;

public class PipeGrid : MonoBehaviour {

	public int NumberOfLans = 12;
	public float radius = 3f;
	public float startDept = 10f;
	public float endDept = -5f;
	public GameObject sphere;
	public Vector3[] start;
	public Vector3[] end;

	// Use this for initialization
	void Start () {
		start = new Vector3[NumberOfLans];
		end = new Vector3[NumberOfLans];

		for(int i = 0; i < NumberOfLans; i++)
		{
			float angle = i *Mathf.PI * 2 / NumberOfLans;
			Vector3 pos = new Vector3(Mathf.Cos (angle), Mathf.Sin (angle), 0) * radius;
			Vector3 posStart = pos + new Vector3(0,0,startDept);
			Vector3 posEnd = pos + new Vector3(0,0,endDept);

			start[i] = posStart;
			end[i] = posEnd;
		}
		for(int i = 0; i < start.Length; i++)
		{
			GameObject obj1 = Instantiate(sphere, start[i], Quaternion.identity) as GameObject;
			obj1.name = "Start" + i;
			obj1.transform.parent = transform;
			GameObject obj2 = Instantiate(sphere, end[i], Quaternion.identity) as GameObject;
			obj2.name = "End" + i;
			obj2.transform.parent = transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
