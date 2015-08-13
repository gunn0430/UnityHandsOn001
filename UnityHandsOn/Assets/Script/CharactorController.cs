using UnityEngine;
using System.Collections;

public class CharactorController : MonoBehaviour {

	public float walkSpeed = 7.0f;
	public float jumpPower = 5.0f;
	public GameObject MainCamera;

	private Vector3 defaultPos;
	private Rigidbody rigidbody;
	private Vector3 vec;
	private bool isTouch = false;

	void Start () {
		defaultPos = gameObject.transform.position;
		rigidbody = gameObject.GetComponent<Rigidbody>();
		vec = rigidbody.velocity;
		Input.gyro.enabled = true;
	}
	
	void Update () {
		MainCamera.transform.localRotation = Quaternion.AngleAxis(90.0f,Vector3.right)*Input.gyro.attitude*Quaternion.AngleAxis(180.0f,Vector3.forward);
		if (Input.touchCount > 0) {
			isTouch = true;
		} else {
			isTouch = false;
		}
	}

	void FixedUpdate(){
		if(isTouch){
			vec = rigidbody.velocity;
			Vector3 vel = walkSpeed * MainCamera.transform.forward;
			rigidbody.velocity = new Vector3 (vel.x,vec.y,vel.z);
		}
	}

	public void Jump(){
		rigidbody.AddForce (0,jumpPower,0,ForceMode.VelocityChange);
	}

	public void DefaultPos(){
		transform.position = defaultPos;
	}
}
