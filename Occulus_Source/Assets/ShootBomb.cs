using UnityEngine;
using System.Collections;

public class ShootBomb : Photon.PunBehaviour {

	public Transform Cam;
	public GameObject BombPrefab;

	// Use this for initialization
	[PunRPC]
	public void ShootObject(string info)
	{
		string[] Vectors = info.Split(':');
		float Force;
		float Px;
		float Py;
		float Pz;
		float Vx;
		float Vy;
		float Vz;
		float.TryParse(Vectors[0], out Force);

		string[] P = Vectors[1].Split(',');
		string[] V = Vectors[2].Split(',');

		float.TryParse(P[0], out Px);
		float.TryParse(P[1], out Py);
		float.TryParse(P[2], out Pz);

		float.TryParse(V[0], out Vx);
		float.TryParse(V[1], out Vy);
		float.TryParse(V[2], out Vz);

		Vector3 Pos = new Vector3(Px, Py, Pz);
		Vector3 Vel = new Vector3(Vx, Vy, Vz);

		GameObject NewBomb = Instantiate(BombPrefab);
		NewBomb.transform.position = Pos*200;
		NewBomb.GetComponent<Rigidbody>().velocity = Vel*Force*150;
		NewBomb.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(-20,20),Random.Range(-20,20),Random.Range(-20,20));
	}
	
	// Update is called once per frame
	public void Shoot ()
	{
		string S = "";
		S += 10+":";
		float Vx = Cam.position.x;
		float Vy = Cam.position.y;
		float Vz = Cam.position.z;
		S += Vx + "," + Vy + "," + Vz + ":";
		Vector3 FF = Cam.TransformDirection(Vector3.forward);
		S += FF.x + "," + FF.y + "," + FF.z;
		GetComponent<PhotonView>().RPC("ShootObject", PhotonTargets.All, S);
	}
}
