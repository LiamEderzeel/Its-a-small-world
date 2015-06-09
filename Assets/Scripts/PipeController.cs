using UnityEngine;
using System.Collections;

public class PipeController : MonoBehaviour
{

	public float speed = 120.0f;

	public static bool RotationControlles {
		set{ _rotationControlles = value;}
	}

	private static bool _rotationControlles = false;

	void Update ()
	{
		if (_rotationControlles) {
			if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
				gameObject.transform.Rotate (Vector3.forward * speed * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
				gameObject.transform.Rotate (-Vector3.forward * speed * Time.deltaTime);
			} else if (Input.GetAxis ("Horizontal") != 0) {
				float roation = Input.GetAxis ("Horizontal") * speed;
				gameObject.transform.Rotate (-Vector3.forward * roation * Time.deltaTime);
			}
		}
	}
}
