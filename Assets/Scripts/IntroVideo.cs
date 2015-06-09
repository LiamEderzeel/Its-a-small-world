using UnityEngine;
using System.Collections;

public class IntroVideo : MonoBehaviour {
	//Variables
	public MovieTexture Video;
	private float timer;
	public AudioClip VideoSound;
	
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
			Main.ToGame();
		}
	}
	// Update is called once per frame
	void OnGUI () {

		Video.Play();
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),Video,ScaleMode.StretchToFill, false, 0.0f);
	}
}
