using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;

	private CharacterController controller;
	private Camera cam;

	void Start () {

		controller = GetComponent<CharacterController>();
		cam = GetComponentInChildren<Camera>();

	}

	void Update() {

		Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		movement *= speed;

		controller.Move(movement);

		//Making player look at the mouse, assuming that the player is in the middle of the screen
		Vector3 mouse_pos = Input.mousePosition;
		mouse_pos -= new Vector3(Screen.width / 2, Screen.height / 2, 0);

		float target_angle = Mathf.Rad2Deg * Mathf.Atan2(mouse_pos.y, mouse_pos.x);

		transform.eulerAngles = new Vector3(0, 0, target_angle);

	}
}
