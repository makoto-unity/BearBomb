using UnityEngine;
using System.Collections;

public class MorphBlink : MonoBehaviour {

	public float startParam = 0.45f;
	public float targetParam = 1.0f;
	public float blinkTime = 0.2f;
	public float blinkSpeed = 10.0f;
	float nowParam ;
	float endParam;
	MMD4MecanimModel mmd;
	public float waitTime = 4.0f;
	public float doubleBlinkRatio = 0.3f;
	public int morphId = 0;
	public bool isOnce = false;

	// Use this for initialization
	IEnumerator Start () {
		yield return null;
		
		mmd = (MMD4MecanimModel) GetComponent<MMD4MecanimModel>();
		
		mmd.morphList[morphId].weight = startParam;     // 00:まばたき 
		yield return null;
		nowParam = startParam;

		if ( isOnce ) {
			nowParam = startParam;
			endParam = targetParam;
			StartCoroutine("motionSmooth");
			yield return new WaitForSeconds(blinkTime);
		} else {
			StartCoroutine("blinkSequence");
		}

	}

	IEnumerator blinkSequence()
	{
		while(true) {
			if ( Random.value < doubleBlinkRatio ) {
				StartCoroutine("blink");
				yield return new WaitForSeconds(blinkTime * 2.0f);
				StartCoroutine("blink");
			} else {
				StartCoroutine("blink");
			}
			yield return new WaitForSeconds(waitTime + Random.value * 2.0f);
		}
	}
	
	IEnumerator blink() 
	{
		nowParam = startParam;
		endParam = targetParam;
		StartCoroutine("motionSmooth");
		yield return new WaitForSeconds(blinkTime);
		nowParam = targetParam;
		endParam = startParam;
		StartCoroutine("motionSmooth");
		yield return new WaitForSeconds(blinkTime);
	}
	
	IEnumerator motionSmooth() 
	{
		float myTime = blinkTime;
		while( myTime > 0.0f ) {
			nowParam = iTween.FloatUpdate(nowParam, endParam, blinkSpeed);
			mmd.morphList[morphId].weight = nowParam; // 00:まばたき 
			myTime -= Time.deltaTime;
			yield return null;
		}
	}
}
