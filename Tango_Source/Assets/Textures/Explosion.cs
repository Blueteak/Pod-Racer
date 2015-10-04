using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public float loopduration;

	float CH = 0;

	// Use this for initialization
	void Start () 
	{
		transform.localScale = Vector3.one * 0.05f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.localScale += Vector3.one*.4f*Time.deltaTime;
		float r = Mathf.Sin((Time.time / loopduration) * (2 * Mathf.PI)) * 0.5f + 0.25f;
		float g = Mathf.Sin((Time.time / loopduration + 0.33333333f) * 2 * Mathf.PI) * 0.5f + 0.25f;
		float b = Mathf.Sin((Time.time / loopduration + 0.66666667f) * 2 * Mathf.PI) * 0.5f + 0.25f;
		float correction = 1 / (r + g + b);
		r *= correction;
		g *= correction;
		b *= correction;
		if(transform.localScale.x > .15f)
			CH += Time.deltaTime*(transform.localScale.x*40);
		if(CH > 15)
			Destroy(gameObject);
		GetComponent<Renderer>().material.SetVector("_ChannelFactor", new Vector4(r+CH,g,b,0));
	}
}
