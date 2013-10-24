using UnityEngine;
using System.Collections;

public class FaceToCam : MonoBehaviour {

	protected Animator animator;
	public Transform target;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		if ( target == null ) {
			target = GameObject.FindGameObjectWithTag("MainCamera").transform;
		}
	}

	// Update is called once per frame
	void Update () {
		animator.SetLookAtPosition(target.position);
		animator.SetLookAtWeight(0.7f);
	}
}
