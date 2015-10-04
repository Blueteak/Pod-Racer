using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Transform Engine1;
	public Transform Engine2;
	public Transform Pod;
	public Transform Pod2;

	Vector3 E1start;
	Vector3 E2start;
	Vector3 PStart;
	Vector3 P2Start;

	void Start()
	{
		E1start = Engine1.position;
		E2start = Engine2.position;
		PStart = Pod.position;
		P2Start = Pod2.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("Reset"))
		{
			Reset();
		}
	}

	void Reset()
	{
		Engine1.position = E1start;
		Engine1.eulerAngles = Vector3.zero;
		Engine2.position = E2start;
		Engine2.eulerAngles = Vector3.zero;
		Pod.position = PStart;
		Pod.eulerAngles = Vector3.zero;
		Pod2.position = P2Start;
		Pod2.eulerAngles = new Vector3(0, 270, 0);
	}
}
