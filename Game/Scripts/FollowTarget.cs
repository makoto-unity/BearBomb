using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

	public Transform target = null;
	public bool canIK = true;

	public float lengLimit = 0.01f;
	public float moveTime = 0.5f;

//	IEnumerator Start() {
//		while(true) {
//			float leng = (this.transform.position - target.position).magnitude;
//			if ( leng > lengLimit ) {
//				iTween.MoveTo(this.gameObject, iTween.Hash("position", target.position, "easeType", "easeOutCubic", "time", moveTime));
//				yield return new WaitForSeconds(moveTime * 0.5f);
//			}
//			yield return null;
//		}
//	}
	void FixedUpdate() {
		this.transform.position = target.position;
	}

}
