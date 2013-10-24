using UnityEngine;
using System.Collections;

public class EyeToTarget : MonoBehaviour {
	public Transform target;
	private Transform refThis;

	// Use this for initialization
	void Start () {
		if ( target == null ) {
			target = GameObject.FindGameObjectWithTag("MainCamera").transform;
		}
		GameObject newObj = new GameObject();
		newObj.name = "ref";
		refThis = newObj.transform;
		refThis.parent = this.transform.parent;
		Transform eye = transform.GetChild(0);
		refThis.position = eye.position;
		refThis.Translate(0.0f, 0.0f, leng);
	}

	public float dotLimit = 0.5f;
	public float leng = 10.0f;

	// Update is called once per frame
	void Update () {
		Transform parentTrs = this.transform.parent;
		refThis.LookAt(target.position, parentTrs.up );
		this.transform.rotation = refThis.rotation;
		//Debug.DrawLine(this.transform.position, target.position, Color.red);
	}
}
