using UnityEngine;
using System.Collections;

// vihollisen pääluokan runko, ei mitään kiveen hakattua
public class Enemy : MonoBehaviour
{
    public Transform ammoType; // mitä ammuksia vihollinen ampuu
    public int weaponCooldown = 90; // ampumisen aikaväli freimeinä

    /* ie. forward, down, player, behind(miinoja varten) */
    public string shootDirection;

    protected Vector3 shootDir = Vector3.zero;

	private Animator anim;
	public string PathAnimation
	{
		get
		{
			return "Current animation playing";
		}
		set
		{
			anim.Play(value);
		}
	}

	// Use this for initialization
	void Start ()
    {
		anim = GetComponent<Animator> ();
		inverseShootDir();
    }

    protected void inverseShootDir()
    {
        shootDir += new Vector3(0, 0, 180);
        if(shootDir.z > 360)
            shootDir -= new Vector3(0, 0, 360);
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        weaponCooldown++;
        if(weaponCooldown >= 90)
        {
            shoot();
            weaponCooldown = 0;
        }
	}

    protected virtual void shoot() // <- virtual sana override komentoa varten lapsi luokissa
    {
        Transform bul = Instantiate(ammoType, transform.position, Quaternion.Euler(transform.eulerAngles + shootDir)) as Transform;
        bul.tag = "EnemyBullet";
    }
}
