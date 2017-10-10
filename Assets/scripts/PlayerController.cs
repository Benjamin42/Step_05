using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	private Animator anim;

	void Start () {
		anim = GetComponent<Animator>();
	}

	public void Move(Vector3 targetPosition, float speed) {
		anim.SetBool("IsWalking", true);

		transform.LookAt(targetPosition);
		transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
		if (transform.position == targetPosition) {
			anim.SetBool("IsWalking", false);
		}
	}
}
