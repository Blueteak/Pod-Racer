using UnityEngine;
using System.Collections;

public class PodRacer : MonoBehaviour {

	Transform T;

	// Use this for initialization
	void Start () {
		T = transform.parent;
		transform.SetParent(null);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.eulerAngles = T.eulerAngles;
		transform.position = T.position/200.0f;// + (Vector3.up * 0.3f);
	}
}
