using UnityEngine;
using System.Collections;

public class PlannetSpawner : MonoBehaviour
{
	public GameObject plannet;
	public float time = 6f;
	private float timer = 0f;
	private bool _Spawn = false;
	private int plannetNumber = 1;
	private int randomLane;
	private GameObject Pipe;
	private PipeGrid otherScript;
	private int NumberOfLans = 0;

	// Use this for initialization
	void Start ()
	{
		timer = Time.time + time;
		Pipe = GameObject.Find("Pipe");
		PipeGrid otherScript = Pipe.GetComponent<PipeGrid>();
		NumberOfLans = otherScript.NumberOfLans;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if(_Spawn)
		{
			for(int i = 0; i < 6; i++)
			{
				bool spawnProbability = RandomBool();
				if(spawnProbability)
				{
					randomLane = (int)Random.Range(0f, NumberOfLans);
					GameObject obj1 = Instantiate(plannet,new Vector3(0,0,0), Quaternion.identity) as GameObject;
					obj1.name = "Plannet" + plannetNumber;
					obj1.transform.parent = transform;
					obj1.GetComponent<PlannetMovment>().lane = randomLane;
					plannetNumber++;
					_Spawn = false;
				}
			}
		}
		else
		{
			if(timer <= Time.time)
			{
				_Spawn = true;
				timer = Time.time + time;
			}
		}
	}
	bool RandomBool()
	{
		int prob = (int)Random.Range(0,100);
		if (prob < 20)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
