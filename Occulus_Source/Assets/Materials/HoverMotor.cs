using UnityEngine;
using System.Collections;

public class HoverMotor : MonoBehaviour {

	public float speed = 90f;
	public float turnSpeed = 5f;
	public float hoverForce = 65f;
	public float hoverHeight = 3.5f;
	private float origHeight;
	private float powerInput;
	private float turnInput;
	public string FCommand;
	private Rigidbody carRigidbody;
	public Vector3 DirSide;
	public Transform ControlRod;
	public float MaxX;
	public ParticleSystem Psyst;

	public Rigidbody OtherEngine;

	public AudioSource VariableAudio;

	float WantVol;
	float WantPitch;
	
	void Start () 
	{
		origHeight = hoverHeight;
		carRigidbody = GetComponent <Rigidbody>();
	}

	void Update () 
	{
		float X = Mathf.Abs(1+Input.GetAxis(FCommand))/2.0f;
		if(ControlRod != null)
		{
			WantVol = 0.25f*(X+.1f);
			WantPitch = Mathf.Clamp((X+.45f)*1.2f,1,1.8f);
			ControlRod.eulerAngles = new Vector3(X*MaxX, ControlRod.eulerAngles.y, 0);
			Psyst.startSize = 1 + 3*X;
			Psyst.startSpeed = 5 + 15*X;
		}
		if(X > 0.1f && ControlRod != null)
		{
			hoverHeight = origHeight * 1.5f;
			OtherEngine.AddRelativeForce(Vector3.forward*speed*Time.deltaTime*X*0.25f);
			carRigidbody.AddRelativeForce(Vector3.forward*speed*Time.deltaTime*X);
			//carRigidbody.AddRelativeForce(DirSide*speed*Time.deltaTime*0.15f*X);
		}
		else
			hoverHeight = origHeight;
		if(ControlRod != null)
		{
			VariableAudio.volume += (WantVol-VariableAudio.volume)*Time.deltaTime;
			VariableAudio.pitch += (WantPitch-VariableAudio.pitch)*Time.deltaTime;
		}
	}

	void FixedUpdate()
	{
		carRigidbody.velocity *= 0.98f;
		carRigidbody.angularVelocity *= .8f;
		Ray ray = new Ray (transform.position, -transform.up);
		RaycastHit hit;
		
		if (Physics.Raycast(ray, out hit, hoverHeight))
		{
			float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
			Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
			carRigidbody.AddForce(appliedHoverForce, ForceMode.Acceleration);
		}
		
		carRigidbody.AddRelativeForce(0f, 0f, powerInput * speed);
		carRigidbody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);

		if(transform.eulerAngles.z > 15 && transform.eulerAngles.z < 180)
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 15);
		if(transform.eulerAngles.z < 345 && transform.eulerAngles.z > 180)
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -15);
		
	}
}
