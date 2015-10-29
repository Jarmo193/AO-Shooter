using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
	public PlayerShoot shootScript;

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			shootScript.shoot();
		}
	}
}
