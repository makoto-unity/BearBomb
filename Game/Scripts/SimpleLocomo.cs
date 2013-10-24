 /// <summary>
/// 
/// </summary>

using UnityEngine;
using System;
using System.Collections;
  
[RequireComponent(typeof(Animator))]  

//Name of class must be name of file as well

public class SimpleLocomo : MonoBehaviour {

    protected Animator animator;

	public Transform target;
	private int diffFwdId;
	private int diffRightId;
	private int directionId;
	private int priorityId;

	public float diffDampTime = 0.1f;
	public float directionResponseTime = 0.2f;

	// Use this for initialization
	void Start () 
	{
        animator = GetComponent<Animator>();
		diffFwdId = Animator.StringToHash("DiffFwd");
		diffRightId = Animator.StringToHash("DiffRight");
		directionId = Animator.StringToHash("Direction");
		priorityId = Animator.StringToHash("HighPriority");
	}
    
	Vector3 relativePos;
	float diffFwd;
	float diffRight;
	float direction;
	int priority = 0;

	void Update () 
	{
		relativePos = this.transform.InverseTransformPoint (target.transform.position);
		diffFwd = relativePos.z;
		diffRight = relativePos.x;
		direction = target.transform.eulerAngles.y - this.transform.eulerAngles.y;
		animator.SetFloat(diffFwdId,   diffFwd);
		animator.SetFloat(diffRightId, diffRight);
		animator.SetFloat(directionId, direction);

		float pri1 = Mathf.Abs(diffFwd);
		float pri2 = Mathf.Abs(diffRight);
		float pri3 = Mathf.Abs(direction);

		if ( isStayMode ) {
			priority = 4;
		}
		else if ( pri1 < 0.1f && pri2 < 0.1f && pri3 < 0.1f ) {
			priority = 0;
		} else {
			if (pri3 > 5.0f) {
				priority = 3;
			} else {
				priority = 1;
			}
		}
		animator.SetInteger(priorityId, priority);
	}

	bool isStayMode = false;

	void OnTriggerEnter(Collider other) {
		if ( isStayMode == false ) {
			isStayMode = true;
			print ("Hit!");
			iTween.MoveTo (this.gameObject, other.transform.position, 1.0f);
			iTween.RotateTo(this.gameObject, other.transform.eulerAngles, 1.0f );
		}
	}
}
