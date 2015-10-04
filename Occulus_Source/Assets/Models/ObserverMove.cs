using UnityEngine;
using System.Collections;

public class ObserverMove : MonoBehaviour {

	Transform T;

	// Use this for initialization
	void Start () 
	{
		T = transform.parent;
		transform.SetParent(null);
	}
	
	// Update is called once per frame
	void Update () {
		transform.eulerAngles = T.eulerAngles;
		transform.position = T.position*200;
	}
}
