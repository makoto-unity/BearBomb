using UnityEngine;
using System.Collections;

public class TouchAndGo : MonoBehaviour {

	int priorityId = 0;
	bool isSet = false;

	// Use this for initialization
	void Start () {
		priorityId = Animator.StringToHash("HighPriority");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Animator animator;

	void OnTriggerEnter(Collider other) {
		if ( isSet == false ) {
			isSet = true;
			animator.SetInteger(priorityId, 4);
			//StartCoroutine("setPriId");
			print ("Hit!");
		}
	}

	IEnumerator setPriId() {
		yield return new WaitForSeconds(1.0f);
		animator.SetInteger(priorityId, 0);
	}
}
