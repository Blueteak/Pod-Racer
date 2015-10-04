using UnityEngine;
using System.Collections;

public class NetworkRacer : Photon.PunBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnJoinedRoom()
	{
		GameObject Pod = (GameObject)PhotonNetwork.Instantiate("FakePodObj", transform.position, Quaternion.identity, 0);
		Pod.GetComponent<NetworkPod>().Setup(transform);
	}
}
