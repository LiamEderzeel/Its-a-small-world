using UnityEngine;
using System.Collections;

public class GettersAndSetters : MonoBehaviour {

	public float _jumpForce = 250f;
	public float _stompForce = 600f;
	public int _comboAmount = 2;
	public float _comboMultiplier = 0.8f;
	private int _planetCombo = 0;

	public float jumpForce {
		get { return _jumpForce; }
		set { _jumpForce = value; }
	}
	public float stompForce {
		get { return _stompForce; }
		set { _stompForce = value; }
	}
	public int comboAmount {
		get { return _comboAmount; }
		set { _comboAmount = value; }
	}
	public float comboMultiplier {
		get { return _comboMultiplier; }
		set { _comboMultiplier = value; }
	}
	public int planetCombo {
		get { return _planetCombo; }
		set { _planetCombo = value; }
	}
	
	void Start () {
	
	}

	void Update () {
	
	}
}
