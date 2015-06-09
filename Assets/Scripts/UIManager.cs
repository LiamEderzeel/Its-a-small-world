using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class UIManager : MonoBehaviour {
	private Text _planetCombo;
	// Use this for initialization
	void Start () {
		_planetCombo = GameObject.Find("PlanetCombo").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		_planetCombo.text =  "x" + PlayerMovment.CurentCombo.ToString();
	}
}