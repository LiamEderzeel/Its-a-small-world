using UnityEngine;
using System.Collections;

public class OutroVideo : MonoBehaviour {
	//Variables
	public MovieTexture Video;
	private float timer;
	private bool SetTimer;
	
	// Use this for initialization
	void Start ()
	{
		Video.Stop();
		GetComponent<AudioSource>().Play();
		timer = Time.time + Video.duration;
		
	}
	void Update ()
	{
		if(Time.time >= timer)
		{
			Main.ResetGame();
		}
	}
	// Update is called once per frame
	void OnGUI () {

		Video.Play();
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),Video,ScaleMode.StretchToFill, false, 0.0f);
	}
}
