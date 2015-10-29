using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
	public Transform bullet;
	public int shotCD;
	[HideInInspector]
	public int currentCD;

	public Transform leftTurret;
	public Transform rightTurret;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (currentCD >= 1)
		{
			currentCD--;
		}
	}

	public void shoot()
	{
		if (currentCD <= 0)
		{
			Transform bulL = Instantiate (bullet, leftTurret.transform.position, leftTurret.transform.rotation) as Transform;
			Transform bulR = Instantiate (bullet, rightTurret.transform.position, rightTurret.transform.rotation) as Transform;
			currentCD = shotCD;
		}
	}
}
