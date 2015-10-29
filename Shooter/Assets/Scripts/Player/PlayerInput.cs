using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
	public PlayerShoot shootScript;

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKey(KeyCode.Space))
		{
			shootScript.shoot();
		}
	}
}
