using UnityEngine;
using System.Collections;

public class NetworkManager : Photon.PunBehaviour {

	public Transform Cam;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnJoinedRoom () 
	{
		Debug.Log("Joined Room");
		PhotonNetwork.Instantiate("ObserverCam", Cam.transform.position, Quaternion.identity, 0);
	}
}
