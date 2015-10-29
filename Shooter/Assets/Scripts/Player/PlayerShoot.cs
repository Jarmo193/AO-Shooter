using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
	public Transform bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void shoot()
	{
		Transform bul = Instantiate (bullet, gameObject.transform.position, gameObject.transform.rotation) as Transform;
	}
}
