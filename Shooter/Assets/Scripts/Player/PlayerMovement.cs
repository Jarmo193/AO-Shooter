using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float smooth;

	public float turnFactor = 0.01f;
	public float maxAngle = 45;

	private bool leftMouseClicked = false;
	public bool MouseClicked
	{
		get
		{
			return leftMouseClicked;
		}
		set
		{
			leftMouseClicked = value;
		}
	}

	private Vector3 originalRotation;
	private Rigidbody2D rb;

	void Start ()
	{
		originalRotation = transform.rotation.eulerAngles;
		rb = GetComponent<Rigidbody2D>();
	}

	void Update ()
	{

	}

	void FixedUpdate()
	{
		if (!leftMouseClicked)
		{
			if(transform.rotation.eulerAngles.z != originalRotation.z)
			{
				if(transform.eulerAngles.z > 300)
					transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, 0, 359.9f), turnFactor);
				else
					transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, originalRotation, turnFactor);

				if(transform.eulerAngles.z >= 359.5f ||
				   transform.eulerAngles.z <= 0.5f)
				{
					transform.eulerAngles = originalRotation;
				}
			}

			Vector3 targetPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector3 newPos = Vector3.Lerp (rb.transform.position, targetPos, smooth);
			rb.MovePosition (newPos);
		}
		else
		{
			Vector3 targetPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector3 angleToTarget =  targetPos - new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, transform.position.z);
			angleToTarget.Normalize();
			float rot_z = Mathf.Atan2 (angleToTarget.y, angleToTarget.x) * Mathf.Rad2Deg;
			GameObject go = new GameObject();
			go.transform.position = this.transform.position;
			go.transform.LookAt(new Vector3(targetPos.x, targetPos.y, transform.position.z));
			go.transform.eulerAngles = new Vector3(0, 0, go.transform.eulerAngles.x);

			Debug.Log("angle to target : "+go.transform.eulerAngles.ToString());

			if(angleToTarget.z < 0)
			{
				if(Mathf.Abs(transform.rotation.eulerAngles.z) - Mathf.Abs(originalRotation.z) > (360-maxAngle) ||
				   Mathf.Abs(transform.rotation.eulerAngles.z) - Mathf.Abs(originalRotation.z) < maxAngle+10)
					transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, Quaternion.Euler(0f, 0f, rot_z - 90), turnFactor);
			}
			else if(angleToTarget.z > 0)
			{
				if(Mathf.Abs(transform.rotation.eulerAngles.z) + Mathf.Abs(originalRotation.z) < maxAngle || 
				   Mathf.Abs(transform.rotation.eulerAngles.z) + Mathf.Abs(originalRotation.z) > 360-maxAngle-10 )
					transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, Quaternion.Euler(0f, 0f, rot_z - 90), turnFactor);
			}
		}
	}
}
