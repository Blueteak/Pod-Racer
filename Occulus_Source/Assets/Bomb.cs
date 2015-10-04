using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	public GameObject Explosion;
	public AudioClip AC;

	void FixedUpdate()
	{
		GetComponent<Rigidbody>().AddForce(Vector3.down*3800f*Time.fixedDeltaTime);
	}

	// Update is called once per frame
	void OnCollisionEnter (Collision col) 
	{
		Instantiate(Explosion, transform.position, Quaternion.identity);
		if(AC != null)
			AudioSource.PlayClipAtPoint(AC, transform.position, 1.0f);
		Destroy(gameObject);
	}
}
