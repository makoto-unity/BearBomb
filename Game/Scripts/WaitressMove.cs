using UnityEngine;
using System.Collections;

public class WaitressMove : MonoBehaviour {

	public float stopLimitLength = 0.3f; // 30cm

	public Vector3 targetPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 nowPos = this.transform.position;
		float leng = (nowPos - targetPos).magnitude;
		if ( leng > stopLimitLength ) {

		}
	}
}
