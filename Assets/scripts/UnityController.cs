﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityController : MonoBehaviour {
	
	public int nbInstance = 1;
	public float speed = 2f;

	private GameObject[] clone;
	private Vector3 targetPosition;
	private bool isWalking;

	void Start () {
		clone = new GameObject[nbInstance];
		for (int i = 0; i < nbInstance; i++) {
			Vector3 position = new Vector3 (0 + 2 * i, 0, 0);
			clone[i] = Instantiate(Resources.Load("OrcPrefab"), position, Quaternion.identity) as GameObject;
		}

		targetPosition = transform.position;
	}

	void Update () {
		if (Input.GetMouseButton (GameConstants.RIGHT_MOUSE_BUTTON)) {
			UpdatePosition ();
		}

		if (isWalking) {
			for (int i = 0; i < nbInstance; i++) {
				PlayerController myComponent = clone[i].GetComponent<PlayerController> ();
				Vector3 position = new Vector3 (targetPosition.x + 2 * i, 0, targetPosition.z);
				myComponent.Move (position, speed);
			}
		}
	}

	void UpdatePosition() {
		Plane plane = new Plane(Vector3.up, transform.position);
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		float point = 0f;
		if (plane.Raycast (ray, out point)) {
			targetPosition = ray.GetPoint (point);
		}

		isWalking = true;
	}
}
