using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float CameraMoveSpeed = 4f;

	void Update () {

		if (Input.GetKey(KeyCode.A)) {
			transform.Translate(new Vector3(-CameraMoveSpeed * Time.deltaTime, 0, 0));
		}

		if (Input.GetKey(KeyCode.D)) {
			transform.Translate(new Vector3(CameraMoveSpeed * Time.deltaTime, 0, 0));
		}

		if (Input.GetKey(KeyCode.W)) {
			transform.Translate(new Vector3(0, CameraMoveSpeed * Time.deltaTime, 0));
		}

		if (Input.GetKey(KeyCode.S)) {
			transform.Translate(new Vector3(0, -CameraMoveSpeed * Time.deltaTime, 0));
		}
	}

}
