using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]  
public class GrabIt : MonoBehaviour {

	protected Animator avatar;
	public GameObject follow = null;
	public bool canIK = true;

	public float lookAtWeight = 1.0f;

	void Start () {
		avatar = GetComponent<Animator>();
	}
	
	private float grabStartTime = 0.0f;
	private float handWeight = 0.0f;
	
	void OnEnable() {
		grabStartTime = Time.time;
	}
	
	void Unfollow() {
		grabStartTime = Time.time;
		canIK = false;
	}

	public float playSec = 4.0f;
	public AvatarIKGoal goal = AvatarIKGoal.RightHand;
	
	void OnAnimatorIK(int layerIndex)
	{		
		if(canIK && avatar && follow && layerIndex == 0) 
		{
			handWeight = 1.0f;
			//handWeight = Mathf.Lerp(0.0f, 1.0f, (Time.time - grabStartTime) / playSec );
							
			avatar.SetIKPositionWeight(goal,handWeight);
//			avatar.SetIKRotationWeight(AvatarIKGoal.RightHand,handWeight);

			avatar.SetIKPosition(goal,follow.transform.position);
//			avatar.SetIKRotation(AvatarIKGoal.RightHand,rightHandTarget.rotation);
		}	

//		if(isLookAt == false && avatar && rightHandTarget) 
//		{
//			handWeight = Mathf.Lerp(1.0f, 0.0f, (Time.time - grabStartTime) / playSec );
//			avatar.SetIKPositionWeight(AvatarIKGoal.RightHand,handWeight);
//			avatar.SetIKPosition(AvatarIKGoal.RightHand,rightHandTarget.position);
//		}	
	}
}
