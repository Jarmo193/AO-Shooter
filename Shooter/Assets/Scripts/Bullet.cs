﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	public int Speed = 5;
	public int Damage = 5;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void FixedUpdate ()
	{
		MoveForward ();
	}

	protected void doDamage(GameObject target)
	{

	}

	void MoveForward ()
	{
		transform.Translate (new Vector3 (0, Speed * Time.deltaTime, 0));
	}
}