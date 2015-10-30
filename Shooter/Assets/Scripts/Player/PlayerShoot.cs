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

    public AudioClip soundSFX;
    private AudioSource soundPlayer;
    // Use this for initialization
    void Start ()
    {
        if(soundSFX != null)
        {
            soundPlayer = gameObject.GetComponent<AudioSource>();
        }
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
			bulL.tag = "PlayerBullet";
			Transform bulR = Instantiate (bullet, rightTurret.transform.position, rightTurret.transform.rotation) as Transform;
			bulR.tag = "PlayerBullet";
			currentCD = shotCD;

            if(soundPlayer != null)
            {
                soundPlayer.PlayOneShot(soundSFX);
            }
		}
	}
}
