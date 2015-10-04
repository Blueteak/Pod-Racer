using UnityEngine;
using System.Collections;

public class BaseAudio : MonoBehaviour {

	public AudioSource Asource;

	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds(0.75f);
		Asource.Play();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
