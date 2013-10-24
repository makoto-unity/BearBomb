using UnityEngine;
using System.Collections;

public class FaceMotion : MonoBehaviour {

	MMD4MecanimModel mmd;

	// Use this for initialization
	IEnumerator Start () {
		yield return null;

		mmd = (MMD4MecanimModel) GetComponent<MMD4MecanimModel>();

		mmd.morphList[ 0].weight = 0.45f;     // 00:まばたき 
		mmd.morphList[46].weight = 1.0f;     // 46:照れ
		yield return null;
		mmd.morphList[49].weight = 0.58f;    // 49:困る
		mmd.morphList[53].weight = 0.67f;    // 53:下

	}

	public void Face2() {
		MorphBlink [] blinks = GetComponents<MorphBlink>();
		foreach( MorphBlink blink in blinks ) {
			if ( blink.enabled == false ) {
				blink.enabled = true;
			}
		}
	}
}
