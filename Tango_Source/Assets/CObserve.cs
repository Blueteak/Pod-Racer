using UnityEngine;
using System.Collections;

public class CObserve : MonoBehaviour {

	Transform T;

	// Use this for initialization
	void Start () {
		T = GameObject.FindObjectOfType<TangoDeltaPoseController>().transform;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = T.position;
		transform.eulerAngles = T.eulerAngles;
	}
}
