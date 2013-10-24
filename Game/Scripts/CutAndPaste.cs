using UnityEngine;
using System.Collections;

public class CutAndPaste : MonoBehaviour {

	public Transform prevParent;
	void Awake() {
	}

	// Use this for initialization
	void Start () {
		this.transform.parent = prevParent;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
