using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float smooth;

	private Rigidbody2D rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update ()
	{

	}

	void FixedUpdate()
	{
		Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 newPos = Vector3.Lerp(rb.transform.position, targetPos, smooth);
		rb.MovePosition(newPos);
	}
}
