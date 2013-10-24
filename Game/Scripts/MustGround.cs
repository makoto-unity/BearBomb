using UnityEngine;
using System.Collections;

public class MustGround : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}


	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 pos = this.transform.position;
		pos.y = 0.0f;
		pos.x = 0.0f;
		this.transform.position = pos;
	}
}
