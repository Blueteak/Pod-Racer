using UnityEngine;
using System.Collections;

public class NetworkPod : MonoBehaviour {

	PhotonView v;
	public GameObject Base;
	public Transform Parent;

	// Use this for initialization
	void Awake () 
	{
		v = GetComponent<PhotonView>();
		if(v.ownerId == PhotonNetwork.player.ID)
		{
			Base.SetActive(false);
		}
		else
		{
			Debug.Log("Owner: " + v.owner.ID + " - Player: " + PhotonNetwork.player.ID);
		}
	}

	void Update()
	{
		transform.position = Parent.position;
		transform.eulerAngles = Parent.eulerAngles;
	}

	public void Setup(Transform T)
	{
		Parent = T;
	}
}
